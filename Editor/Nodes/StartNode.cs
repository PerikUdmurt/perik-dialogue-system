using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public sealed class StartNode: BaseEditorNode
    {
        public override void Initialize(Vector2 position, List<IEvent> events = null, string id = null)
        {
            base.Initialize(position, events, id);
            CreatePort("Start", Direction.Output, Port.Capacity.Single);
        }

        public override void Draw()
        {
            DrawTitleContainer();
            DrawOutputContainer();
            RefreshExpandedState();
        }
    }
}