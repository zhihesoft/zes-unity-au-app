using Au.DI;
using Au.TS;
using UnityEngine;

namespace Au
{
    public abstract class App : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            OnStart();
        }

        protected TSApp tsApp;

        protected abstract void OnStart();

        protected object rootComponent;

        public virtual void Bootstrap<T>()
        {
            rootComponent = Container.root.Resolve<T>();
        }
    }
}
