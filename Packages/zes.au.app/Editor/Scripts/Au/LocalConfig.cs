using System;
using System.Collections.Generic;

namespace Au
{
    [Serializable]
    public class LocalConfig
    {
        public List<LocalConfigItem> items = new List<LocalConfigItem>();
    }

    [Serializable]
    public class LocalConfigItem
    {
        // Item name
        public string name;
        // Excel 配置目录
        public string excelsDirectory;
        // App output directory
        public string outputDirectory = "out";
        // Android Keystore file
        public string androidKeyStoreFile;
        // Android 证书密码
        public string androidKeystorePassword;
        // Android 签名密码
        public string androidKeyAliasPassword;
    }
}
