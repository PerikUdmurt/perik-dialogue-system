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

    [NodeEvent("Начало фразы", 250,230,220,1), Serializable]
    public struct OnBeginPhraseEventData: IEvent
    {
        public int a;
        public BlockData currentBlockData;
    }


    public struct OnEndPhraseEventData: IEvent
    {
        public BlockData currentBlockData;
        public List<PhraseNode> nextPhrases;
    }

    [NodeEvent("Начало диалога", 245, 40, 145, 0.8f), Serializable]
    public struct OnBeginDialogueEventData: IEvent
    {
        
    }

    public struct OnEndDialogueEventData : IEvent
    {

    }

    public struct OnDisplayChangedEventData: IEvent
    {

    }
}