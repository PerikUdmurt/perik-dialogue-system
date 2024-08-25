using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            NodeName = "dialogue";
            Events = new List<IEvent>();

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
        Dictionary<string, Type> eventTypes = new Dictionary<string, Type>();
        List<string> eventNames = new List<string>();
        private void DrawExtensionContainer()
        {
            Assembly assembly = Assembly.Load("Assembly-CSharp-firstpass");

            Debug.Log(assembly.FullName);

            var events = from m in assembly.GetTypes()
                         from a in m.GetCustomAttributes(typeof(NodeEventAttribute), false)
                         select m;
            

            foreach (var eventType in events)
            {
                NodeEventAttribute attribute = (NodeEventAttribute)eventType.GetCustomAttribute(typeof(NodeEventAttribute));
                eventTypes.Add(attribute.Name, eventType);
                eventNames.Add(attribute.Name);
            }

            DropdownField dropdownField = new DropdownField(eventNames, 1);
            extensionContainer.Add(dropdownField);
            Button addbutton = MyElementUtility.AddButton("AddEvent");
            addbutton.clicked += () => CreateEvent(dropdownField.value);

            extensionContainer.Add(addbutton);
        }

        private void CreateEvent(string eventName)
        {
            if (eventTypes.TryGetValue(eventName, out var type))
            {
                Debug.Log(type.FullName);
                IEvent @event = (IEvent)Activator.CreateInstance(type);

                Events.Add(@event);
                DrawEventContainer(@event);
            }
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