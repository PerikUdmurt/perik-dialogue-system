using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystem.NodePlayers.NodeHandlers
{
    public abstract class BaseNodeHandler<TNode> : INodeHandler where TNode : INode
    {
        protected private IEventBus _eventBus;

        public BaseNodeHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public abstract void OnHandle(TNode node);

        public virtual void HandleNode(INode node) =>
            OnHandle((TNode)node);


        protected void TriggerAllEvents(INode node) 
        {
            foreach (IEvent @event in node.Events)
                _eventBus.Trigger(@event);
        }
    }
}