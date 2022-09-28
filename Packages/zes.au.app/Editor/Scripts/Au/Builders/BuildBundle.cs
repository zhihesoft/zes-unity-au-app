using System.IO;
using System.Linq;
using UnityEngine;

namespace Au.Builders
{
    internal class BuildBundle : BuildTask
    {
        public override string name => "Bundle";

        protected override void AfterBuild()
        {
            Utils.DirClear(Application.streamingAssetsPath);
            if (!EditorHelper.usingAAB(target))
            {
                DirectoryInfo di = new DirectoryInfo(bundleOutputDir());
                di.GetFiles()
                    .Where(file => file.Extension != ".manifest")
                    .Where(file => !file.Name.StartsWith(target.ToString()))
                    .ToList()
                    .ForEach(file =>
                    {
                        File.Copy(file.FullName, Path.Combine(Application.streamingAssetsPath, file.Name));
                    });
            }
        }

        protected override bool BeforeBuild()
        {
            Utils.DirClear(bundleOutputDir());
            Loaders.ResourceBuilder.AutoCreateBundleNames(
                Path.Combine("Assets", GameSettingsManager.current.appConfig.bundleDataPath));
            return GameSettingsManager.current != null;
        }

        protected override bool OnBuild()
        {
            Loaders.ResourceBuilder.BuildBundles(bundleOutputDir(), target);
            return true;
        }

        string bundleOutputDir()
        {
            string outputPath = Path.Combine(GameSettingsManager.current.projectConfig.bundleOutputPath, target.ToString());
            return outputPath;
        }
    }
}
