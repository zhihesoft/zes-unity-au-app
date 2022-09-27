namespace Au.Forms
{
    public class ProjectConfigPanel : SettingPanel
    {
        public override string Name => "Project";

        public override string DisplayName => "Project";

        public override string Description => "Project settings";

        public override void OnGUI()
        {
            var config = GameSettingsManager.current.projectConfig;

            Foldout("Bundles", () =>
            {
                config.bundleOutputPath = TextField("Bundle out dir", config.bundleOutputPath);
            });

            Foldout("i18n", () =>
            {
                config.languageStartId = IntField("Language start id", config.languageStartId);
                config.languageConfigName = TextField("Language config name", config.languageConfigName);
            });

            Foldout("Javascript", () =>
            {
                config.javascriptProjectPath = TextField("JS project", config.javascriptProjectPath);
                config.javascriptDebugEntry = TextField("JS debug entry", config.javascriptDebugEntry);
                config.javascriptReleaseEntry = TextField("JS release entry", config.javascriptReleaseEntry);
            });

        }
    }
}
