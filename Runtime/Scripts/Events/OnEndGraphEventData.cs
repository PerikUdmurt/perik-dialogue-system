using SimpleDialogueSystem.Infrastructure.EventBus;
using System;

namespace SimpleDialogueSystem.Events
{
    [NodeEvent("dev: stop dialogue"), Serializable]
    public struct OnEndGraphEventData : IEvent { }
}