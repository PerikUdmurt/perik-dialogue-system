using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public static class LoadGraphUtility
    {
        private static StartNode _startNode;
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

            _startNode = CreateStartNode();
            CreateEditorNodes();
            CreateNoteNodes();
            RestoreConnections();
        }


        private static void RestoreConnections()
        {
            foreach (var node in _pair.Keys)
                foreach (var nextNodeID in node.NextNodesID)
                {
                    EditorNode nextNode = (EditorNode)FindEditorNode(nextNodeID);
                    Edge edge = _pair[node].OutputPorts[0].ConnectTo(nextNode.InputPorts[0]);
                    _graphView.AddElement(edge);
                }

            if (_dialogueStaticData.StartNodeID != null)
            {
                EditorNode nextNode = (EditorNode)FindEditorNode(_dialogueStaticData.StartNodeID);
                if (nextNode == null) return;
                Edge edge = _startNode.OutputPorts[0].ConnectTo(nextNode.InputPorts[0]);
                _graphView.AddElement(edge);
            }
        }

        private static void CreateEditorNodes()
        {
            if (_dialogueStaticData != null)
            {
                if (_dialogueNodes.Count == 0) return;

                foreach (var node in _dialogueStaticData.NodeDatas)
                {
                    List<IEvent> events = node.EventDatas.ToEventList();

                    EditorNode editorNode = _graphView.CreateNode(node.Position.ToVector2(), events, node.ID);
                    _pair.Add(node, editorNode);
                    _dialogueNodes.Add(node.ID, node);
                }
            }
        }

        private static void CreateNoteNodes()
        {
            if (_dialogueStaticData != null)
            {
                if (_dialogueStaticData.Notes.Count == 0) return;

                foreach (var node in _dialogueStaticData.Notes)
                {
                    _graphView.CreateNoteNode(node.Position, node.Text);
                }
            }
        }

        private static StartNode CreateStartNode()
        {
            Vector2 vector = _dialogueStaticData.StartNodePosition.ToVector2();
            return _graphView.CreateStartNode(vector);
        }

        private static BaseEditorNode FindEditorNode(string id)
        {
            BaseEditorNode Enode = null;

            _graphView.graphElements.ForEach(element =>
            {
                if (element is BaseEditorNode node)
                {
                    if (node.ID == id)
                    {
                        Enode = node;
                        return;
                    }
                }
            });

            return Enode;
        }
    }
}