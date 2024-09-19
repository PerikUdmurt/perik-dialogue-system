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

            GetEventType(@event, out Type eventType, out string eventName, out string hex);

            DrawContainer(eventName, ref @event);

            SetStyles(hex);
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

        private void SetStyles(string hexcode)
        {
            AddToClassList("ds-node__custom-data-container");
            style.borderLeftWidth = 5;
            style.borderLeftColor = SetSideColor(hexcode);
        }

        private static Color SetSideColor(string hexcode)
        {
            ColorUtility.TryParseHtmlString(hexcode, out Color color);
            return color;
        }

        private void GetEventType(IEvent @event, out Type eventType, out string eventName, out string hex)
        {
            eventType = @event.GetType();
            NodeEventAttribute attribute = (NodeEventAttribute)eventType.GetCustomAttribute(typeof(NodeEventAttribute));
            eventName = attribute.Name;
            hex = attribute.Hex;
        }
    }
}