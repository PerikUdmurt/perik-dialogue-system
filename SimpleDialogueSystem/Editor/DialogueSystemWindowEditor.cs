using SimpleDialogueSystem.StaticDatas;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public class DialogueSystemWindowEditor : EditorWindow
    {
        private static DialogueStaticData _staticData;
        
        [MenuItem("Window/SimpleDialogueSystem/DialogueGraphs")]
        public static void Open()
        {
            DialogueSystemWindowEditor wnd = GetWindow<DialogueSystemWindowEditor>();
            wnd.titleContent = new GUIContent("DialogueGraph");
        }

        public static void Open(DialogueStaticData staticData)
        {
            Open();
            _staticData = staticData;
        }

        private void CreateGUI()
        {
           NodeGraphView graphView = MyElementUtility.AddGraphView();
            Toolbar toolbar = MyElementUtility.AddToolbar();
            SaveGraphUtility.Init(graphView);

            rootVisualElement.Add(graphView);
            rootVisualElement.Add(toolbar);
            AddStyles();
            LoadGraphUtility.Load(_staticData, graphView);
        }

        private void OnDisable()
        {
            SaveGraphUtility.Save();
        }

        private void AddStyles()
        {
            rootVisualElement.AddStylesByPath("Variables.uss");
            rootVisualElement.AddStylesByPath("NodeStyles.uss");
        }
    }
}