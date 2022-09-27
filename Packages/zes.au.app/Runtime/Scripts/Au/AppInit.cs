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
        /// Use debug mode javascript env
        /// </summary>
        public abstract bool javascriptDebugMode { get; }

        /// <summary>
        /// Init js env
        /// </summary>
        /// <param name="env"></param>
        public abstract void InitJsEnv(JsEnv env);

        /// <summary>
        /// Create loader
        /// </summary>
        /// <returns></returns>
        public abstract Loader CreateLoader();
    }
}
