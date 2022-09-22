using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditorInternal;
using Debug = UnityEngine.Debug;

namespace Au.Builders
{
    internal class BuildExcels : BuildTask
    {
        public override string name => "Excels";

        protected override void AfterBuild()
        {
        }

        protected override bool BeforeBuild()
        {
            var config = GameSettingsManager.current.GetLocalConfig();
            if (!Directory.Exists(config.excelsDirectory))
            {
                Debug.Log($"excel directory [{config.excelsDirectory}] not existed.");
                return false;
            }
            return true;
        }

        protected override bool OnBuild()
        {
            var appConfig = GameSettingsManager.current.appConfig;
            var projectConfig = GameSettingsManager.current.projectConfig;
            var config = GameSettingsManager.current.GetLocalConfig();

            DirectoryInfo excelDir = new DirectoryInfo(config.excelsDirectory);
            DirectoryInfo workDir = excelDir.Parent;
            DirectoryInfo outDir = new DirectoryInfo(Path.Combine(workDir.FullName, "output"));
            DirectoryInfo outClientDir = new DirectoryInfo(Path.Combine(workDir.FullName, "output", "client"));
            DirectoryInfo outLanguageDir = new DirectoryInfo(Path.Combine(workDir.FullName, "output", "language"));

            DirectoryInfo targetConfDir = new DirectoryInfo(Path.Combine(projectConfig.bundleDataPath, appConfig.bundleConfig));
            DirectoryInfo targetLanguageDir = new DirectoryInfo(Path.Combine(projectConfig.bundleDataPath, appConfig.bundleLanguage));

            Utils.DirEnsure(targetConfDir.FullName);
            Utils.DirEnsure(targetLanguageDir.FullName);
            Utils.DirEnsure(outDir.FullName);

            int code = EditorHelper.Shell("zes-excel-exporter", new List<string>
            {
                "-i", excelDir.FullName,
                "-o", outDir.FullName,
                "--lid", projectConfig.languageStartId.ToString(),
                "-l", projectConfig.languageConfigName
            }, workDir.FullName);

            if (code != 0)
            {
                logger.Error("excel export failed with code " + code);
                logger.Error("output:");
                logger.Error(EditorHelper.shellOutput.ToString());
                return false;
            }

            Utils.DirCopy(outClientDir, targetConfDir);
            Utils.DirCopy(outLanguageDir, targetLanguageDir);

            return true;
        }
    }
}
