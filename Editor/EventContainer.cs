using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors
{
    public class EventContainer : VisualElement
    {
        public IEvent Event { get; private set; }

        public EventContainer(ref IEvent @event) : base()
        {
            Event = @event;

            GetEventType(@event, out Type eventType, out string eventName);

            DrawContainer(eventName, ref @event);

            SetStyles();
        }

        public virtual void DrawContainer(string name, ref IEvent @event)
        {
            Foldout foldout = new Foldout()
            {
                text = name
            };

            object obj = @event;
            foldout.DrawProperties(ref obj);

            this.Add(foldout);
        }

        private void SetStyles()
        {
            AddToClassList("ds-node__custom-data-container");
            style.borderLeftWidth = 5;
            style.borderLeftColor = Color.red;
        }

        private void GetEventType(IEvent @event, out Type eventType, out string eventName)
        {
            eventType = @event.GetType();
            NodeEventAttribute attribute = (NodeEventAttribute)eventType.GetCustomAttribute(typeof(NodeEventAttribute));
            eventName = attribute.Name;
        }
    }
}