using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
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

        public EditorNode CreateNode(Vector2 position, List<IEvent> events)
        { 
            EditorNode node = _factory.CreateEditorNode(position, events);
            AddElement(node);
            return node;
        }

        public NoteNode CreateNoteNode(Vector2 position, string text = "")
        {
            NoteNode node = _factory.CreateEditorNode(position, text);
            AddElement(node);
            return node;
        }

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

        private IManipulator CreateNodeContextualMenu()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction(
                    actionName: "Add Node", 
                    actionEvent => CreateNode(actionEvent.eventInfo.localMousePosition, new()))   
                );
            return contextualMenuManipulator;
        }

        private IManipulator CreateNodeContextualMenu2()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction(
                    actionName: "Add NoteNode",
                    actionEvent => CreateNoteNode(actionEvent.eventInfo.localMousePosition))
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