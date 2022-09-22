using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.Builders
{
    internal class BuildJavascript : BuildTask
    {
        public override string name => "Javascript";

        protected override void AfterBuild()
        {
        }

        protected override bool BeforeBuild()
        {
            return true;
        }

        protected override bool OnBuild()
        {
            var projectConfig = GameSettingsManager.current.projectConfig;
            var appConfig = GameSettingsManager.current.appConfig;

            var exitCode = EditorHelper.Shell("gulp", new List<string> { "build" }, projectConfig.javascriptProjectPath);
            if (exitCode != 0)
            {
                logger.Error("build ts source failed with code " + exitCode);
                logger.Error("output:");
                logger.Error(EditorHelper.shellOutput.ToString());
                return false;
            }

            var source = new FileInfo(projectConfig.javascriptBuildResult);
            if (!source.Exists)
            {
                logger.Error($"{source.FullName} not existed");
                return false;
            }

            var target = Path.Combine(projectConfig.bundleDataPath, appConfig.bundleJS, source.Name);

            source.CopyTo(target, true);
            return true;
        }
    }
}
