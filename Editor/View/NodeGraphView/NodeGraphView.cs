using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
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
            _factory = new EditorNodeFactory(this);
            AddManipulators();
            AddGridBackground();
            AddStyles();
        }

        public StartNode CreateStartNode(Vector2 position)
            => _factory.CreateSimpleNode<StartNode>(position);

        public SimpleNode CreateNode(Vector2 position, List<IEvent> events, string id = null)
            => _factory.CreateSimpleNode<SimpleNode>(position, events, id);

        public NoteNode CreateStickyNote(Vector2 position, string text = "¬ведите текст заметки")
            => _factory.CreateNote(position, text);

        public ChoicesNode CreateChoicesNode(Vector2 position, List<IEvent> events, string id = null)
            => _factory.CreateChoicesNode(position, events, id);

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

            this.CreateContextualMenu(
                menuItemName: "Add Node", 
                actionEvent => CreateNode(actionEvent.eventInfo.localMousePosition, new()));
            this.CreateContextualMenu(
                menuItemName: "Add Choices Node",
                actionEvent => CreateChoicesNode(actionEvent.eventInfo.localMousePosition, new()));
            this.CreateContextualMenu(
                menuItemName: "Add Sticky note",
                actionEvent => CreateStickyNote(actionEvent.eventInfo.localMousePosition));
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