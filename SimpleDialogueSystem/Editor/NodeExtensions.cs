using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.StaticDatas;

namespace SimpleDialogueSystem.Editors
{
    public static class NodeExtensions
    {
        public static DialogueNode ToDialogueNode(this EditorNode editorNode)
            => new DialogueNode()
            {
                ID = editorNode.ID,
                Position = editorNode.GetPosition().position,
                NextNodesID = new(),
                Events = editorNode.Events
            };
    }
}