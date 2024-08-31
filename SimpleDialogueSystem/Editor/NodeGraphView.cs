using SimpleDialogueSystem.Editors.Nodes;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors
{
    public class NodeGraphView : GraphView
    {
        EditorNodeFactory _factory;
        public NodeGraphView() 
        {
            _factory = new EditorNodeFactory();
            AddManipulators();
            AddGridBackground();
            AddStyles();
        }

        private EditorNode CreateNode(Vector2 position)
            => _factory.CreateEditorNode<EditorNode>(position);

        private NoteNode CreateNoteNode(Vector2 position)
            => _factory.CreateEditorNode<NoteNode>(position);

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatablePorts = new();

            ports.ForEach(port =>
            {
                if (startPort == port)
                    return;

                if (startPort.node == port.node)
                    return;

                if (startPort.direction == port.direction)
                    return;

                compatablePorts.Add(port);
            });

            return compatablePorts;
        }

        private void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());   
            this.AddManipulator(new RectangleSelector());  

            this.AddManipulator(CreateNodeContextualMenu());
            this.AddManipulator(CreateNodeContextualMenu2());
        }

        //Повторяющийся код. Перепиши.
        private IManipulator CreateNodeContextualMenu()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction(
                    actionName: "Add Node", 
                    actionEvent => AddElement(CreateNode(actionEvent.eventInfo.localMousePosition)))   
                );
            return contextualMenuManipulator;
        }

        private IManipulator CreateNodeContextualMenu2()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction(
                    actionName: "Add NoteNode",
                    actionEvent => AddElement(CreateNoteNode(actionEvent.eventInfo.localMousePosition)))
                );
            return contextualMenuManipulator;
        }

        private void AddStyles()
        {
            this.AddStylesByPath("GraphViewStyles.uss");
        }

        private void AddGridBackground()
        {
            GridBackground gridBackground = new GridBackground();

            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }
    }
}