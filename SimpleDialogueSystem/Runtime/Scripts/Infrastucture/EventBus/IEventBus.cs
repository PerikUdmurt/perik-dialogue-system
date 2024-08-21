namespace SimpleDialogueSystem.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Register<T>(IEventHandler<T> receiver) where T : struct, IEvent;
        void Trigger<T>(T @event) where T : struct, IEvent;
        void Unregister<T>(IEventHandler<T> reciever) where T : struct, IEvent;
    }
}