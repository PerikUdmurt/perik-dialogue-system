using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;

namespace SimpleDialogueSystem.DialogueSystemModel.Nodes
{
    public interface INode
    {
        public List<IEvent> Events { get; }
    }
}
