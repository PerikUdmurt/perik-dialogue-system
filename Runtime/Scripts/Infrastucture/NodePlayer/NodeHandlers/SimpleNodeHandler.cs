using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer.NodeHandlers
{
    public class SimpleNodeHandler : BaseNodeHandler<SimpleNode>
    {
        public SimpleNodeHandler(BaseEventBus eventBus) : base(eventBus) { }

        public override void OnHandle(SimpleNode node)
        {
            TriggerAllEvents(node);
            
        }
    }
}