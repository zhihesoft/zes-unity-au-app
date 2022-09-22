using System.Collections.Generic;
using UnityEditor;

namespace Au.Forms
{
    public abstract class SettingPanel
    {
        public abstract string Name { get; }
        public abstract string DisplayName { get; }
        public abstract string Description { get; }
        public bool dirty { get; set; }

        Dictionary<string, bool> foldoutFlags = new Dictionary<string, bool>();

        /// <summary>
        /// render gui
        /// if return true, means config is dirty, should save it.
        /// </summary>
        /// <returns></returns>
        abstract public void OnGUI();
        public virtual void OnShow() { }
        public virtual void OnHide() { }

        protected string TextField(string label, string value)
        {
            var ret = EditorGUILayout.TextField(label, value);
            if (!dirty)
            {
                dirty = ret != value;
            }
            return ret;
        }

        protected int IntField(string label, int value)
        {
            int ret = EditorGUILayout.IntField(label, value);
            if (!dirty)
            {
                dirty = ret != value;
            }
            return ret;
        }

        protected bool BoolField(string label, bool value)
        {
            var ret = EditorGUILayout.Toggle(label, value);
            if (!dirty)
            {
                dirty = ret != value;
            }
            return ret;
        }

        protected void Foldout(string name, System.Action act, bool addSpace = true)
        {
            if (!foldoutFlags.TryGetValue(name, out bool flag))
            {
                foldoutFlags.Add(name, true);
                flag = true;
            }

            var newflag = EditorGUILayout.Foldout(flag, name, true);
            if (newflag)
            {
                using (new GUIIndent())
                {
                    act();
                }
            }
            if (newflag != flag)
            {
                foldoutFlags[name] = newflag;
            }

            if (addSpace)
            {
                EditorGUILayout.Space();
            }
        }

    }
}
