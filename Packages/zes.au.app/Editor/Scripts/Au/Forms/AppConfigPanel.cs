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
            RenderFoldout("Application", () =>
            {
                manager.appConfig.appName = TextField("App name", manager.appConfig.appName);
                manager.appConfig.appId = TextField("App Id", manager.appConfig.appId);
                EditorGUILayout.LabelField("App display name", Application.productName);
                EditorGUILayout.LabelField("App version", Application.version + "." + BuildNo.Get());
            });

            EditorGUILayout.Space();

            RenderFoldout("Common Settings", () =>
            {
                manager.appConfig.loginServer = TextField("Login server", manager.appConfig.loginServer);
                manager.appConfig.checkUpdate = BoolField("Check update", manager.appConfig.checkUpdate);
                manager.appConfig.allowGuest = BoolField("Allow guest", manager.appConfig.allowGuest);
                manager.appConfig.appLanguage = TextField("App language", manager.appConfig.appLanguage);
            });

            EditorGUILayout.Space();

            RenderFoldout("Patch Settings", () =>
            {
                manager.appConfig.patchServer = TextField("Patch server", manager.appConfig.patchServer);
                manager.appConfig.minVersion = TextField("Minimun version", manager.appConfig.minVersion);
            });

            EditorGUILayout.Space();

            RenderFoldout("Bundle Settings", () =>
            {
                manager.appConfig.bundleConfig = TextField("Config bundle", manager.appConfig.bundleConfig);
                manager.appConfig.bundleLanguage = TextField("Language bundle", manager.appConfig.bundleLanguage);
                manager.appConfig.bundleJS = TextField("Javascript bundle", manager.appConfig.bundleJS);
            });
        }
    }
}
