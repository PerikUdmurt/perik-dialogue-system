using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystem.NodePlayers.NodeHandlers
{
    public class ConditionalNodeHandler : BaseNodeHandler<ConditionalNode>
    {
        public ConditionalNodeHandler(IEventBus eventBus) : base(eventBus) { }

        public override void OnHandle(ConditionalNode node)
        {
            TriggerAllEvents(node);
        }
    }
}