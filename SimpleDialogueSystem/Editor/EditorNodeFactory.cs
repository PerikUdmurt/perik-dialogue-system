using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public class EditorNodeFactory
    {
        public EditorNode CreateEditorNode(Vector2 position, List<IEvent> events)
        {
            EditorNode node = new();
            node.Initialize(position, events);
            node.Draw();

            return node;
        }

        public NoteNode CreateEditorNode(Vector2 position, string text = "")
        {
            NoteNode node = new();
            node.Initialize(position, text);
            node.Draw();

            return node;
        }
    }
}