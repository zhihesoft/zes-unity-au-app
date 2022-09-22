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
        // Bundle data dir
        public string bundleDataPath = "Assets/Bundles";
        // bundle output path
        public string bundleOutputPath = "AssetBundles";
        // javascript project path
        public string javascriptProjectPath = "Typescripts";
        // javascript entry for debug
        public string javascriptEntryEditor = "Typescripts/dist/index.js";
        // javascript build result
        public string javascriptBuildResult = "Typescripts/out/main.bytes";

    }
}
