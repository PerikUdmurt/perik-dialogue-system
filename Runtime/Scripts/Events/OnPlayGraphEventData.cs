using SimpleDialogueSystem.Infrastructure.EventBus;
using System;

namespace SimpleDialogueSystem.Events
{
    [NodeEvent("Начать диалог", "f34723"), Serializable]
    public struct OnPlayGraphEventData: IEvent
    {
        public string graphID;
    }

    public interface IOnPlayGraphHandler : IEventHandler<OnPlayGraphEventData> { }
}