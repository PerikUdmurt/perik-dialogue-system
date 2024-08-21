using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;

namespace SimpleDialogueSystem
{
    [Serializable]
    public class PhraseNode
    {
        
    }

    public abstract class BaseDialogueNode
    {
        public abstract void AddNode();
        public abstract void RemoveNode();
        public abstract List<BaseDialogueNode> GetNodes();
    }

    public class DialogueNode
    {

    }

    public interface IStartEventsHolder
    {
        public List<IEvent> GetStartEvents();
    }

    public interface IPostEventsHolder
    {
        public List<IEvent> GetPostEvents();
    }
}