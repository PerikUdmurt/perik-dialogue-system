using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public abstract class BaseNode: Node
    {
        public abstract void Initialize(Vector2 position);
        public abstract string NodeName { get; set; }
        public abstract void Draw();
    }
}