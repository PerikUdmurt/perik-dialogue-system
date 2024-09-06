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

        public EditorNode CreateEditorNode(Vector2 position, List<IEvent> events, string id = null)
        {
            EditorNode node = new();
            node.Initialize(position, events, id);
            node.Draw();
            _graphView.AddElement(node);

            return node;
        }

        public NoteNode CreateEditorNode(Vector2 position, string text = "")
        {
            NoteNode node = new();
            node.Initialize(position, text);
            node.Draw();
            _graphView.AddElement(node);

            return node;
        }
    }
}