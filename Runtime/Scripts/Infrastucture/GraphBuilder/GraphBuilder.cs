using SimpleDialogueSystem.Infrastructure.NodePlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.GraphProviders
{
    public class GraphBuilder
    {

    }

    public interface IGraphBuilder
    {
        Node GetGraph(string graphName);
    }
}