using Puerts;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Au.TS
{
    /// <summary>
    /// A TS App
    /// </summary>
    public class TSApp : IDisposable
    {
        const string localScriptPrefix = "local://";
        const string bundleScriptPrefix = "bundle://";

        /// <summary>
        /// Create a new TSApp instance
        /// </summary>
        /// <param name="scriptLocation">
        /// Local file local://path/to/index.js
        /// Bundle file bundle://bundlename/path/to/asset
        /// </param>
        public TSApp(string scriptLocation) : this(new StartupInfo { scriptLocation = scriptLocation }) { }

        public TSApp(StartupInfo startupInfo)
        {
            Assert.IsNotNull(startupInfo);
            this.startupInfo = startupInfo;
            loader = new JSLoader(startupInfo.scriptLocation);
        }

        private readonly StartupInfo startupInfo;

        private readonly JSLoader loader;

        public JsEnv env { get; private set; }

        public async Task<bool> Run()
        {
            Assert.IsNull(env);
            string scriptpath = "";
            if (startupInfo.scriptLocation.StartsWith(localScriptPrefix))
            {
                scriptpath = startupInfo.scriptLocation.Substring(localScriptPrefix.Length);
            }
            else
            {
                scriptpath = startupInfo.scriptLocation.Substring(bundleScriptPrefix.Length);
            }

            env = new JsEnv(loader, startupInfo.debugPort);
            CommonInit(env);
            startupInfo.initActions?.Invoke(env);
            env.Eval($"require('{loader.rootFile}');");
            return true;
        }

        public void Dispose()
        {
            env?.Dispose();
            env = null;
        }

        public T GetFunc<T>(string func)
        {
            return env.Eval<T>($"require('{loader.rootFile}').{func};");
        }

        public void Tick()
        {
            env?.Tick();
        }

        private void CommonInit(JsEnv env)
        {
            env.UsingAction<bool>();
            env.UsingAction<float>();
            env.UsingAction<string>();
            env.UsingAction<string, string>();

            env.UsingFunc<string, string>();
            env.UsingFunc<int, string>();           // for i18n
        }
    }
}
