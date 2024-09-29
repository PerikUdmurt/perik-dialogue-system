using SimpleDialogueSystem.DialogueSystem.NodePlayers.NodeHandlers;
using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;

namespace SimpleDialogueSystem.DialogueSystem.NodePlayers
{
    public sealed class NodePlayer : INodePlayer
    {
        private readonly IEventBus _eventBus;
        private Dictionary<string, INode> _nodes;
        private Dictionary<Type, INodeHandler> _nodeHandlers;

        public NodePlayer(IEventBus eventBus, Dictionary<string, INode> nodes)
        {
            _eventBus = eventBus;
            _nodes = nodes;

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
    }
}