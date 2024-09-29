using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using UnityEngine;

namespace SimpleDialogueSystem.Events
{
    public interface IOnEndDialogueHandler : IEventHandler<OnShowChoicesEventData> { }

    [NodeEvent("Показать выбор"), Serializable]
    public struct OnShowChoicesEventData : IEvent
    {

    }
}