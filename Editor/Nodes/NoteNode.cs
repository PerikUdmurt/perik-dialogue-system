using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class NoteNode: BaseEditorNode
    {
        public override void Initialize(Vector2 position, List<IEvent> events = null, string id = null)
        {
            base.Initialize(position, events, id);
        }

        public override void Draw()
        {
            DrawTitleContainer();
            DrawExtensionContainer();
            RefreshExpandedState();
        }
    }
}