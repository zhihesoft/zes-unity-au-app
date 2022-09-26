using Puerts;
using System;

namespace Au.TS
{
    public class StartupInfo
    {
        public string scriptChunk;
        public Action<JsEnv> onInit;
        public int debugPort = 9229;
    }
}
