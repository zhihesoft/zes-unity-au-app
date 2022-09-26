using Au.Loaders;
using Puerts;
using System;
using System.Collections.Generic;
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
        const string localScriptPrefix = "file://";
        const string bundleScriptPrefix = "bundle://";

        /// <summary>
        /// Create a new TSApp instance
        /// </summary>
        /// <param name="loader">Resource loader</param>
        /// <param name="scriptLocation">
        /// Local file file://path/to/file
        /// Bundle file bundle://bundlename/path/to/asset
        /// </param>
        public TSApp(Loader loader, string scriptLocation) : this(loader, new StartupInfo { scriptLocation = scriptLocation }) { }

        public TSApp(Loader loader, StartupInfo startupInfo)
        {
            Assert.IsNotNull(startupInfo);
            this.startupInfo = startupInfo;
            res = loader;
        }

        private readonly StartupInfo startupInfo;
        private readonly Loader res;
        private JSLoader jsLoader;
        private Log log = Log.GetLogger<TSApp>();

        public JsEnv env { get; private set; }

        public async Task<bool> Run()
        {
            Assert.IsNull(env);
            if (startupInfo.scriptLocation.StartsWith(localScriptPrefix))
            {
                var scriptpath = startupInfo.scriptLocation.Substring(localScriptPrefix.Length);
                log.Info($"load from file system: {scriptpath}");
                jsLoader = new JSLoader(scriptpath);
            }
            else
            {
                var scriptpath = startupInfo.scriptLocation.Substring(bundleScriptPrefix.Length);
                log.Info($"load from bundle system: {scriptpath}");
                List<string> parts = new List<string>(scriptpath.Split("/"));
                string bundle = parts[0];
                parts = parts.GetRange(1, parts.Count - 1);
                string asset = string.Join("/", parts);
                await res.LoadBundle(bundle, null);
                var obj = await res.LoadAsset(asset, typeof(TextAsset));
                string script = (obj as TextAsset).text;
                jsLoader = new JSLoader(script);
                res.UnloadBundle(bundle);
            }
            env = new JsEnv(jsLoader, startupInfo.debugPort);
            //await env.WaitDebuggerAsync();
            CommonInit(env);
            startupInfo.initActions?.Invoke(env);
            env.Eval($"require('{jsLoader.rootFile}');");
            return true;
        }

        public void Dispose()
        {
            env?.Dispose();
            env = null;
        }

        public T GetFunc<T>(string func)
        {
            return env.Eval<T>($"require('{jsLoader.rootFile}').{func};");
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
