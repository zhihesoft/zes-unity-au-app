using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Au.Forms
{
    public class PlatformConfigPanel : SettingPanel
    {
        public override string Name => "Platform";

        public override string DisplayName => "Platform";

        public override string Description => "Platform settings";

        public override void OnGUI()
        {
            var config = manager.platformConfig;

            EditorGUILayout.LabelField("secret");
            using (new GUIIndent())
            {
                config.androidKeystorePassword = TextField("Android keystore pwd", config.androidKeystorePassword);
                config.androidKeyAliasPassword = TextField("Android keyalias pwd", config.androidKeyAliasPassword);
            }

            EditorGUILayout.LabelField("i18n");
            using (new GUIIndent())
            {
                config.languageStartId = IntField("Language start id", config.languageStartId);
                config.languageConfigName = TextField("Language config name", config.languageConfigName);
            }

            EditorGUILayout.LabelField("Javascript");
            using (new GUIIndent())
            {
                config.javascriptProjectPath = TextField("JS project", config.javascriptProjectPath);
                config.javascriptEntryEditor = TextField("JS editor entry", config.javascriptEntryEditor);
                config.javascriptBuildResult = TextField("JS build result", config.javascriptBuildResult);
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            config.dependencies = config.dependencies ?? new string[0];
            using (new GUILayout.VerticalScope())
            {
                using (new GUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("Dependencies");
                    if (GUILayout.Button("+", EditorStyles.miniButton))
                    {
                        config.dependencies = config.dependencies.Append("").ToArray();
                    }
                    GUILayout.FlexibleSpace();
                }
                using (new GUIIndent())
                {
                    var deps = config.dependencies.ToList();

                    for (int i = 0; i < deps.Count; i++)
                    {
                        using (new GUILayout.HorizontalScope())
                        {
                            string newstr = EditorGUILayout.TextField(config.dependencies[i]);
                            if (newstr != config.dependencies[i])
                            {
                                dirty = true;
                                config.dependencies[i] = newstr;
                            }
                            if (GUILayout.Button("-", GUILayout.Width(32)))
                            {
                                dirty = true;
                                config.dependencies = config.dependencies.Where((d, idx) => idx != i).ToArray();
                            }
                        }
                    }
                }
            }
        }
    }
}
