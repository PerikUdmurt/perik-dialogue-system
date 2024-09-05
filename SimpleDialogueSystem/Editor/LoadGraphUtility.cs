using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace SimpleDialogueSystem.Editors
{
    public static class LoadGraphUtility
    {
        private static NodeGraphView _graphView;
        private static DialogueStaticData _dialogueStaticData;
        private static Dictionary<DialogueNode, EditorNode> _createdNodes;

        public static void Load(DialogueStaticData dialogueStaticData, NodeGraphView nodeGraphView)
        {
            _createdNodes = new Dictionary<DialogueNode, EditorNode>();
            _dialogueStaticData = dialogueStaticData;
            _graphView = nodeGraphView;

            CreateEditorNodes();
            //RestoreConnections();
        }

        /*
        private static void RestoreConnections()
        {
            foreach (var node in _createdNodes.Keys)
            {
                foreach (var nextNode in node.NextNodesID)
                {
                    Edge edge = _createdNodes[node].OutputPort.ConnectTo(_createdNodes[nextNode].InputPort);
                    _graphView.AddElement(edge);
                }
            }
        }
        */
        private static void CreateEditorNodes()
        {
            foreach (var node in _dialogueStaticData.NodeDatas)
            {
                EditorNode editorNode = _graphView.CreateNode(node.Position, node.Events);
                _createdNodes.Add(node, editorNode);
            }
        }
    }
}