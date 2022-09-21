using Au.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Au
{
    public class SettingsManager
    {
        public const string dirSettings = "GameSettings";
        public const string dirCommon = "common";
        public const string dirPlatform = "platforms";
        public const string dirConfig = "configs";
        public const string fileAppConfig = "app.json";
        public const string filePlatformConfig = "platform.json";
        public const string fullpathAppConfig = "Assets/Resources/" + fileAppConfig;
        public const string defaultConfigName = "dev";

        private Dictionary<string, SettingPanel> panels = new Dictionary<string, SettingPanel>();
        private SettingPanel currentPanel;
        private string[] allConfigs;
        private int currentIndexOfConfig = -1;
        private bool showCreatePanel = false;
        private string newPlatformName = "";

        public AppConfig appConfig { get; protected set; }
        public PlatformConfig platformConfig { get; protected set; }

        public virtual void Initialize()
        {
            EditorHelper.DirEnsure(Path.Combine("Assets", "Resources")); // ensure Resources dir exists

            InitializePanels();
            currentPanel = panels.Values.First();
            currentPanel.OnShow();

            string platformdir = Path.Combine(dirSettings, dirPlatform);
            string configdir = Path.Combine(dirSettings, dirConfig);
            string commonDir = Path.Combine(dirSettings, dirCommon);

            EditorHelper.DirEnsure(platformdir);
            EditorHelper.DirEnsure(configdir);
            EditorHelper.DirEnsure(commonDir);

            allConfigs = new DirectoryInfo(platformdir)
                .GetDirectories()
                .SelectMany(p => new DirectoryInfo(configdir)
                    .GetDirectories()
                    .Select(d => $"{p.Name}/{d.Name}")
            ).ToArray();

            LoadConfigs();

            if (IsConfigValid())
            {
                var currentconfigname = $"{platformConfig.name}/{appConfig.name}";
                currentIndexOfConfig = allConfigs.ToList().IndexOf(currentconfigname);
            }
        }

        public void OnGUI()
        {
            if (EditorApplication.isCompiling)
            {
                EditorGUILayout.LabelField("Project is compiling !!",
                    EditorStyles.centeredGreyMiniLabel,
                    GUILayout.ExpandWidth(true),
                    GUILayout.ExpandHeight(true));
                return;
            }

            DrawConfigSelector();
            // DrawCreatePanel();

            if (!IsConfigValid())
            {
                EditorGUILayout.LabelField("Config invalid !!",
                    EditorStyles.centeredGreyMiniLabel,
                    GUILayout.ExpandWidth(true),
                    GUILayout.ExpandHeight(true));
                return;
            }

            using (new EditorGUILayout.HorizontalScope(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
            {
                SectionSelector();
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
                {
                    if (currentPanel != null)
                    {
                        EditorGUILayout.LabelField(currentPanel.Description);
                        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
                        currentPanel.OnGUI();
                        if (currentPanel.dirty)
                        {
                            EditorHelper.SaveAppConfig(appConfig);
                            EditorHelper.SavePlatformConfig(platformConfig);
                            currentPanel.dirty = false;
                            DelayRefreshAssets();
                        }
                    }
                }
            }
        }

        async void DelayRefreshAssets()
        {
            await Task.Yield();
            AssetDatabase.Refresh();
        }

        void InitializePanels()
        {
            var arr = new SettingPanel[]
            {
                new AppConfigPanel(),
                new PlatformConfigPanel(),
                new BuildPanel()
            };
            panels = arr.ToDictionary(i => i.Name, i => i);
            panels.ToList().ForEach(i => i.Value.manager = this);
        }

        void LoadConfigs()
        {
            appConfig = EditorHelper.LoadAppConfig();
            platformConfig = EditorHelper.LoadPlatformConfig();
        }

        bool IsConfigValid()
        {
            return appConfig != null && platformConfig != null;
        }

        void SectionSelector()
        {
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox, GUILayout.Width(160), GUILayout.ExpandHeight(true)))
            {
                foreach (var item in panels.Values)
                {
                    //if (item.GetType() == typeof(SpacePanel))
                    //{
                    //    item.OnGUI();
                    //    continue;
                    //}
                    Color old = GUI.backgroundColor;
                    GUI.backgroundColor = item == currentPanel ? Color.green : old;
                    if (GUILayout.Button(item.DisplayName, GUILayout.Height(32)))
                    {
                        GUIUtility.keyboardControl = 0;
                        if (currentPanel != item)
                        {
                            currentPanel.OnHide();
                        }
                        currentPanel = item;
                        currentPanel.OnShow();
                    }
                    GUI.backgroundColor = old;

                }
            }
        }

        void DrawConfigSelector()
        {
            EditorGUILayout.BeginHorizontal();
            var newIndex = EditorGUILayout.Popup(currentIndexOfConfig, allConfigs);
            if (newIndex != currentIndexOfConfig)
            {
                ApplyConfig(newIndex);
            }
            if (GUILayout.Button("+", EditorStyles.miniButton, GUILayout.Width(32)))
            {
                showCreatePanel = !showCreatePanel;
            }
            EditorGUILayout.EndHorizontal();
        }

        private void ApplyConfig(int newIndex)
        {
            string[] names = GetPlatformAndConfigName(currentIndexOfConfig);
            string platformTemplateDir;
            string configTemplateDir;
            string commonTemplateDir = Path.Combine(dirSettings, dirCommon);

            string[] newNames = GetPlatformAndConfigName(newIndex);
            bool platformChanged = names == null || names[0] != newNames[0];

            if (names != null)
            {
                // Remove Plugins dir
                EditorHelper.DirClear("Assets/Plugins");

                platformTemplateDir = Path.Combine(dirSettings, dirPlatform, names[0]);
                configTemplateDir = Path.Combine(dirSettings, dirConfig, names[1]);
                EditorHelper.ClearTemplateFiles(platformTemplateDir);
                EditorHelper.ClearTemplateFiles(configTemplateDir);
                if (platformChanged)
                {
                    RemoveDeps();
                }
            }

            currentIndexOfConfig = newIndex;
            names = GetPlatformAndConfigName(currentIndexOfConfig);
            platformTemplateDir = Path.Combine(dirSettings, dirPlatform, names[0]);
            configTemplateDir = Path.Combine(dirSettings, dirConfig, names[1]);

            EditorHelper.DirCopy(commonTemplateDir, ".");
            EditorHelper.DirCopy(platformTemplateDir, ".");
            EditorHelper.DirCopy(configTemplateDir, ".");

            LoadConfigs();
            if (platformChanged)
            {
                AddDeps();
            }

            if (appConfig.name != names[1])
            {
                appConfig.name = names[1];
                EditorHelper.SaveAppConfig(appConfig);
            }

            if (platformConfig.name != names[0])
            {
                platformConfig.name = names[0];
                EditorHelper.SavePlatformConfig(platformConfig);
            }

            if (platformChanged)
            {
                EditorApplication.OpenProject(".");
            }
            else
            {
                AssetDatabase.Refresh();
            }
        }

        string[] GetPlatformAndConfigName(int index)
        {
            if (index < 0)
            {
                return null;
            }

            var configname = allConfigs[index];
            var parts = configname.Split('/');
            var platformname = parts[0].Trim();
            configname = parts[1].Trim();
            return new string[] { platformname, configname };
        }

        void RemoveDeps()
        {
            if (platformConfig.dependencies != null && platformConfig.dependencies.Length > 0)
            {
                var all = string.Join(' ', platformConfig.dependencies);
                EditorHelper.Shell("openupm", $"remove {all}");
            }
        }

        void AddDeps()
        {
            if (platformConfig.dependencies != null && platformConfig.dependencies.Length > 0)
            {
                var all = string.Join(' ', platformConfig.dependencies);
                EditorHelper.Shell("openupm", $"add {all}");
            }
        }

    }
}
