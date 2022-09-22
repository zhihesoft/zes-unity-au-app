using System.IO;

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
                Path.Combine(GameSettingsManager.current.projectConfig.bundleOutputPath, target.ToString()),
                runner.target);
            return true;
        }
    }
}
