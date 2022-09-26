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
            var config = GameSettingsManager.current.platformConfig;

            config.dependencies = config.dependencies ?? new string[0];
            using (new GUILayout.VerticalScope())
            {
                EditorGUILayout.LabelField("AppId", Application.identifier);
                using (new GUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("Dependencies");
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("+", EditorStyles.miniButton))
                    {
                        config.dependencies = config.dependencies.Append("").ToArray();
                    }
                    //GUILayout.FlexibleSpace();
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
