using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;

namespace SimpleDialogueSystem.DialogueSystemModel.Nodes
{
    public sealed class ChoiceNode : INode
    {
        public List<IEvent> Events => throw new System.NotImplementedException();
    }
}
