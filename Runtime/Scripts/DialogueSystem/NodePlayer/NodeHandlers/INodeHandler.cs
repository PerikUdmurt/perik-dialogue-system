using SimpleDialogueSystem.DialogueSystemModel.Nodes;

namespace SimpleDialogueSystem.DialogueSystemModel.NodePlayers.NodeHandlers
{
    public interface INodeHandler
    {
        void HandleNode(INode node);
    };
}