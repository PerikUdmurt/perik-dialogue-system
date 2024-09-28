namespace SimpleDialogueSystem.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Register<T>(IEventHandler<T> receiver) where T : IEvent;
        void Trigger<T>(T @event) where T : IEvent;
        void Unregister<T>(IEventHandler<T> reciever) where T : IEvent;
    }
}