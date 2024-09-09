using SimpleDialogueSystem.Infrastructure.NodePlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.GraphBuilder
{
    public class GraphBuilder : IGraphBuilder
    {

    }

    public interface IGraphBuilder
    {
        Node GetGraph(string graphName);
    }
}