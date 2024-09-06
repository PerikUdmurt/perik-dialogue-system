using UnityEditor.Experimental.GraphView;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public abstract class BaseNode: Node
    {
        public abstract string NodeName { get; set; }
        public abstract void Draw();
    }
}