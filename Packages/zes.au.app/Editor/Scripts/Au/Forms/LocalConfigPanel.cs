using UnityEditor;
using UnityEngine;

namespace Au.Forms
{
    public class LocalConfigPanel : SettingPanel
    {
        public override string Name => "Local";

        public override string DisplayName => "Local";

        public override string Description => "Local configs";

        public override void OnGUI()
        {
            var config = GameSettingsManager.current.GetLocalConfig();

            Foldout("Excels", () =>
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    string old = config.excelsDirectory;
                    config.excelsDirectory = EditorGUILayout.TextField("Excels dir", config.excelsDirectory);
                    if (GUILayout.Button("...", EditorStyles.miniButtonRight, GUILayout.Width(32)))
                    {
                        config.excelsDirectory = EditorUtility.OpenFolderPanel("Excels Folder", config.excelsDirectory, "");
                    }
                    if (old != config.excelsDirectory)
                    {
                        dirty = true;
                    }
                }
            });

            Foldout("Android secret", () =>
            {
                config.androidKeyStoreFile = TextField("Android keystore", config.androidKeyStoreFile);
                config.androidKeystorePassword = TextField("Android keystore pwd", config.androidKeystorePassword);
                config.androidKeyAliasPassword = TextField("Android keyalias pwd", config.androidKeyAliasPassword);
            });
        }
    }
}
