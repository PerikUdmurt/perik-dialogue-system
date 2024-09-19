using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public static class EventFinder
    {
        private static Dictionary<string, Type> _eventTypes;
        private static List<string> _eventNames;

        static EventFinder()
        {
            _eventNames = new List<string>();
            _eventTypes = new Dictionary<string, Type>();
            FindEvents();
        }

        public static List<string> EventNames { get => _eventNames; }

        public static bool TryGetEventType(string eventName, out Type eventType)
        {
            if (_eventTypes.TryGetValue(eventName, out Type resultType))
            {
                eventType = resultType;
                return true;
            }
            eventType = null;
            return false;
        }

        private static void FindEvents()
        {
            Assembly assembly = Assembly.Load("Assembly-CSharp-firstpass");

            Debug.Log(assembly.FullName);

            var events = from m in assembly.GetTypes()
                         from a in m.GetCustomAttributes(typeof(NodeEventAttribute), false)
                         select m;


            foreach (var eventType in events)
            {
                NodeEventAttribute attribute = (NodeEventAttribute)eventType.GetCustomAttribute(typeof(NodeEventAttribute));
                _eventTypes.Add(attribute.Name, eventType);
                _eventNames.Add(attribute.Name);
            }
        }
}
}