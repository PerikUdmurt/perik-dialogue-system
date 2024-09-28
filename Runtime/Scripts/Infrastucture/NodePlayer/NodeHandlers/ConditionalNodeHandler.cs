using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer.NodeHandlers
{
    public class ConditionalNodeHandler : BaseNodeHandler<ConditionalNode>
    {
        public ConditionalNodeHandler(BaseEventBus eventBus) : base(eventBus) { }

        public override void OnHandle(ConditionalNode node)
        {
            TriggerAllEvents(node);
        }
    }
}