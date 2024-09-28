using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer.NodeHandlers
{
    public class ChoiceNodeHandler : BaseNodeHandler<ChoiceNode>
    {
        public ChoiceNodeHandler(BaseEventBus eventBus) : base(eventBus) { }

        public override void OnHandle(ChoiceNode node)
        {
            TriggerAllEvents(node);
        }
    }
}