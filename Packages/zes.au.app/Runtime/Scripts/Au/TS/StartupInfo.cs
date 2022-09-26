using Puerts;
using System;

namespace Au.TS
{
    public class StartupInfo
    {
        /// <summary>
        /// Script location
        /// Local file: file://path/to/file
        /// Bundle file: bundle://bundlename/path/to/asset
        /// </summary>
        public string scriptLocation;
        public Action<JsEnv> initActions;
        public int debugPort = 9229;
    }
}
