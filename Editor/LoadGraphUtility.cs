using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace SimpleDialogueSystem.Editors
{
    public static class LoadGraphUtility
    {
        private static NodeGraphView _graphView;
        private static DialogueStaticData _dialogueStaticData;
        private static Dictionary<DialogueNodeStaticData, EditorNode> _pair;
        private static Dictionary<string, DialogueNodeStaticData> _dialogueNodes;

        public static void Load(DialogueStaticData dialogueStaticData, NodeGraphView nodeGraphView)
        {
            _pair = new Dictionary<DialogueNodeStaticData, EditorNode>();
            _dialogueNodes = new();
            _dialogueStaticData = dialogueStaticData;
            _graphView = nodeGraphView;

            CreateEditorNodes();
            RestoreConnections();
        }

        
        private static void RestoreConnections()
        {
            foreach (var node in _pair.Keys)
                foreach (var nextNodeID in node.NextNodesID)
                {
                    EditorNode nextNode = FindEditorNode(nextNodeID);
                    Edge edge = _pair[node].OutputPort.ConnectTo(nextNode.InputPort);
                    _graphView.AddElement(edge);
                }
        }
        
        private static void CreateEditorNodes()
        {
            if (_dialogueStaticData != null)
            {
                foreach (var node in _dialogueStaticData.NodeDatas)
                {
                    List<IEvent> events = node.EventDatas.ToEventList();

                    EditorNode editorNode = _graphView.CreateNode(node.Position.ToVector2(), events, node.ID);
                    _pair.Add(node, editorNode);
                    _dialogueNodes.Add(node.ID, node);
                }
            }
        }

        private static EditorNode FindEditorNode(string id)
        {
            if (_dialogueNodes.TryGetValue(id, out var dialogueNode))
            {
                if (_pair.TryGetValue(dialogueNode, out var editorNode))
                    return editorNode;
            }

            return null;
        }
    }
}