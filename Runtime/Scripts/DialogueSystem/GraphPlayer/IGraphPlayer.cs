using SimpleDialogueSystem.DialogueSystemModel.NodePlayers;

namespace SimpleDialogueSystem.DialogueSystemModel.GraphPlayers
{
    public interface IGraphPlayer: INodePlayer
    {
        void StartGraph(string graphId);
        void StartGraphFromNode(string graphId, string node);
    }
}