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
        public string bundleDataPath = "Bundles";
        // bundle output path
        public string bundleOutputPath = "AssetBundles";
        // javascript project path
        public string javascriptProjectPath = "Typescripts";
        // javascript build result
        public string javascriptBuildResult = "Typescripts/out/main.bytes";

    }
}
