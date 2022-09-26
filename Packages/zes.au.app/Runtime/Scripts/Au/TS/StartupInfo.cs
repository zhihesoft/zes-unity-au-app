using Puerts;
using System;

namespace Au.TS
{
    public class StartupInfo
    {
        /// <summary>
        /// Script location
        /// Local file: local://path/to/index.js
        /// Bundle file: bundle://bundlename/path/to/asset
        /// </summary>
        public string scriptLocation;
        public Action<JsEnv> initActions;
        public int debugPort = 9229;
    }
}
