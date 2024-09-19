using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class NoteNode : StickyNote
    {
        public void Initialize(Vector2 position, string text)
        {
            new Rect(position, Vector2.zero);
            contents = text;
        }
    }
}