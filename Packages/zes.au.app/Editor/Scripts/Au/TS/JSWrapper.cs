using Puerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Au.TS
{
    /// <summary>
    /// Get types of JSWrap attribute
    /// </summary>
    [Configure]
    public static class JSWrapper
    {
        [Binding]
        public static IEnumerable<Type> Bind
        {
            get
            {
                List<Type> typesList = new List<Type>();

                var wrapTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                                from type in assembly.GetTypes()
                                where type.IsDefined(typeof(JSWrapAttribute), false)
                                select type;

                typesList.AddRange(wrapTypes);
                return typesList;
            }
        }

        [Binding]
        public static IEnumerable<Type> CommonBindings
        {
            get
            {
                return new Type[]
                {
                    typeof(Vector2),
                    typeof(Vector3),
                    typeof(Color),
                    typeof(Scene),
                    typeof(UnityEngine.Object),
                    typeof(Application),
                    typeof(SystemInfo),
                    typeof(Array),
                    typeof(Component),
                    typeof(AsyncOperation),
                    typeof(Resources),
                    typeof(TextAsset),
                    typeof(GameObject),
                    typeof(Transform),
                    typeof(RectTransform),
                    typeof(CanvasGroup),
                    typeof(AssetBundle),
                    typeof(Sprite),
                    typeof(Graphic),
                    typeof(Image),
                    typeof(Text),
                    typeof(Button),
                    typeof(Toggle),
                    typeof(ToggleGroup),
                    typeof(Slider),
                    typeof(Button.ButtonClickedEvent),
                    typeof(UnityEvent),
                    typeof(UnityEventBase),
                    typeof(PlayerPrefs),
                    typeof(VideoPlayer),
                    typeof(VideoClip),
                    typeof(Behaviour),
                    typeof(Animator),
                    typeof(Animation),
                    typeof(UnityEngine.AI.NavMeshAgent),

                    typeof(TMP_Text),

                };
            }
        }

        [Filter]
        public static bool Filter(MemberInfo mb)
        {
            if (mb.IsDefined(typeof(JSIgnoreAttribute), false))
            {
                // Debug.Log($"{mb} is ignore");
                return true;
            }
            return false;
        }
    }
}
