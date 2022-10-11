using Au.TS;
using UnityEditor;
using UnityEngine;

namespace Au
{
    public static class MenuCommands
    {
        [MenuItem("Au/Utils/Nest AnimClips in Controller", true)]
        public static bool NestAnimClipsValidate()
        {
            return NestAnimator.NestAnimClipsValidate();
        }

        [MenuItem("Au/Utils/Nest AnimClips in Controller")]
        public static void NestAnimClips(MenuCommand command)
        {
            NestAnimator.NestAnimClips(command);
        }

        [MenuItem("Au/Utils/Clear PlayerPrefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [MenuItem("Au/Utils/Import puerts plugin files")]
        public static void ImportJsBins()
        {
            JSBinImporter.Import();
            AssetDatabase.Refresh();
        }
    }
}
