using SimpleDialogueSystem.DialogueSystemModel.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystemModel.NodePlayers.NodeHandlers
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