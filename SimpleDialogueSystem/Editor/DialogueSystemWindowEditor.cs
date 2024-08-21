using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors
{
    public class DialogueSystemWindowEditor : EditorWindow
    {
        [MenuItem("Window/SimpleDialogueSystem/DialogueGraphs")]
        public static void ShowExample()
        {
            DialogueSystemWindowEditor wnd = GetWindow<DialogueSystemWindowEditor>();
            wnd.titleContent = new GUIContent("DialogueGraph");
        }

        private void CreateGUI()
        {
            AddGraphView();
            AddStyles();
        }

        private void AddStyles()
        {
            StyleSheet styleSheet = (StyleSheet)EditorGUIUtility.Load("Variables.uss");
            rootVisualElement.styleSheets.Add(styleSheet);
        }

        private void AddGraphView()
        {
            DialogueGraphView graphView = new DialogueGraphView();
            graphView.StretchToParentSize();
            rootVisualElement.Add(graphView);
        }
    }
}