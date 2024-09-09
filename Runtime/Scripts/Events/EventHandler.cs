using SimpleDialogueSystem.Infrastructure.EventBus;
using System;

namespace SimpleDialogueSystem.Events
{
    public interface OnPlayPhraseHandler : IEventHandler<OnPlayPhraseEventData> { }
    public interface OnPlayDialogueHandler : IEventHandler<OnPlayDialogueEventData> { }
    public interface OnEndDialogueHandler : IEventHandler<OnShowChoicesEventData> { }
    public interface OnDisplayChangedHandler : IEventHandler<OnDisplayChangedEventData> { }

    [NodeEvent("Проиграть фразу"), Serializable]
    public struct OnPlayPhraseEventData: IEvent
    {
        public string text;
    }

    [NodeEvent("Начать диалог"), Serializable]
    public struct OnPlayDialogueEventData: IEvent
    {
        public string dialogueName;
    }

    [NodeEvent("Показать выбор"), Serializable]
    public struct OnShowChoicesEventData : IEvent
    {

    }

    [NodeEvent("Настройки диалогового окна"), Serializable]
    public struct OnDisplayChangedEventData: IEvent
    {

    }
}