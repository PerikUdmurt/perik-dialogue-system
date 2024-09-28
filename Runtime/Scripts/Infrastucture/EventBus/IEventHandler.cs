using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.EventBus
{
    public interface IEventHandler<T> : IBaseEventReceiver where T : IEvent
    {
        void OnEvent(T @event);
    }
}