using SimpleDialogueSystem.DialogueSystem.NodePlayers;

namespace SimpleDialogueSystem.DialogueSystem.GraphPlayers
{
    public interface IGraphPlayer: INodePlayer
    {
        void StartGraph(string graphId);
        void StartGraphFromNode(string graphId, string node);
    }
}