using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer.NodeHandlers
{
    public abstract class BaseNodeHandler<TNode> : INodeHandler where TNode : INode
    {
        protected private BaseEventBus _eventBus;

        public BaseNodeHandler(BaseEventBus eventBus)
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