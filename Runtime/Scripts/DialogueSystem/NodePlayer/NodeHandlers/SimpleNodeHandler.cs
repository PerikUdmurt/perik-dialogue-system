using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystem.NodePlayers.NodeHandlers
{
    public class SimpleNodeHandler : BaseNodeHandler<SimpleNode>
    {
        public SimpleNodeHandler(IEventBus eventBus) : base(eventBus) { }

        public override void OnHandle(SimpleNode node)
        {
            TriggerAllEvents(node);
            
        }
    }
}