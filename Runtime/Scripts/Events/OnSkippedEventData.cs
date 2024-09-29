using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Events
{
    [NodeEvent("dev: skip"), System.Serializable]
    public struct OnSkippedEventData : IEvent { }
}