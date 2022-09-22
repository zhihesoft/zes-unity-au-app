using System.IO;
using UnityEngine;

namespace Au
{
    public class GameSettings
    {
        public AppConfig appConfig;
        public PlatformConfig platformConfig;
        public ProjectConfig projectConfig;
        public LocalConfig localConfig;

        public void Load()
        {
            platformConfig = File.Exists(GameSettingsManager.filePlatformConfig)
                ? JsonUtility.FromJson<PlatformConfig>(File.ReadAllText(GameSettingsManager.filePlatformConfig))
                : new PlatformConfig();
            appConfig = File.Exists(GameSettingsManager.fullpathAppConfig)
                ? JsonUtility.FromJson<AppConfig>(File.ReadAllText(GameSettingsManager.fullpathAppConfig))
                : new AppConfig();
            projectConfig = File.Exists(GameSettingsManager.fileProjectConfig)
                ? JsonUtility.FromJson<ProjectConfig>(File.ReadAllText(GameSettingsManager.fileProjectConfig))
                : new ProjectConfig();
            localConfig = File.Exists(GameSettingsManager.fileLocalConfig)
                ? JsonUtility.FromJson<LocalConfig>(File.ReadAllText(GameSettingsManager.fileLocalConfig))
                : new LocalConfig();
        }

        public void Save()
        {
            Save(platformConfig, GameSettingsManager.filePlatformConfig);
            Save(appConfig, GameSettingsManager.fullpathAppConfig);
            Save(projectConfig, GameSettingsManager.fileProjectConfig);
            Save(localConfig, GameSettingsManager.fileLocalConfig);
        }

        public void Save<T>(T config, string path)
        {
            File.WriteAllText(path, JsonUtility.ToJson(config, true), Utils.utf8WithoutBOM);
        }

        public LocalConfigItem GetLocalConfig()
        {
            var all = GameSettingsManager.current.localConfig;
            string path = GameSettingsManager.current.platformConfig.name + "/" + GameSettingsManager.current.appConfig.name;
            var item = all.items.Find(i => i.name == path);
            if (item == null)
            {
                item = new LocalConfigItem();
                item.name = path;
                all.items.Add(item);
            }
            Save(localConfig, GameSettingsManager.fileLocalConfig);
            return item;
        }
    }
}
