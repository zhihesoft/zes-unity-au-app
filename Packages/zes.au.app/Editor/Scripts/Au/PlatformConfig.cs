namespace Au
{
    [System.Serializable]
    public class PlatformConfig
    {
        // 配置名称
        public string name;
        // dependences (will install by openupm)
        public string[] dependencies;
    }
}
