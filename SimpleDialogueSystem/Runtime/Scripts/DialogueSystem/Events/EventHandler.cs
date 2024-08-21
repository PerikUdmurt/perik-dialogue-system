using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Events
{
    public interface OnBeginPhraseHandler : IEventHandler<OnBeginPhraseEventData> { }
    public interface OnEndPhraseHandler : IEventHandler<OnEndPhraseEventData> { }
    public interface OnBeginDialogueHandler : IEventHandler<OnBeginDialogueEventData> { }
    public interface OnEndDialogueHandler : IEventHandler<OnEndDialogueEventData> { }
    public interface OnDisplayChangedHandler : IEventHandler<OnDisplayChangedEventData> { }

    public struct OnBeginPhraseEventData: IEvent
    {
        public BlockData currentBlockData;
    }

    public struct OnEndPhraseEventData: IEvent
    {
        public BlockData currentBlockData;
        public List<PhraseNode> nextPhrases;
    }

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