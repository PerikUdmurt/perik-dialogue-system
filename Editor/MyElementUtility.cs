using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors
{
    public static class MyElementUtility
    {
        public const string TextField = "ds-node__text-field";
        public const string TextFieldHidden = "ds-node__text-field";
        public const string FilenameTextField = "ds-node__text-field";

        public const string Button = "ds-node__button";

        private const string defaultFileNameLabel = "FileName";
        private const string defaultFileName = "NewFile";

        public static TextField AddTextField(string label = "", string initialValue = "")
        {
            TextField textField = new()
            {
                label = label,
                value = initialValue 
            };
            textField.AddToClassList(TextField);
            textField.AddToClassList(FilenameTextField);
            textField.AddToClassList(TextFieldHidden);
            return textField;
        }

        public static Button AddButton(string buttonText) 
        {
            Button button = new Button()
            {
                text = buttonText
            };
            button.AddToClassList(Button);
            return button;
        }

        public static void AddStylesByPath(this VisualElement visualElement, string path)
        {
            StyleSheet styleSheet = (StyleSheet)EditorGUIUtility.Load(path);
            visualElement.styleSheets.Add(styleSheet);
        }

        public static NodeGraphView AddGraphView()
        {
            NodeGraphView graphView = new NodeGraphView();
            graphView.StretchToParentSize();
            return graphView;
        }

        public static Toolbar AddToolbar()
        {
            Toolbar toolbar = new Toolbar();

            TextField fileNameTextField = MyElementUtility.AddTextField(defaultFileNameLabel, defaultFileName);
            toolbar.Add(fileNameTextField);

            Button saveButton = MyElementUtility.AddButton("Save");
            toolbar.Add(saveButton);

            toolbar.AddStylesByPath("DSToolbarStyles.uss");

            return toolbar;
        }
    }
}