using System;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Infrastructure.EventBus
{
    // IEventBus
    public class BaseEventBus
    {
        protected private readonly Dictionary<Type, List<WeakReference<IBaseEventReceiver>>> _receivers;
        protected private readonly Dictionary<int, WeakReference<IBaseEventReceiver>> _receiversHashToReference;

        public BaseEventBus()
        {
            _receivers = new();
            _receiversHashToReference = new();
        }

        public void Register<TEvent>(IEventHandler<TEvent> receiver) where TEvent : struct, IEvent
        {
            Type receiverType = typeof(IEventHandler<TEvent>);
            if (!_receivers.ContainsKey(receiverType))
                _receivers[receiverType] = new List<WeakReference<IBaseEventReceiver>>();

            WeakReference<IBaseEventReceiver> reference = new WeakReference<IBaseEventReceiver>(receiver);

            _receivers[receiverType].Add(reference);
            _receiversHashToReference[receiver.GetHashCode()] = reference;
        }
        
        public void Unregister<T>(IEventHandler<T> reciever) where T : struct, IEvent
        {
            Type eventType = typeof(T);
            int receiverHash = reciever.GetHashCode();
            if (!_receivers.ContainsKey(eventType) || _receiversHashToReference.ContainsKey(receiverHash))
                return;

            WeakReference<IBaseEventReceiver> reference = _receiversHashToReference[receiverHash];

            _receivers[eventType].Remove(reference);
            _receiversHashToReference.Remove(receiverHash);
        }

        public void Trigger<TEvent>(TEvent @event) where TEvent : struct, IEvent
        {
            Type eventType = typeof(TEvent);
            if (!_receivers.ContainsKey(eventType))
                return;

            foreach (WeakReference<IBaseEventReceiver> reference in _receivers[eventType])
            {
                if (reference.TryGetTarget(out var receiver))
                    ((IEventHandler<TEvent>)receiver).OnEvent(@event);
            }
        }
    }   
}