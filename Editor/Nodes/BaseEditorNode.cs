using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class BaseEditorNode : BaseNode
    {
        protected override string nodeName { get => "EditorNode"; }
        protected VisualElement eventsContainer;
        private List<Port> _inputPorts;
        private List<Port> _outputPorts;

        public List<Port> InputPorts { get => _inputPorts; }
        public List<Port> OutputPorts { get => _outputPorts; }
        public string ID { get; set; }
        public List<IEvent> Events { get; set; }

        public virtual void Initialize(Vector2 position, List<IEvent> events = null, string id = null)
        {
            _inputPorts = new List<Port>();
            _outputPorts = new List<Port>();

            if (id == null)
                ID = Guid.NewGuid().ToString();
            else ID = id;

            eventsContainer = new VisualElement();

            Events = new();
            if (events != null)
            {
                foreach (IEvent @event in events)
                {
                    CreateEvent(@event);
                }
            }

            SetPosition(new Rect(position, Vector2.zero));

            SetStyles();
        }
        public override void Draw()
        {

        }

        protected Port CreatePort(string portName, Direction direction, Port.Capacity capacity)
        {
            Port port = InstantiatePort(Orientation.Horizontal, direction, capacity, typeof(bool));
            port.portName = portName;

            if (direction == Direction.Output)
                _outputPorts.Add(port);

            if (direction == Direction.Input)
                _inputPorts.Add(port);

            return port;
        }

        protected virtual void DrawOutputContainer()
        {
            foreach (var port in _outputPorts)
                outputContainer.Add(port);
        }

        protected virtual void DrawInputContainer()
        {
            foreach (var port in _inputPorts)
                inputContainer.Add(port);
        }

        private void SetStyles()
        {
            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }

        protected virtual void DrawEventContainer(IEvent @event)
        {
            EventContainer eventContainer = new EventContainer(ref @event);
            eventsContainer.Add(eventContainer);

            Button removeButton = MyElementUtility.AddButton("Remove");
            removeButton.clicked += () => RemoveEventContainer(eventContainer);
            eventContainer.Add(removeButton);
            RefreshExpandedState();
        }

        protected virtual void DrawTitleContainer()
        {
            Label label = new Label(nodeName);
            titleContainer.Insert(0, label);
        }



        protected virtual void DrawExtensionContainer()
        {
            DropdownField dropdownField = AddEventDropdownField();
            AddCreateEventButton(dropdownField);
            extensionContainer.Add(eventsContainer);
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

        private void RemoveEventContainer(EventContainer container)
        {
            eventsContainer.Remove(container);
            Events.Remove(container.Event);
        }
    }
}