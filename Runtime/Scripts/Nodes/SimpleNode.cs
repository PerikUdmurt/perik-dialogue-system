using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;

namespace SimpleDialogueSystem.DialogueSystem.Nodes
{
    public sealed class SimpleNode : INode
    {
        public List<IEvent> Events => throw new System.NotImplementedException();
    }
}
