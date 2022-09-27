using UnityEditor;
using UnityEngine;

namespace Au.Forms
{
    public class AppConfigPanel : SettingPanel
    {
        public override string Name => "Game";

        public override string DisplayName => "Game";

        public override string Description => "Game settings";

        public override void OnGUI()
        {
            var appConfig = GameSettingsManager.current.appConfig;

            Foldout("Application", () =>
            {
                appConfig.appName = TextField("App name", appConfig.appName);
                EditorGUILayout.LabelField("App id", Application.identifier);
                EditorGUILayout.LabelField("App display name", Application.productName);
                EditorGUILayout.LabelField("App version", Application.version + "." + BuildNo.Get());
            });


            Foldout("Common Settings", () =>
            {
                appConfig.loginServer = TextField("Login server", appConfig.loginServer);
                appConfig.checkUpdate = BoolField("Check update", appConfig.checkUpdate);
                appConfig.allowGuest = BoolField("Allow guest", appConfig.allowGuest);
                appConfig.appLanguage = TextField("App language", appConfig.appLanguage);
            });


            Foldout("Patch Settings", () =>
            {
                appConfig.patchServer = TextField("Patch server", appConfig.patchServer);
                appConfig.minVersion = TextField("Minimun version", appConfig.minVersion);
            });


            Foldout("Bundle Settings", () =>
            {
                appConfig.bundleDataPath = TextField("Bundles", appConfig.bundleDataPath);
                appConfig.bundleConfig = TextField("Config bundle", appConfig.bundleConfig);
                appConfig.bundleLanguage = TextField("Language bundle", appConfig.bundleLanguage);
                appConfig.bundleJS = TextField("Javascript bundle", appConfig.bundleJS);
                appConfig.jsEntry = TextField("Javascript entry", appConfig.jsEntry);
            });
        }
    }
}
