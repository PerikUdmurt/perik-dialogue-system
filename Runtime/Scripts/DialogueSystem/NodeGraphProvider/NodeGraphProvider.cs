using SimpleDialogueSystem.DialogueSystem.Nodes;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Infrastructure.GraphProviders
{
    public class NodeGraphProvider : IGraphProvider
    {
        public Dictionary<string, INode> GetGraph(string id)
        {
            return new();
        }
    }
}