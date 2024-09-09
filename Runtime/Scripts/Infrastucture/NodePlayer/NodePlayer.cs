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
            if (_nodes.TryGetValue(nodeID, out Node node))
            {
                foreach ()
            }
        }

        public override void PlayNextNode()
        {
            
        }

        public override void StartDialogue(string id)
        {

        }
    }

    public class Node
    {
        private List<string> _nextNodes;
        private List<IEvent> _events;

        public Node(List<Node> nextNodes, List<IEvent> events)
        {
            _nextNodes = nextNodes;

            if (events == null)
                _events = new List<IEvent>();
            else
                _events = events;
        }

        public 
    }
}