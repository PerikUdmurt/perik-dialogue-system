using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.PackageManager;
using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.EventBus
{
    public class BaseEventBus : IEventBus
    {
        protected private readonly Dictionary<Type, List<WeakReference<IBaseEventReceiver>>> _receivers;
        protected private readonly Dictionary<int, WeakReference<IBaseEventReceiver>> _receiversHashToReference;

        public BaseEventBus()
        {
            _receivers = new();
            _receiversHashToReference = new();
        }

        public void Register<TEvent>(IEventHandler<TEvent> receiver) where TEvent : IEvent
        {
            Type receiverType = typeof(TEvent);
            if (!_receivers.ContainsKey(receiverType))
                _receivers[receiverType] = new List<WeakReference<IBaseEventReceiver>>();

            WeakReference<IBaseEventReceiver> reference = new WeakReference<IBaseEventReceiver>(receiver);

            _receivers[receiverType].Add(reference);
            _receiversHashToReference[receiver.GetHashCode()] = reference;
            Debug.Log($"[EVENT BUS] Registered event handler {receiver.ToString()} for event {receiverType.Name}");
        }
        
        public void Unregister<TEvent>(IEventHandler<TEvent> reciever) where TEvent : IEvent
        {
            Type eventType = typeof(IEventHandler<TEvent>);
            int receiverHash = reciever.GetHashCode();
            if (!_receivers.ContainsKey(eventType) || _receiversHashToReference.ContainsKey(receiverHash))
                return;

            WeakReference<IBaseEventReceiver> reference = _receiversHashToReference[receiverHash];

            _receivers[eventType].Remove(reference);
            _receiversHashToReference.Remove(receiverHash);
            Debug.Log($"[EVENT BUS] Unregistered event handler {reciever.ToString()} for event {eventType.Name}");
        }

        public void Trigger<TEvent>(TEvent @event) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            if (!_receivers.ContainsKey(eventType))
                return;

            foreach (WeakReference<IBaseEventReceiver> reference in _receivers[eventType])
            {
                if (reference.TryGetTarget(out var receiver))
                {
                    ((IEventHandler<TEvent>)receiver).OnEvent(@event);
                    Debug.Log($"[EVENT BUS] Triggered event handler {receiver.ToString()} with event {eventType.Name}");
                }
            }
        }
    }   
}