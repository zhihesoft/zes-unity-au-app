using System;

namespace PuertsStaticWrap
{
    public static class AutoStaticCodeRegister
    {
        public static void Register(Puerts.JsEnv jsEnv)
        {
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.GameObject), UnityEngine_GameObject_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Image), UnityEngine_UI_Image_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(Au.App), Au_App_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(Au.AppConfig), Au_AppConfig_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(Au.Tags), Au_Tags_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(Au.Utils), Au_Utils_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Vector2), UnityEngine_Vector2_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Vector3), UnityEngine_Vector3_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Color), UnityEngine_Color_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.SceneManagement.Scene), UnityEngine_SceneManagement_Scene_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Object), UnityEngine_Object_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Application), UnityEngine_Application_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.SystemInfo), UnityEngine_SystemInfo_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(System.Array), System_Array_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Component), UnityEngine_Component_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.AsyncOperation), UnityEngine_AsyncOperation_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Resources), UnityEngine_Resources_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.TextAsset), UnityEngine_TextAsset_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Transform), UnityEngine_Transform_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.RectTransform), UnityEngine_RectTransform_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.CanvasGroup), UnityEngine_CanvasGroup_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.AssetBundle), UnityEngine_AssetBundle_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Sprite), UnityEngine_Sprite_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Graphic), UnityEngine_UI_Graphic_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Text), UnityEngine_UI_Text_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Button), UnityEngine_UI_Button_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Toggle), UnityEngine_UI_Toggle_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.ToggleGroup), UnityEngine_UI_ToggleGroup_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Slider), UnityEngine_UI_Slider_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Button.ButtonClickedEvent), UnityEngine_UI_Button_ButtonClickedEvent_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Events.UnityEvent), UnityEngine_Events_UnityEvent_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Events.UnityEventBase), UnityEngine_Events_UnityEventBase_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.PlayerPrefs), UnityEngine_PlayerPrefs_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Video.VideoPlayer), UnityEngine_Video_VideoPlayer_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Video.VideoClip), UnityEngine_Video_VideoClip_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Behaviour), UnityEngine_Behaviour_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Animator), UnityEngine_Animator_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Animation), UnityEngine_Animation_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.AI.NavMeshAgent), UnityEngine_AI_NavMeshAgent_Wrap.GetRegisterInfo);
                
                
            jsEnv.AddLazyStaticWrapLoader(typeof(TMPro.TMP_Text), TMPro_TMP_Text_Wrap.GetRegisterInfo);
                
                
        }
    }
}