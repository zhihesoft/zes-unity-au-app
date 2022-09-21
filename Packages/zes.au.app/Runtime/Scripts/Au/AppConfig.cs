﻿using System;

namespace Au
{
    [Serializable]
    public class AppConfig
    {
        // Config name
        public string name = "";
        // App short name
        public string appName = "game";
        // App id
        public string appId = "com.lj.game";
        // App language
        public string appLanguage = "zh-cn";
        // Game login server
        public string loginServer = "";
        // Allow guest login
        public bool allowGuest = false;
        // Patch server 
        public string patchServer = "";
        // Mininmun version
        public string minVersion = "";
        // if check update
        public bool checkUpdate = true;

        // javascript entry for runtime
        public string bundleJS = "js";
        // Config bundle name
        public string bundleConfig = "conf";
        // Language bundle name
        public string bundleLanguage = "language";
    }
}