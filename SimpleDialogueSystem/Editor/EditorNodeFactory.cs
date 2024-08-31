using SimpleDialogueSystem.Editors.Nodes;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public class EditorNodeFactory
    {
        public T CreateEditorNode<T>(Vector2 position) where T : BaseNode, new()
        {
            T node = new();
            node.Initialize(position);
            node.Draw();

            return node;
        }
    }
}