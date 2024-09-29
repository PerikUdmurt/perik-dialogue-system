using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Events
{
    [NodeEvent("Проиграть фразу", "#C8C814"), System.Serializable]
    public struct OnPlayPhraseEventData: IEvent
    {
        public BlockData blockData;
    }
}