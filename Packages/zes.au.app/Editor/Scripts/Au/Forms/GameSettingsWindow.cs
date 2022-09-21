using UnityEditor;
using UnityEngine;

namespace Au.Forms
{
    public class GameSettingsWindow : EditorWindow
    {

        [MenuItem("Au/Settings", priority = 1)]
        public static void ShowGameSettingsWindow()
        {
            var window = GetWindow<GameSettingsWindow>("Game Settings");
            window.Show();
            window.minSize = new Vector2(800, 600);
            window.Initialize();
        }

        private SettingsManager manager;

        void Initialize()
        {
            if (manager == null)
            {
                manager = new SettingsManager();
                manager.Initialize();
            }
        }

        private void OnGUI()
        {
            if (manager == null)
            {
                Initialize();
            }
            manager?.OnGUI();
        }
    }
}

