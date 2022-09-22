using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Au.Builders
{
    internal class BuildPatch : BuildTask
    {
        public override string name => "Patch";

        Patcher.BuildSettings patchSettings;

        protected override void AfterBuild()
        {
        }

        protected override bool BeforeBuild()
        {
            patchSettings = new Patcher.BuildSettings
            {
                app = Application.identifier,
                version = EditorHelper.CurrentVersion(),
                url = EditorHelper.CombineUri(GameSettingsManager.current.appConfig.patchServer, target.ToString().ToLower()),
                minVersion = GameSettingsManager.current.appConfig.minVersion,
                bundlesDir = Path.Combine(GameSettingsManager.current.projectConfig.bundleOutputPath, target.ToString()),
            };
            return patchSettings.Validate();
        }

        protected override bool OnBuild()
        {
            Patcher.PatcherBuilder.Build(patchSettings);
            BuildPatchZip(EditorHelper.GetAppOutputName(
                GameSettingsManager.current.appConfig,
                GameSettingsManager.current.platformConfig,
                target));
            return true;
        }

        void BuildPatchZip(string name)
        {
            var localDir = new DirectoryInfo(Path.Combine(GameSettingsManager.current.projectConfig.bundleOutputPath, target.ToString()));
            string outputDir = GameSettingsManager.current.GetLocalConfig().outputDirectory;
            Utils.DirEnsure(outputDir);
            FileInfo zipFile = new FileInfo(Path.Combine(outputDir, name + ".zip"));
            using (ZipFile zip = ZipFile.Create(zipFile.FullName))
            {
                zip.BeginUpdate();
                localDir.GetFiles("*.*").ToList().ForEach(file => zip.Add(file.FullName, file.Name));
                zip.CommitUpdate();
            }
        }

    }
}
