using System;
using UnityEditor;

namespace Au.Forms
{
    public class GUIIndent : IDisposable
    {
        public GUIIndent()
        {
            indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = indentLevel + 1;
        }

        readonly int indentLevel;

        public void Dispose()
        {
            EditorGUI.indentLevel = indentLevel;
        }
    }
}
