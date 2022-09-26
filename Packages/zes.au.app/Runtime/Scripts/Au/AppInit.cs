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
        /// Javascript asset path. (e.g. Assets/Bundles/js/main.bytes)
        /// </summary>
        public abstract string javascriptAssetPath { get; }

        /// <summary>
        /// Javascript debug mode, if true, scripts will be loaded directly from js files
        /// </summary>
        public abstract bool javascriptInEditor { get; }

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
        //        {
        //#if UNITY_EDITOR
        //            return new LoaderForEditor();
        //#else
        //            return new LoaderForRuntime();
        //#endif
        //        }
    }
}
