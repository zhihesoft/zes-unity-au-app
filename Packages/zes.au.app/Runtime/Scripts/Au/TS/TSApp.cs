using Puerts;
using System;
using UnityEngine.Assertions;

namespace Au.TS
{
    /// <summary>
    /// A TS App
    /// </summary>
    public class TSApp : IDisposable
    {
        public TSApp(string scriptChunk) : this(new StartupInfo { scriptChunk = scriptChunk }) { }

        public TSApp(StartupInfo startupInfo)
        {
            Assert.IsNotNull(startupInfo);
            this.startupInfo = startupInfo;
            loader = new JSLoader(startupInfo.scriptChunk);
        }

        private readonly StartupInfo startupInfo;

        private readonly JSLoader loader;

        public JsEnv env { get; private set; }

        public void Run()
        {
            Assert.IsNull(env);
            env = new JsEnv(loader, startupInfo.debugPort);
            CommonInit(env);
            startupInfo.onInit?.Invoke(env);
            env.Eval($"require('{loader.rootFile}');");
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
