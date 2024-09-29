using SimpleDialogueSystem.DialogueSystem.NodePlayers;
using SimpleDialogueSystem.DialogueSystem.Nodes;
using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.Infrastructure.GraphProviders;
using System.Collections.Generic;

namespace SimpleDialogueSystem.DialogueSystem.GraphPlayers
{
    public class DialoguePlayer : IGraphPlayer, IOnPlayGraphHandler
    {
        private readonly IEventBus _eventBus;
        private readonly IGraphProvider _graphProvider;

        private INodePlayer _nodePlayer;

        public DialoguePlayer(IEventBus eventBus ,IGraphProvider graphProvider)
        {
            _eventBus = eventBus;
            _graphProvider = graphProvider;
        }

        public void OnEvent(OnPlayGraphEventData @event) =>
            StartGraph(@event.graphID);

        public void PlayNextNode() => _nodePlayer.PlayNextNode();

        public void PlayNode(string nodeId) => _nodePlayer.PlayNode(nodeId);

        public void StartGraph(string graphId)
        {
            Dictionary<string, INode> graph = _graphProvider.GetGraph(graphId);
            _nodePlayer = new NodePlayer(_eventBus, graph);
        }

        public void StartGraphFromNode(string graphId, string node)
        {
            StartGraph(graphId);
            _nodePlayer.PlayNode(node);
        }
    }
}
