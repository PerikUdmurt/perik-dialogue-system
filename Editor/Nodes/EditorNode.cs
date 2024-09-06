using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class EditorNode : BaseNode
    {
        private Port _inputPort;
        private Port _outputPort;

        public Port InputPort { get => _inputPort; }
        public Port OutputPort { get => _outputPort; }

        public string ID {  get; set; }
        public override string NodeName { get; set; }
        public List<IEvent> Events { get; set; }

        public void Initialize(Vector2 position, List<IEvent> events)
        {
            ID = Guid.NewGuid().ToString();
            NodeName = "Dialogue";
            Events = new();

            _outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
            _inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));

            foreach (IEvent @event in events)
            {
                CreateEvent(@event);
            }

            SetPosition(new Rect(position, Vector2.zero));

            SetStyles();
        }

        private void SetStyles()
        {
            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }

        public override void Draw()
        {
            DrawTitleContainer();
            DrawInputContainer();
            DrawOutputContainer();
            DrawExtensionContainer();
            RefreshExpandedState();
        }

        private void DrawInputContainer()
        {
            _inputPort.portName = "Input";

            inputContainer.Add(_inputPort);
        }

        private void DrawOutputContainer()
        {
            _outputPort.portName = "Output";

            outputContainer.Add(_outputPort);
            outputContainer.Add(_outputPort);
        }
        
        private void DrawExtensionContainer()
        {
            DropdownField dropdownField = AddEventDropdownField();

            AddCreateEventButton(dropdownField);
        }

        private void AddCreateEventButton(DropdownField dropdownField)
        {
            Button addbutton = MyElementUtility.AddButton("AddEvent");
            addbutton.clicked += () => CreateEventByType(dropdownField.value);

            extensionContainer.Add(addbutton);
        }

        private DropdownField AddEventDropdownField()
        {
            List<string> names = EventFinder.EventNames;

            DropdownField dropdownField = new DropdownField(names, 1);
            extensionContainer.Add(dropdownField);
            return dropdownField;
        }

        private void CreateEventByType(string eventName)
        {
            if (EventFinder.TryGetEventType(eventName, out var type))
            {
                Debug.Log(type.FullName);
                IEvent @event = (IEvent)Activator.CreateInstance(type);
                
                CreateEvent(@event);
            }
        }

        private void CreateEvent(IEvent @event)
        {
            Events.Add(@event);
            DrawEventContainer(@event);
        }

        private void RemoveEvent(EventContainer container)
        {
            extensionContainer.Remove(container);
        }

        private void DrawEventContainer(IEvent @event)
        {
            EventContainer eventContainer = new EventContainer(@event);
            extensionContainer.Add(eventContainer);

            Button removeButton = MyElementUtility.AddButton("Remove");
            removeButton.clicked += () => RemoveEvent(eventContainer);
            eventContainer.Add(removeButton);
            RefreshExpandedState();
        }

        private void DrawTitleContainer()
        {
            TextField testTextField = MyElementUtility.AddTextField("NodeName",NodeName);
            titleContainer.Insert(0, testTextField);
        }
    }
}