using SimpleDialogueSystem.DialogueSystemModel.Nodes;
using System.Collections.Generic;

namespace SimpleDialogueSystem.Infrastructure.GraphProviders
{
    public interface IGraphProvider
    {
        Dictionary<string, INode> GetGraph(string id);
    }
}