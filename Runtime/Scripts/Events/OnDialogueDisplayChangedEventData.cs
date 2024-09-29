using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Events
{
    [NodeEvent("Настройки диалогового окна"), System.Serializable]
    public struct OnDialogueDisplayChangedEventData: IEvent
    {

    }

    public interface IOnDialogueDisplayChangedHandler : IEventHandler<OnDialogueDisplayChangedEventData> { }
}