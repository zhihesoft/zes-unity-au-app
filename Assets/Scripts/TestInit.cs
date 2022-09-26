using Au;
using Au.Loaders;
using Puerts;

internal class TestInit : AppInit
{
    public override string javascriptAssetPath => "bundle://js/Assets/Bundles/js/main.bytes";

    public override string javascriptDebugPath => "file://./Typescripts/dist/index.js";

    public override Loader CreateLoader()
    {
#if UNITY_EDITOR
        return new LoaderForEditor();
#else
        return new LoaderForRuntime();
#endif
    }

    public override void InitJS(JsEnv env)
    {
        return;
    }
}
