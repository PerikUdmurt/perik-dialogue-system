using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.Infrastructure.NodePlayer.NodeHandlers;
using System;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer
{
    public sealed class NodePlayer : INodePlayer
    {
        private readonly BaseEventBus _eventBus;
        private Dictionary<string, INode> _nodes;
        private Dictionary<Type, INodeHandler> _nodeHandlers;

        public NodePlayer(BaseEventBus eventBus)
        {
            _eventBus = eventBus;
            _nodes = new Dictionary<string, INode>();

            _nodeHandlers = new Dictionary<Type, INodeHandler>()
            {
                [typeof(SimpleNode)] = new SimpleNodeHandler(_eventBus),
                [typeof(ChoiceNode)] = new ChoiceNodeHandler(_eventBus),
                [typeof(ConditionalNode)] = new ConditionalNodeHandler(_eventBus)
            };
        }

        public void PlayNode(string nodeID)
        {
            if (!_nodes.TryGetValue(nodeID, out INode node))
                throw new Exception($"Node with id {nodeID} is not founded in dictionary");

            Type nodeType = node.GetType();
            if (!_nodeHandlers.TryGetValue(nodeType, out INodeHandler handler))
                throw new Exception($"NodeHandler for type {nodeType.Name} is not founded");

            handler.HandleNode(node);
        }

        public void PlayNextNode()
        {

        }

        public void StartNodeGraph(string id)
        {

        }
    }
}

namespace SimpleDialogueSystem.Infrastructure.GraphProviders
{
    public class GraphProvider
    {

    }
}