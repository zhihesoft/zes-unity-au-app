using System;

namespace Au
{
    [Serializable]
    public class ProjectConfig
    {
        // language id start from
        public int languageStartId = 18000;
        // language config name
        public string languageConfigName = "language";
        // bundle output path
        public string bundleOutputPath = "AssetBundles";
        // javascript project path
        public string javascriptProjectPath = "Typescripts";
        // javascript debug
        public string javascriptDebugEntry = "./Typescripts/dist/index.js";
        // javascript release
        public string javascriptReleaseEntry = "./Typescript/out/main.bytes";

    }
}
