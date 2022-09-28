using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Au.Builders
{
    internal class BuildApp : BuildTask
    {
        public override string name => "APP";

        protected override void AfterBuild()
        {
        }

        protected override bool BeforeBuild()
        {
            EditorUserBuildSettings.buildAppBundle = false;
            return true;
        }

        protected override bool OnBuild()
        {
            var localConfig = GameSettingsManager.current.GetLocalConfig();
            string outputDir = localConfig.outputDirectory;
            Utils.DirEnsure(outputDir);

            string extension = "";
            if (EditorHelper.usingAAB(target))
            {
                extension = ".aab";
            }
            else if (target == BuildTarget.Android)
            {
                extension = ".apk";
            }
            string appOutputName = EditorHelper.GetAppOutputName(
                GameSettingsManager.current.appConfig,
                GameSettingsManager.current.platformConfig,
                target);
            string outputPath = string.Format("{0}/{1}{2}",
                outputDir,
                appOutputName,
                extension
                );

            if (target == BuildTarget.StandaloneWindows64 || target == BuildTarget.StandaloneWindows)
            {
                outputPath = string.Format("{0}/{1}/{2}{3}",
                                outputDir,
                                appOutputName,
                                Application.productName,
                                ".exe"
                                );
            }


            string[] scenes = EditorHelper.GetBuildScenes();

            BuildPlayerOptions opts = new BuildPlayerOptions()
            {
                locationPathName = outputPath,
                scenes = scenes,
                target = target,
            };

            bool result = false;
#if USING_AAB
            opts.targetGroup = BuildTargetGroup.Android;
            Google.Android.AppBundle.Editor.Internal.AppBundlePublisher.Build(opts, null, true);
            result = true;
#else
            var report = BuildPipeline.BuildPlayer(opts);

            if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Failed)
            {
                logger.Error($"build failed: {report.summary.totalErrors} errors");
            }
            if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                logger.Info($"build succ !!");
                result = true;
            }
            if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Cancelled)
            {
                logger.Warn($"build cancel");
            }
            if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Unknown)
            {
                logger.Error($"build failed for unknown reason");
            }
#endif

            return result;
        }
    }
}
