using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class SimpleNode : BaseEditorNode
    {
        public override void Initialize(Vector2 position, List<IEvent> events = null, string id = null)
        {
            base.Initialize(position, events, id);
            CreatePort("Input", Direction.Input, Port.Capacity.Multi);
            CreatePort("Output", Direction.Output, Port.Capacity.Single);
        }
    }

    public class ConditionNode : BaseEditorNode
    {
        public override void Initialize(Vector2 position, List<IEvent> events = null, string id = null)
        {
            base.Initialize(position, events, id);
            CreatePort("Input", Direction.Input, Port.Capacity.Multi);
            CreatePort("Output", Direction.Output, Port.Capacity.Multi);
        }
    }

    public class ChoicesNode : BaseEditorNode
    {
        public List<string> Choices { get; private set; }

        public void Initialize(Vector2 position, List<string> choices, List<IEvent> events = null, string id = null)
        {
            base.Initialize(position, events, id);
            Choices = new();

            CreatePort("Input", Direction.Input, Port.Capacity.Multi);

            foreach (string choice in choices)
            {
                CreateChoicePort(choice);
            }

            this.CreateContextualMenu("AddChoice", actionEvent => CreateChoicePort("New Choice"));
        }

        private Port CreateChoicePort(string text)
        {
            Port port = CreatePort("", Direction.Output, Port.Capacity.Single);
            TextField choiceTextField = new TextField();
            port.contentContainer.Add(choiceTextField);

            port.CreateContextualMenu("RemoveChoice", actionEvent => RemoveChoicePort(port));
            RefreshExpandedState();
            return port;
        }

        private void RemoveChoicePort(Port port)
        {
            outputContainer.Remove(port);
            OutputPorts.Remove(port);
        }
    }
}