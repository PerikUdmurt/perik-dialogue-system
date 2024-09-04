using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors
{
    public class EventContainer : VisualElement
    {
        public EventContainer(IEvent @event) : base()
        {
            GetEventType(@event, out Type eventType, out Color borderColor, out string eventName);

            DrawContainer(eventName, @event);

            SetStyles(borderColor);
        }

        private static void GetEventType(IEvent @event, out Type eventType, out Color borderColor, out string eventName)
        {
            eventType = @event.GetType();
            NodeEventAttribute attribute = (NodeEventAttribute)eventType.GetCustomAttribute(typeof(NodeEventAttribute));
            (float, float, float, float) rgba = attribute.Rgba;
            borderColor = new Color(rgba.Item1, rgba.Item2, rgba.Item3, rgba.Item4);
            eventName = attribute.Name;
        }

        private void DrawContainer(string name, IEvent @event)
        {
            Foldout foldout = new Foldout()
            {
                text = name
            };

            this.Add(foldout);
        }

        private void SetStyles(Color leftBorderColor)
        {
            AddToClassList("ds-node__custom-data-container");
            style.borderLeftWidth = 5;
            style.borderLeftColor = leftBorderColor;
        }
    }
}