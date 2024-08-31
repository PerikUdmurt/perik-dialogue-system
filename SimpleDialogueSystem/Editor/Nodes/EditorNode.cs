using CodiceApp.EventTracking.Plastic;
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
    public class EditorNode : BaseNode
    {
        public override string NodeName { get; set; }
        public List<IEvent> Events { get; set; }

        public override void Initialize(Vector2 position)
        {
            Initialize(position, new());
        }

        public void Initialize(Vector2 position, List<IEvent> events)
        {
            NodeName = "Dialogue";
            Events = new();

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
            Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));

            inputPort.portName = "Input";

            inputContainer.Add(inputPort);
        }

        private void DrawOutputContainer()
        {
            Port outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));

            outputPort.portName = "Output";

            outputContainer.Add(outputPort);
            outputContainer.Add(outputPort);
        }

        //Поиск ивентов через рефлексию в отдельный класс
        
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