using SimpleDialogueSystem.Editors.Nodes;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.Editors.Error
{
    public class ErrorData
    {
        public Color Color { get; set; }

        private void GenerateRandomColor()
        {
            Color = new Color32(
                (byte)Random.Range(65, 256),
                (byte)Random.Range(50, 176),
                (byte)Random.Range(50, 176),
                255);
        }
    }

    public class NodeErrorData
    {
        public ErrorData ErrorData { get; set; }
        public List<EditorNode> Nodes { get; set; }

        public NodeErrorData(ErrorData errorData, List<EditorNode> nodes)
        {
            ErrorData = errorData;
            Nodes = nodes;
        }
    }
}