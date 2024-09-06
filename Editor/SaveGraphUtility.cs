using SimpleDialogueSystem.Editors.Nodes;
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

            dialogueData.Init("New", null,_nodePairs.Values.ToList());
        }

        private static void ConnectDialogueNodes()
        {
            foreach (Edge edge in _edges)
            {
                if (_nodePairs.TryGetValue((EditorNode)edge.output.node, out DialogueNode inputDNode))
                {
                    if (_nodePairs.TryGetValue((EditorNode)edge.input.node, out DialogueNode outputDNode))
                    {
                        inputDNode.NextNodesID.Add(outputDNode.ID);
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
}