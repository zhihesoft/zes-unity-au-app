using Puerts;
using System.IO;

namespace Au.TS
{
    internal class JSLoader : ILoader
    {
        /// <summary>
        /// Create a JSLoader
        /// </summary>
        /// <param name="chunk">root script chunk or file</param>
        public JSLoader(string chunk)
        {
            this.chunk = chunk;
            bundleMode = !File.Exists(chunk);
            rootFile = bundleMode ? "./main.bytes" : chunk;
            log.Info($"JSLoader.bundleMode: {bundleMode}");
        }

        private Log log = Log.GetLogger<JSLoader>();

        private readonly bool bundleMode;

        private readonly string chunk;

        private const string puerPrefix = "puer";

        private ILoader puerLoader = new DefaultLoader();

        public readonly string rootFile;

        public bool FileExists(string filepath)
        {
            if (filepath.StartsWith(puerPrefix))
            {
                return puerLoader.FileExists(filepath);
            }
            if (bundleMode) // always return true in bundle mode
            {
                return true;
            }
            return File.Exists(filepath);
        }

        public string ReadFile(string filepath, out string debugpath)
        {
            if (filepath.StartsWith(puerPrefix))
            {
                return puerLoader.ReadFile(filepath, out debugpath);
            }
            if (bundleMode) // always return chunk in bundle mode
            {
                debugpath = filepath;
                return chunk;
            }
            debugpath = new FileInfo(filepath).FullName;
            return File.ReadAllText(filepath);
        }
    }
}
