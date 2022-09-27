using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Au
{
    public static class EditorHelper
    {
        public static string[] GetBuildScenes()
        {
            string[] scenes = EditorBuildSettings.scenes
                         .Where(scene => scene.enabled)
                         .Select(scene => scene.path)
                         .Select(s =>
                         {
                             return s;
                         })
                         .ToArray();
            return scenes;
        }

        public static bool usingAAB(BuildTarget target)
        {
            if (target != BuildTarget.Android)
            {
                return false;
            }

#if USING_AAB
            return true;
#else
            return false;
#endif
        }

        public static string CurrentVersion()
        {
            return $"{Application.version}.{BuildNo.Get()}";
        }

        public static int Shell(string filename, List<string> arguments, string workingDir = null)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
#if UNITY_EDITOR_WIN
                FileName = "cmd",
#else
                FileName = "/bin/bash",
#endif
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };

#if UNITY_EDITOR_WIN
            startInfo.ArgumentList.Add("/c");
#endif
            startInfo.ArgumentList.Add(filename);
            arguments.ForEach(i => startInfo.ArgumentList.Add(i));

            if (!string.IsNullOrEmpty(workingDir))
            {
                startInfo.WorkingDirectory = workingDir;
            }

            var proc = Process.Start(startInfo);

            proc.WaitForExit();

            if (proc.ExitCode != 0)
            {
                Debug.LogError(proc.StandardOutput.ReadToEnd());
                Debug.LogError(proc.StandardError.ReadToEnd());
            }

            return proc.ExitCode;
        }

        public static string GetAppOutputName(AppConfig appConfig, PlatformConfig platformConfig, BuildTarget target)
        {
            string appOutputName = string.Join("_",
                appConfig.appName,
                target.ToString().ToLower(),
                platformConfig.name,
                appConfig.name,
                CurrentVersion()
                );
            return appOutputName;

        }

        public static string CombineUri(string baseUri, string path)
        {
            if (!baseUri.EndsWith("/"))
            {
                baseUri += "/";
            }

            return new Uri(new Uri(baseUri), path).ToString();
        }


        /// <summary>
        /// clear any file in project if it present in template dir
        /// </summary>
        /// <param name="templateDir"></param>
        /// <returns></returns>
        public static void ClearTemplateFiles(string templateDir)
        {
            ClearTemplateFiles(templateDir, null);
        }

        private static void ClearTemplateFiles(string templateDir, string childDir)
        {
            childDir = childDir ?? ".";
            string fromDir = Path.Combine(templateDir, childDir);
            string toDir = Path.Combine(".", childDir);
            var dir = new DirectoryInfo(fromDir);
            dir.GetFiles().ToList().ForEach(file =>
            {
                string toFile = Path.Combine(toDir, file.Name);
                if (File.Exists(toFile))
                {
                    File.Delete(toFile);
                }
            });
            dir.GetDirectories().ToList().ForEach(dir =>
            {
                ClearTemplateFiles(templateDir, Path.Combine(childDir, dir.Name));
            });
        }
    }
}
