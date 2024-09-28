using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;

namespace SimpleDialogueSystem.DialogueSystem.Nodes
{
    public interface INode
    {
        public List<IEvent> Events { get; }
    }
}
