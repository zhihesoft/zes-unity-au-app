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

        public static string GetAppOutputName(AppConfig appConfig, PlatformConfig platformConfig)
        {
            string appOutputName = string.Join("_",
                appConfig.appName,
                platformConfig.name,
                appConfig.name,
                CurrentVersion(),
                DateTime.Now.ToString("yyyyMMdd")
                );
            return appOutputName;

        }

        public static DirectoryInfo DirEnsure(string dir)
        {
            return DirEnsure(new DirectoryInfo(dir));
        }

        // ensure dir exist
        public static DirectoryInfo DirEnsure(DirectoryInfo dir)
        {
            if (!dir.Parent.Exists)
            {
                DirEnsure(dir.Parent);
            }

            if (!dir.Exists)
            {
                dir.Create();
            }

            return dir;
        }

        public static DirectoryInfo DirClear(string dir)
        {
            return DirClear(new DirectoryInfo(dir));
        }

        // clear dir
        public static DirectoryInfo DirClear(DirectoryInfo dir)
        {
            DirEnsure(dir);
            dir.GetFiles().ToList().ForEach(f => f.Delete());
            dir.GetDirectories().ToList().ForEach(d => d.Delete(true));
            return dir;
        }

        public static void DirCopy(string from, string to)
        {
            DirCopy(new DirectoryInfo(from), new DirectoryInfo(to));
        }

        public static void DirCopy(DirectoryInfo from, DirectoryInfo to)
        {
            if (!from.Exists)
            {
                UnityEngine.Debug.LogError($"Copy dir failed: {from.FullName} not existed");
                return;
            }

            DirEnsure(to);

            from.GetFiles().ToList().ForEach(file => file.CopyTo(Path.Combine(to.FullName, file.Name), true));
            from.GetDirectories().ToList().ForEach(dir => DirCopy(dir, new DirectoryInfo(Path.Combine(to.FullName, dir.Name))));
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

        private static void SaveJsonObj<T>(T obj, string path) where T : class
        {
            var json = JsonUtility.ToJson(obj, true);
            File.WriteAllText(path, json, Utils.utf8WithoutBOM);
        }

        private static T LoadJsonObj<T>(string path) where T : class
        {
            if (!File.Exists(path))
            {
                return null;
            }

            var content = File.ReadAllText(path);
            var obj = JsonUtility.FromJson<T>(content);
            return obj;
        }
    }
}
