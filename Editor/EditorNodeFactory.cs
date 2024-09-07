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

        public T CreateEditorNode<T>(Vector2 position, List<IEvent> events, string id = null) where T : BaseEditorNode, new()
        {
            T node = new();
            node.Initialize(position, events, id);
            node.Draw();
            _graphView.AddElement(node);

            return node;
        }
    }
}