using Au.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Au.Forms
{
    public class BuildPanel : SettingPanel
    {
        private Logger logger = Logger.GetLogger<BuildPanel>();
        public override string Name => "Build";

        public override string DisplayName => "Build";

        public override string Description => "Build project";

        private int buildNo = 0;

        public override void OnShow()
        {
            base.OnShow();
            buildNo = BuildNo.Get();
        }

        public override void OnGUI()
        {
            EditorGUILayout.LabelField("App id", Application.identifier);
            EditorGUILayout.LabelField("Platform", GameSettingsManager.current.platformConfig.name);
            EditorGUILayout.LabelField("App config", GameSettingsManager.current.appConfig.name);
            EditorGUILayout.LabelField("Build no.", buildNo.ToString());
            EditorGUILayout.LabelField("Excels", GameSettingsManager.current.GetLocalConfig().excelsDirectory);
            EditorGUILayout.LabelField("Bundles", GameSettingsManager.current.projectConfig.bundleDataPath);
            EditorGUILayout.LabelField("Output", GameSettingsManager.current.GetLocalConfig().outputDirectory);
            EditorGUILayout.Space();

            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Build Bundles", GUILayout.Width(128), GUILayout.Height(32)))
                {
                    BuildProc(false);
                }
                if (GUILayout.Button("Build", GUILayout.Width(64), GUILayout.Height(32)))
                {
                    BuildProc(true);
                }
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }

        private async void BuildProc(bool app)
        {
            await Task.Yield();

            List<BuildTask> tasks = new List<BuildTask>();
            tasks.Add(new BuildJavascript());
            tasks.Add(new BuildExcels());
            tasks.Add(new BuildBundle());
            if (app)
            {
                tasks.Add(new BuildApp());
            }

            if (BuildRunner.Run(tasks.ToArray()))
            {
                buildNo = BuildNo.Inc();
            }
        }
    }
}
