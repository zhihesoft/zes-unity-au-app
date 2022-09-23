using Au.Internal;
using Au.Loaders;
using Au.TS;
using System.IO;
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

        public static void RestartJavascriptApp()
        {
            Assert.IsNotNull(_instance._tsApp);
            _instance._tsApp.Dispose();
            _instance._tsApp = null;
            _instance.RunJavascript();
        }

        private static App _instance;

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
            string scriptChunk = "";

            if (_init.javascriptDebugMode)
            {
                var json = await File.ReadAllTextAsync("project.json");
                var config = JsonUtility.FromJson<ProjectConfig>(json);
                scriptChunk = config.javascriptEntryEditor;
            }
            else
            {
                await _loader.LoadBundle(_config.bundleJS, null);
                var js = (await _loader.LoadAsset(_init.javascriptAssetPath, typeof(TextAsset))) as TextAsset;
                scriptChunk = js.text;
                _loader.UnloadBundle(_config.bundleJS);
            }
             
            _tsApp = new TSApp(new StartupInfo
            {
                onInit = _init.InitJS,
                scriptChunk = scriptChunk
            });
            _tsApp.Run();
        }

        private AppInit _init;
        private Loader _loader;
        private TSApp _tsApp;
        private AppConfig _config;
    }
}
