using Au;
using Au.Loaders;
using Puerts;

internal class TestInit : AppInit
{
    public override bool javascriptDebugMode =>
#if UNITY_EDITOR
            true;
#else
            false;
#endif

    //    public override string javascriptAssetPath =>
    //#if UNITY_EDITOR
    //        "file://./Typescripts/dist/index.js";
    //#else
    //        "bundle://js/Assets/Bundles/js/main.bytes";
    //#endif

    public override Loader CreateLoader()
    {
#if UNITY_EDITOR
        return new LoaderForEditor();
#else
        return new LoaderForRuntime();
#endif
    }

    public override void InitJsEnv(JsEnv env)
    {
        return;
    }
}
