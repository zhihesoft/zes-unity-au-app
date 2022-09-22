using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Au
{
    public static class GameSettingsManager
    {
        public const string dirSettings = "GameSettings";
        public const string dirCommon = ".general";
        public const string dirPlatform = "platforms";
        public const string dirTemplates = "templates";
        public const string fileAppConfig = "app.json";
        public const string fileProjectConfig = "project.json";
        public const string fileLocalConfig = ".localconfig";
        public const string filePlatformConfig = "platform.json";
        public const string fullpathAppConfig = "Assets/Resources/" + fileAppConfig;
        public const string defaultConfigName = "dev";


        public static GameSettings current;

        public static GameSettings Load(bool force = false)
        {
            if (!force && current != null)
            {
                return current;
            }

            current = new GameSettings();
            current.Load();
            return current;
        }

        public static List<string> GetSettingPaths()
        {
            return new DirectoryInfo(dirSettings).GetDirectories()
                .Where(dir => dir.Name != dirCommon)
                .SelectMany(dir =>
                        dir.GetDirectories()
                        .Where(sd => sd.Name != dirTemplates)
                        .Select(sd => $"{dir.Name}/{sd.Name}"))
                .ToList();
        }

        public static GameSettings ChangeSetting(string path)
        {
            string[] parts = path.Split("/");
            string platformName = parts[0];
            string configName = parts[1];

            RevertSetting();
            CopySettings(platformName, configName);

            GameSettings ret = Load(true);
            ret.appConfig.name = configName;
            ret.platformConfig.name = platformName;
            ret.Save();
            return ret;
        }

        public static void ApplySettings()
        {
            if (current == null)
            {
                return;
            }

            string platformName = current.platformConfig.name;
            string configName = current.appConfig.name;

            // copy platform.json
            File.Copy(filePlatformConfig, Path.Combine(dirSettings, platformName, filePlatformConfig), true);

            // copy app.json
            File.Copy(fullpathAppConfig, Path.Combine(dirSettings, platformName, configName, fullpathAppConfig), true);
        }

        private static void RevertSetting()
        {
            if (current == null)
            {
                return;
            }

            string platformName = current.platformConfig.name;
            string configName = current.appConfig.name;

            // revert config
            RevertDir(new DirectoryInfo(Path.Combine(dirSettings, platformName, configName)), new DirectoryInfo("."));
            // revert platform
            RevertDir(new DirectoryInfo(Path.Combine(dirSettings, platformName, dirTemplates)), new DirectoryInfo("."));
        }

        private static void CopySettings(string platformName, string configName)
        {
            // first copy general
            CopyDir(new DirectoryInfo(Path.Combine(dirSettings, dirCommon)), new DirectoryInfo("."));

            // second copy platform settings
            CopyDir(new DirectoryInfo(Path.Combine(dirSettings, platformName, dirTemplates)), new DirectoryInfo("."));

            // last copy app config settings
            CopyDir(new DirectoryInfo(Path.Combine(dirSettings, platformName, configName)), new DirectoryInfo("."));
        }

        private static void CopyDir(DirectoryInfo templateDir, DirectoryInfo workDir)
        {
            if (!workDir.Exists)
            {
                workDir.Create();
            }

            templateDir.GetDirectories()
                .ToList()
                .ForEach(dir => CopyDir(dir, new DirectoryInfo(Path.Combine(workDir.FullName, dir.Name))));

            templateDir.GetFiles()
                .ToList()
                .ForEach(file => file.CopyTo(Path.Combine(workDir.FullName, file.Name), true));
        }

        private static DirectoryInfo RevertDir(DirectoryInfo templateDir, DirectoryInfo workDir)
        {
            if (!templateDir.Exists || !workDir.Exists)
            {
                return workDir;
            }

            workDir.GetDirectories()
                .Where(dir => Directory.Exists(Path.Combine(templateDir.FullName, dir.Name)))
                .Select(dir => RevertDir(new DirectoryInfo(Path.Combine(templateDir.FullName, dir.Name)), dir))
                .Where(dir => !(dir.GetDirectories().Any() || dir.GetFiles().Any()))
                .ToList()
                .ForEach(dir => dir.Delete(true));

            workDir.GetFiles()
                .Where(file => File.Exists(Path.Combine(templateDir.FullName, file.Name)))
                .ToList()
                .ForEach(file => file.Delete());

            return workDir;
        }
    }
}
