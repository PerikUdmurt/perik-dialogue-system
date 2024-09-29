using SimpleDialogueSystem.DialogueSystemModel.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystemModel.NodePlayers.NodeHandlers
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