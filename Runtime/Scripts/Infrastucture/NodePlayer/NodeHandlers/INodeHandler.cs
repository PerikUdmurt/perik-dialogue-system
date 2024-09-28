using SimpleDialogueSystem.DialogueSystem.Nodes;

namespace SimpleDialogueSystem.Infrastructure.NodePlayer.NodeHandlers
{
    public interface INodeHandler
    {
        void HandleNode(INode node);
    };
}