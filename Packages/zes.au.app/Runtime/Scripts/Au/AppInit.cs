using Au.Loaders;
using Puerts;
using UnityEngine;

namespace Au
{
    /// <summary>
    /// App initializor
    /// </summary>
    public abstract class AppInit : MonoBehaviour
    {
        /// <summary>
        /// Javascript asset path. (e.g. bundle://js/Assets/Bundles/js/main.bytes)
        /// </summary>
        public abstract string javascriptAssetPath { get; }

        /// <summary>
        /// Javascript debug path. (e.g. file://Typescripts/dist/index.js )
        /// </summary>
        public abstract string javascriptDebugPath { get; }

        /// <summary>
        /// Init js env
        /// </summary>
        /// <param name="env"></param>
        public abstract void InitJS(JsEnv env);

        /// <summary>
        /// Create loader
        /// </summary>
        /// <returns></returns>
        public abstract Loader CreateLoader();
    }
}
