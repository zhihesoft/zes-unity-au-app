#if UNITY_EDITOR
using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Au.Loaders
{
    public class LoaderForEditor : Loader
    {
        public override void UnloadAllBundles()
        {
        }

        public override bool UnloadBundle(string name)
        {
            return true;
        }

        protected override async Task<UnityEngine.Object> LoadingAsset(string path, Type type)
        {
            var data = AssetDatabase.LoadAssetAtPath(path, type);
            await Task.Delay(0);
            return data;
        }

        protected override async Task<bool> LoadingBundle(string name, Action<float> progress)
        {
            for (int i = 0; i < 15; i++)
            {
                progress(i / 15.0f);
                await Task.Yield();
            }
            progress(1);
            return true;
        }

        protected override async Task<Scene> LoadingScene(string name, bool additive, Action<float> progress)
        {
            Scene loadedScene = default(Scene);
            UnityAction<Scene, LoadSceneMode> callback = (scene, mode) => loadedScene = scene;
            SceneManager.sceneLoaded += callback;
            var loadparams = new LoadSceneParameters(additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
            var op = EditorSceneManager.LoadSceneAsyncInPlayMode(name, loadparams);
            await Utils.WaitAsyncOperation(op, progress);
            SceneManager.sceneLoaded -= callback;
            return loadedScene;
        }
    }
}

#endif