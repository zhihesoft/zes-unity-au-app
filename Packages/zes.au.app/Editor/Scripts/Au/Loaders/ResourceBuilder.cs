using System.IO;
using UnityEditor;
using UnityEngine;

namespace Au.Loaders
{
    /// <summary>
    /// Build for Resource Manager
    /// </summary>
    public static class ResourceBuilder
    {
        private static Log log = Log.GetLogger("ResourceBuilder");

        /// <summary>
        /// Auto create bundle names in dir Assets/{path}
        /// Assume each sub-dir is a bundle
        /// </summary>
        /// <param name="path"></param>
        public static void AutoCreateBundleNames(string path)
        {
            var bundles = new DirectoryInfo(path);
            var dirs = bundles.GetDirectories();
            foreach (var dir in dirs)
            {
                var importer = AssetImporter.GetAtPath(Path.Combine(path, dir.Name));
                if (importer == null)
                {
                    log.Error($"AssetImporter is null : {Path.Combine(path, dir.Name)}");
                    continue;
                }
                importer.assetBundleName = dir.Name.ToLower();
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Build bundles to output path dir
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="target"></param>
        public static void BuildBundles(string outputPath, BuildTarget target)
        {
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, target);
        }
    }
}
