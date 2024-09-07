using UnityEditor.Experimental.GraphView;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public abstract class BaseNode: Node
    {
        protected virtual string nodeName { get => "Node"; }
        public abstract void Draw();
    }
}