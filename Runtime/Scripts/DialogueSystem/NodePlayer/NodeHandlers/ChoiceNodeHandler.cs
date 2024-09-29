using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystem.NodePlayers.NodeHandlers
{
    public class ChoiceNodeHandler : BaseNodeHandler<ChoiceNode>
    {
        public ChoiceNodeHandler(IEventBus eventBus) : base(eventBus) { }

        public override void OnHandle(ChoiceNode node)
        {
            TriggerAllEvents(node);
        }
    }
}