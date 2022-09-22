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
            Foldout("i18n", () =>
            {
                config.languageStartId = IntField("Language start id", config.languageStartId);
                config.languageConfigName = TextField("Language config name", config.languageConfigName);
            });

            Foldout("Javascript", () =>
            {
                config.javascriptProjectPath = TextField("JS project", config.javascriptProjectPath);
                config.javascriptEntryEditor = TextField("JS editor entry", config.javascriptEntryEditor);
                config.javascriptBuildResult = TextField("JS build result", config.javascriptBuildResult);
            });

        }
    }
}
