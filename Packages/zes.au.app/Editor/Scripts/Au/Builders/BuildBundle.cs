namespace Au.Builders
{
    internal class BuildBundle : BuildTask
    {
        public override string name => "Bundle";

        protected override void AfterBuild()
        {
        }

        protected override bool BeforeBuild()
        {
            Au.Loaders.ResourceBuilder.AutoCreateBundleNames(GameSettingsManager.current.projectConfig.bundleDataPath);
            return GameSettingsManager.current != null;
        }

        protected override bool OnBuild()
        {
            Loaders.ResourceBuilder.BuildBundles(
                GameSettingsManager.current.projectConfig.bundleOutputPath,
                runner.target);
            return true;
        }
    }
}
