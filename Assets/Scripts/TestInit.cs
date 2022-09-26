using Au;
using Au.Loaders;
using Puerts;

internal class TestInit : AppInit
{
    public override string javascriptAssetPath => "Assets/Bundles/js/main.bytes";

    public override bool javascriptInEditor
    {
        get
        {
#if UNITY_EDITOR
            return true;
#else
            return false;
#endif
        }
    }

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
