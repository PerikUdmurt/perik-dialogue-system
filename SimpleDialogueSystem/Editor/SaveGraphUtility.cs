using SimpleDialogueSystem.StaticDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public static class SaveGraphUtility
    {
        private static NodeGraphView _graphView;

        private static List<Edge> _edges;
        private static Dictionary<EditorNode, DialogueNode> _nodePairs;

        public static void Init(NodeGraphView graphView)
        {
            _nodePairs = new Dictionary<EditorNode, DialogueNode>();
            _edges = new List<Edge>();
            _graphView = graphView;
        }

        public static void Save()
        {
            GetElementsFromGraphView();
            ConnectDialogueNodes();
            DialogueStaticData dialogueData = CreateAsset<DialogueStaticData>("Assets", "NewDialogue");

            dialogueData.Init("New", _nodePairs.Values.ToList());
        }

        private static void ConnectDialogueNodes()
        {
            foreach (Edge edge in _edges)
            {
                if (_nodePairs.TryGetValue((EditorNode)edge.output.node, out DialogueNode inputDNode))
                {
                    if (_nodePairs.TryGetValue((EditorNode)edge.input.node, out DialogueNode outputDNode))
                    {
                        inputDNode.NextNodes.Add(outputDNode);
                    }
                }
            }
        }

        private static T CreateAsset<T>(string path, string assetName) where T : ScriptableObject
        {
            string fullPath = $"{path}/{assetName}.asset";

            T asset = AssetDatabase.LoadAssetAtPath<T>(fullPath);

            if (asset == null )
            {
                asset = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(asset, fullPath);
            }

            return asset;
        }

        private static void GetElementsFromGraphView()
        {
            _graphView.graphElements.ForEach(graphElement =>
            {
                if (graphElement is EditorNode node)
                {
                    DialogueNode dialogueNode = node.ToDialogueNode();
                    _nodePairs.Add(node, dialogueNode);
                    return;
                }

                if (graphElement is Edge edge)
                {
                    _edges.Add(edge);
                    return;
                }
            });
        }
    }

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
            RestoreConnections();
        }

        private static void RestoreConnections()
        {
            foreach (var node in _createdNodes.Keys)
            {
                foreach (var nextNode in node.NextNodes)
                {
                    Edge edge = _createdNodes[node].OutputPort.ConnectTo(_createdNodes[nextNode].InputPort);
                    _graphView.AddElement(edge);
                }
            }
        }

        private static void CreateEditorNodes()
        {
            if (_dialogueStaticData.NodeDatas == null)
                return;

            foreach (var node in _dialogueStaticData.NodeDatas)
            {
                EditorNode editorNode = _graphView.CreateNode(node.Position);
                _createdNodes.Add(node, editorNode);
            }
        }


    }

    public static class NodeExtensions
    {
        public static DialogueNode ToDialogueNode(this EditorNode editorNode)
            => new DialogueNode()
            {
                Name = editorNode.NodeName,
                Position = editorNode.GetPosition().position,
                NextNodes = new()
            };
    }
}