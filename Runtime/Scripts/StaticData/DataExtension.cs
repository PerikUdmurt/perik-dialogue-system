using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    public static class DataExtension
    {
        public static EventStaticData ToEventStaticData(this IEvent @event)
        {
            return new EventStaticData()
            {
                typeName = @event.GetType().FullName,
                json = JsonUtility.ToJson(@event, true)
            };
        }

        public static IEvent FromEventStaticData(this EventStaticData staticData)
            => JsonUtility.FromJson(staticData.json, Type.GetType(staticData.typeName)) as IEvent;

        public static List<IEvent> ToEventList(this List<EventStaticData> staticDatas)
        {
            List<IEvent> events = new List<IEvent>();

            foreach (var eventData in staticDatas)
            {
                IEvent @event = eventData.FromEventStaticData();
                events.Add(@event);
            }

            return events;
        }

        public static Vector2Data ToVector2Data(this Vector2 vector)
            => new Vector2Data(vector.x, vector.y);

        public static Vector2 ToVector2(this Vector2Data vectorData)
            => new Vector2(vectorData.x, vectorData.y);
    }
}