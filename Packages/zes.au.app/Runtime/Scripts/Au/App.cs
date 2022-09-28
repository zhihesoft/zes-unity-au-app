using Au.Loaders;
using Au.TS;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Au
{
    /// <summary>
    ///  App Host
    /// </summary>
    [JSWrap]
    public class App : MonoBehaviour
    {
        public static bool inEditor
        {
            get
            {
#if UNITY_EDITOR
                return true;
#else
                return false;
#endif
            }
        }

        public static string platform
        {
            get
            {
#if UNITY_ANDROID
                return "android";
#elif UNITY_IOS
                return "ios";
#else
                return Application.platform.ToString();
#endif
            }
        }

        public static Loader loader => _instance._loader;
        public static AppConfig config => _instance._config;
        public static Func<int, string> i18n { get; private set; }

        public static async Task<bool> RestartJS()
        {
            Assert.IsNotNull(_instance._tsApp);
            return await _instance._tsApp.Restart();
        }

        private static App _instance;
        private AppInit _init;
        private Loader _loader;
        private TSApp _tsApp;
        private AppConfig _config;

        private void Start()
        {
            Assert.IsNull(_instance);
            DontDestroyOnLoad(gameObject);
            _instance = this;

            var ta = Resources.Load<TextAsset>("app");
            _config = JsonUtility.FromJson<AppConfig>(ta.text);

            OnStart();
        }

        private void OnStart()
        {
            _init = gameObject.GetComponent<AppInit>();
            Assert.IsNotNull(_init, "AppInit is not found");
            _loader = _init.CreateLoader();
            RunJS();
        }

        private void Update()
        {
            _tsApp?.Tick();
        }

        private async void RunJS()
        {
            string scriptLocation = "";
            if (_init.javascriptDebugMode)
            {
                var projectConfig = JsonUtility.FromJson<ProjectConfig>(File.ReadAllText("project.json"));
                scriptLocation = $"file://{projectConfig.javascriptDebugEntry}";
            }
            else
            {
                scriptLocation = $"bundle://{config.bundleJS}/Assets/{config.bundleDataPath}/{config.bundleJS}/{config.jsEntry}";
            }

            var startupInfo = new StartupInfo
            {
                initActions = _init.InitJsEnv,
                scriptLocation = scriptLocation,
            };
            _tsApp = new TSApp(_loader, startupInfo);
            await _tsApp.Run();
            i18n = _tsApp.GetFunc<Func<int, string>>("i18n");
        }
    }
}
