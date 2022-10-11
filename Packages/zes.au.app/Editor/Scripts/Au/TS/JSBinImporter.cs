using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Au.TS
{
    internal static class JSBinImporter
    {
        public static void Import()
        {
            var puertsDirPrefix = "com.tencent.puerts.core";
            var di = new DirectoryInfo(Path.Combine("Library", "PackageCache"));
            if (!di.Exists)
            {
                Alert($"{di.FullName} not existed");
                return;
            }

            var dir = di.GetDirectories().FirstOrDefault(d => d.Name.ToLower().StartsWith(puertsDirPrefix));
            if (dir == null)
            {
                Alert($"cannot find puerts package. \n(dir start with {puertsDirPrefix})");
                return;
            }

            var pluginDir = new DirectoryInfo(Path.Combine(dir.FullName, "Plugins"));
            if (!pluginDir.Exists)
            {
                Alert($"cannot find puerts plugin dir. \n ({pluginDir.FullName})");
                return;
            }

            var all = new string[] { "Android", "iOS" };
            pluginDir.GetDirectories()
                .Where(dir => all.Any(a => a == dir.Name))
                .ToList()
                .ForEach(dir =>
                {
                    DirCopy(dir, new DirectoryInfo(Path.Combine("Assets", "Plugins", dir.Name)));
                });
            Alert("DONE");
        }

        static void Alert(string message)
        {
            EditorUtility.DisplayDialog("MSG", message, "OK");
        }

        static void DirCopy(DirectoryInfo from, DirectoryInfo to)
        {
            if (!from.Exists)
            {
                Debug.LogError($"Copy dir failed: {from.FullName} not existed");
                return;
            }

            Utils.DirEnsure(to);

            var extensions = new string[] { ".so", ".a" };

            from.GetFiles()
                .Where(f => extensions.Any(e => e == f.Extension.ToLower()))
                .ToList()
                .ForEach(file => file.CopyTo(Path.Combine(to.FullName, file.Name), true));

            from.GetDirectories()
                .ToList()
                .ForEach(dir => DirCopy(dir, new DirectoryInfo(Path.Combine(to.FullName, dir.Name))));
        }

    }
}
