using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.Model.DialoguePlayer;

namespace SimpleDialogueSystem.Model
{
    public class DialogueModel
    {
        private BaseEventBus _eventBus;
        private BaseNodePlayer _nodePlayer;

        public DialogueModel() 
        { 
            _eventBus = new BaseEventBus();
            _nodePlayer = new NodePlayer(_eventBus);
        }
        
        public void Register<T>(IEventHandler<T> eventReceiver) where T: struct, IEvent
            => _eventBus.Register(eventReceiver);
        public void Unregister<T>(IEventHandler<T> eventReceiver) where T : struct, IEvent
            => _eventBus.Unregister(eventReceiver);
        
        public void StartDialogue(string id)
            => _nodePlayer.StartDialogue(id);

        public void SelectNode(int index)
            => _nodePlayer.SelectNode(index);

        public void PlayNode(BaseDialogueNode node)
            => _nodePlayer.PlayNode(node);

        public void PlayNextNode()
            => _nodePlayer.PlayNextNode();
    }

    public class BaseDialogueNode
    {
    }
}