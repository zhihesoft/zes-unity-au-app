using System;
using System.Collections.Generic;

namespace Au.Patcher
{
    [Serializable]
    public class PatchInfo
    {
        public string app;
        public string version;
        public Dictionary<string, PatchFileInfo> files;
    }
}
