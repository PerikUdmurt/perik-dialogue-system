using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public class EditorNodeFactory
    {
        private readonly NodeGraphView _graphView;
        public EditorNodeFactory(NodeGraphView graphView) 
        { 
            _graphView = graphView;
        }

        public T CreateEditorNode<T>(Vector2 position, List<IEvent> events = null, string id = null) where T : BaseEditorNode, new()
        {
            T node = new();
            node.Initialize(position, events, id);
            node.Draw();
            _graphView.AddElement(node);

            return node;
        }

        public NoteNode CreateNote(Vector2 position, string text)
        {
            NoteNode note = new NoteNode();
            note.Initialize(position, text);
            _graphView.AddElement(note);

            return note;
        }
    }
}