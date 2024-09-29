using SimpleDialogueSystem.DialogueSystem.Nodes;

namespace SimpleDialogueSystem.DialogueSystem.NodePlayers.NodeHandlers
{
    public interface INodeHandler
    {
        void HandleNode(INode node);
    };
}