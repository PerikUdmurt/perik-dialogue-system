using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.EventBus
{
    public interface IEventHandler<T> : IBaseEventReceiver where T : struct, IEvent
    {
        void OnEvent(T @event);
    }
}