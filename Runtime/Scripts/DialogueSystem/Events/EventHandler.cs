using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Events
{
    public interface OnBeginPhraseHandler : IEventHandler<OnBeginPhraseEventData> { }
    public interface OnEndPhraseHandler : IEventHandler<OnEndPhraseEventData> { }
    public interface OnBeginDialogueHandler : IEventHandler<OnBeginDialogueEventData> { }
    public interface OnEndDialogueHandler : IEventHandler<OnEndDialogueEventData> { }
    public interface OnDisplayChangedHandler : IEventHandler<OnDisplayChangedEventData> { }

    [NodeEvent("Начало фразы"), Serializable]
    public struct OnBeginPhraseEventData: IEvent
    {
        public int a;
        public List<int> intlist;
        public string str;
        public float f;
        public OnBeginDialogueEventData ghghfhfl;
    }


    public struct OnEndPhraseEventData: IEvent
    {
    }

    [NodeEvent("Начало диалога"), Serializable]
    public struct OnBeginDialogueEventData: IEvent
    {
        public my my;
    }

    public struct OnEndDialogueEventData : IEvent
    {

    }

    public struct OnDisplayChangedEventData: IEvent
    {

    }

    public enum my
    {
        None = 0,
        ghghgj = 1,
    }
}