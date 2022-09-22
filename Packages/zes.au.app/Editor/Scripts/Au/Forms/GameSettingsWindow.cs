using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Au.Forms
{
    public class GameSettingsWindow : EditorWindow
    {

        [MenuItem("Au/Settings", priority = 1)]
        public static void ShowGameSettingsWindow()
        {
            var window = GetWindow<GameSettingsWindow>("Game Settings");
            window.Show();
            window.minSize = new Vector2(800, 600);
            window.Initialize();
        }

        bool refreshing;
        int currentIndexOfConfig = -1;
        string[] allConfigPaths = null;
        SettingPanel[] panels;
        SettingPanel currentPanel;

        void Initialize()
        {
            panels = new SettingPanel[]
            {
                new AppConfigPanel(),
                new PlatformConfigPanel(),
                new ProjectConfigPanel(),
                new LocalConfigPanel(),
                new BuildPanel()
            };
            currentPanel = panels.First();
            allConfigPaths = GameSettingsManager.GetSettingPaths().ToArray();
            GameSettingsManager.Load(true);
            if (GameSettingsManager.current != null)
            {
                GameSettings settings = GameSettingsManager.current;
                string currentConfigPath = $"{settings.platformConfig.name}/{settings.appConfig.name}";
                currentIndexOfConfig = allConfigPaths.ToList().FindIndex(i => i == currentConfigPath);
            }
        }

        void OnGUI()
        {
            if (GameSettingsManager.current == null)
            {
                Initialize();
            }

            if (!Validate(!EditorApplication.isCompiling, "Project is compiling !!"))
            {
                return;
            }

            DrawConfigSelector();

            if (!Validate(GameSettingsManager.current != null, "Invalid config"))
            {
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
                            GameSettingsManager.current.Save();
                            DelayRefreshAssets();
                        }
                    }
                }
            }
        }

        async void DelayRefreshAssets()
        {
            if (refreshing)
            {
                return;
            }

            refreshing = true;
            await Task.Delay(1000);
            GameSettingsManager.current.Save();
            AssetDatabase.Refresh();
            refreshing = false;
        }

        bool Validate(bool condition, string message)
        {
            if (!condition)
            {
                EditorGUILayout.LabelField(
                    message,
                    EditorStyles.centeredGreyMiniLabel,
                    GUILayout.ExpandWidth(true),
                    GUILayout.ExpandHeight(true));
                return false;
            }
            return true;
        }

        void DrawConfigSelector()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                var newIndex = EditorGUILayout.Popup(currentIndexOfConfig, allConfigPaths);
                if (newIndex != currentIndexOfConfig)
                {
                    GameSettingsManager.ChangeSetting(allConfigPaths[newIndex]);
                    currentIndexOfConfig = newIndex;
                }

                if (GUILayout.Button("Apply", EditorStyles.miniButton, GUILayout.Width(64)))
                {
                    GameSettingsManager.ApplySettings();
                }
            }
        }

        void SectionSelector()
        {
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox, GUILayout.Width(160), GUILayout.ExpandHeight(true)))
            {
                foreach (var item in panels)
                {
                    Color old = GUI.backgroundColor;
                    GUI.backgroundColor = item == currentPanel ? Color.green : old;
                    if (GUILayout.Button(item.DisplayName, GUILayout.Height(32)))
                    {
                        GUIUtility.keyboardControl = 0;
                        if (currentPanel != item)
                        {
                            currentPanel?.OnHide();
                        }
                        currentPanel = item;
                        currentPanel.OnShow();
                    }
                    GUI.backgroundColor = old;

                }
            }
        }

    }
}

