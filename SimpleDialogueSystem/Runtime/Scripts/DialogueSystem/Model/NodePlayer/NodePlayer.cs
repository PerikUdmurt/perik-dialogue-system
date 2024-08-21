using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.Model.DialoguePlayer
{
    public class NodePlayer : BaseNodePlayer
    {
        private readonly BaseEventBus _eventBus;

        public NodePlayer(BaseEventBus eventBus) 
        { 
            _eventBus = eventBus;
        }

        public override void PlayNextNode()
        {
            
        }

        public override void PlayNode(BaseDialogueNode node)
        {
            
        }

        public override void SelectNode(int index)
        {
            
        }

        public override void StartDialogue(string id)
        {

        }
    }
}