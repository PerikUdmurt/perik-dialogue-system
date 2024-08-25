using SimpleDialogueSystem.StaticDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors
{
    public class DialogueSystemWindowEditor : EditorWindow
    {
        [MenuItem("Window/SimpleDialogueSystem/DialogueGraphs")]
        public static void Open()
        {
            DialogueSystemWindowEditor wnd = GetWindow<DialogueSystemWindowEditor>();
            wnd.titleContent = new GUIContent("DialogueGraph");
        }

        public static void Open(DialogueStaticData staticData)
        {
            Open();
        }

        private void CreateGUI()
        {
            NodeGraphView view = MyElementUtility.AddGraphView();
            Toolbar toolbar = MyElementUtility.AddToolbar();

            rootVisualElement.Add(view);
            rootVisualElement.Add(toolbar);
            AddSidePanel();
            AddStyles();
        }

        //Лист со всеми диалогами можно вынести в отдельный класс
        List<DialogueStaticData> dialogues = new();
        private void AddSidePanel()
        {
            VisualElement sidePanel = new VisualElement();

            ListView dialogueListView = AddDialogueListView();
            sidePanel.Add(dialogueListView);
            sidePanel.AddToClassList("ds-node__side-pane-container");
            sidePanel.style.width = 200f;
            sidePanel.style.height = 100;

            rootVisualElement.Add(sidePanel);
        }

        

        private ListView AddDialogueListView()
        {
            dialogues = Resources.LoadAll<DialogueStaticData>("StaticDatas").ToList<DialogueStaticData>();

            return new ListView(dialogues);
        }

        private void AddStyles()
        {
            rootVisualElement.AddStylesByPath("Variables.uss");
            rootVisualElement.AddStylesByPath("NodeStyles.uss");
        }
    }
}