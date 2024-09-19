using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer
{
    public class NodePlayer : BaseNodePlayer
    {
        private readonly BaseEventBus _eventBus;
        private Dictionary<string, Node> _nodes;

        public NodePlayer(BaseEventBus eventBus) 
        { 
            _eventBus = eventBus;
            _nodes = new Dictionary<string, Node>();
        }

        public void PlayNode(string nodeID)
        {
            
        }

        public override void PlayNextNode()
        {
            
        }

        public override void StartDialogue(string id)
        {

        }

        public override void SelectNode(int index)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Node
    {
        private List<string> _nextNodes;
        private List<IEvent> _events;
    }
}