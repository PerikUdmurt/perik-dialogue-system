﻿using SimpleDialogueSystem.Infrastructure.EventBus;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class EditorNode : BaseEditorNode
    { 
        public override void Initialize(Vector2 position, List<IEvent> events = null, string id = null)
        {
            base.Initialize(position, events, id);
            CreatePort("Input", Direction.Input, Port.Capacity.Multi);
            CreatePort("Output", Direction.Output, Port.Capacity.Multi);
        }

        public override void Draw()
        {
            DrawTitleContainer();
            DrawInputContainer();
            DrawOutputContainer();
            DrawExtensionContainer();
            RefreshExpandedState();
        }
    }
}