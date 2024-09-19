using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using UnityEngine;

namespace SimpleDialogueSystem.Events
{
    public interface OnPlayPhraseHandler : IEventHandler<OnPlayPhraseEventData> { }
    public interface OnPlayDialogueHandler : IEventHandler<OnPlayDialogueEventData> { }
    public interface OnEndDialogueHandler : IEventHandler<OnShowChoicesEventData> { }
    public interface OnDisplayChangedHandler : IEventHandler<OnDisplayChangedEventData> { }

    [NodeEvent("Проиграть фразу", "#C8C814"), Serializable]
    public struct OnPlayPhraseEventData: IEvent
    {
        public string text;
    }

    [NodeEvent("Начать диалог", "f34723"), Serializable]
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
    
    [NodeEvent("Получить очки"), Serializable]
    public struct OnAddScore : IEvent
    {
        public int score;
    }
}