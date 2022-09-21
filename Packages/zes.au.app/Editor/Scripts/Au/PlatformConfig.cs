﻿namespace Au
{
    [System.Serializable]
    public class PlatformConfig
    {
        // 配置名称
        public string name;

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
        public string javascriptEntryEditor = "dist/index.js";
        // javascript build result
        public string javascriptBuildResult = "out/main.bytes";

        // Android 证书密码
        public string androidKeystorePassword;
        // Android 签名密码
        public string androidKeyAliasPassword;

        // dependences (will install by openupm)
        public string[] dependencies;
    }
}
