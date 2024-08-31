using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem
{
    [Serializable]
    public class PhraseNode
    {
        List<IEvent> Events = new List<IEvent>();

    }

    public abstract class BaseDialogueNode
    {
        public List<IEvent> Events { get; }
        public abstract void AddNode();
        public abstract void RemoveNode();
        public abstract List<BaseDialogueNode> GetNodes();
    }

    public class DialogueNode: MonoBehaviour
    {

    }
}