using SimpleDialogueSystem.StaticDatas;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public class DialogueSystemWindowEditor : EditorWindow
    {
        private const string TitleContentText = "Dialogue System";

        private static DialogueStaticData _staticData;
        
        public static void Open()
        {
            DialogueSystemWindowEditor wnd = GetWindow<DialogueSystemWindowEditor>();
            wnd.titleContent = new GUIContent(TitleContentText);
        }

        public static void Open(DialogueStaticData staticData)
        {
            _staticData = staticData;
            Open();
        }

        private void CreateGUI()
        {
            NodeGraphView graphView = UIElementUtility.AddGraphView();
            Toolbar toolbar = UIElementUtility.AddToolbar();
            SaveGraphUtility.Init(_staticData, graphView);

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