using Au.Loaders;
using Au.TS;
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
        public static Loader loader => _instance._loader;
        public static AppConfig config => _instance._config;
#if UNITY_EDITOR
        public static bool jsDebugMode = true;
#else
        public static bool jsDebugMode = false;
#endif

        public static void RestartJS()
        {
            Assert.IsNotNull(_instance._tsApp);
            _instance._tsApp.Dispose();
            _instance._tsApp = null;
            _instance.RunJavascript();
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
            RunJavascript();
        }

        private void Update()
        {
            _tsApp?.Tick();
        }

        private async void RunJavascript()
        {
            var startupInfo = new StartupInfo
            {
                initActions = _init.InitJS,
                scriptLocation = jsDebugMode
                    ? _init.javascriptDebugPath
                    : _init.javascriptAssetPath,
            };

            _tsApp = new TSApp(_loader, startupInfo);
            await _tsApp.Run();
        }

    }
}
