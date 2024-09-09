using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SimpleDialogueSystem.Editors
{
    public static class SaveGraphUtility
    {
        private static DialogueStaticData _staticData;
        private static NodeGraphView _graphView;

        private static StartNode _startNode;
        private static List<NoteData> _notes;
        private static List<Edge> _edges;
        private static Dictionary<EditorNode, DialogueNodeStaticData> _nodePairs;

        public static void Init(DialogueStaticData dialogueStaticData, NodeGraphView graphView)
        {
            _staticData = dialogueStaticData;
            _notes = new List<NoteData>();
            _nodePairs = new Dictionary<EditorNode, DialogueNodeStaticData>();
            _edges = new List<Edge>();
            _graphView = graphView;
        }

        public static void Save()
        {
            GetElementsFromGraphView();
            ConnectDialogueNodes();
            CreateData();
        }

        private static void CreateData()
        {
            string startNodeID = DetectStartNodeID();
            Vector2Data startVector = _startNode.GetPosition().position.ToVector2Data();
            List<DialogueNodeStaticData> nodes = _nodePairs.Values.ToList();

            _staticData.Init(startNodeID, startVector, nodes, _notes);
        }

        private static string DetectStartNodeID()
        {
            Port port = _startNode.OutputPorts.FirstOrDefault();
            
            if (port == null)
                return "";

            foreach (Edge edge in _edges)
            {
                if (edge.output == port)
                {
                    return ((EditorNode)edge.input.node).ID;
                }
            }

            return "";
        }

        private static void ConnectDialogueNodes()
        {
            foreach (Edge edge in _edges)
            {
                if (edge.output.node is EditorNode && edge.input.node is EditorNode)
                {
                    if (_nodePairs.TryGetValue((EditorNode)edge.output.node, out DialogueNodeStaticData inputDNode))
                    {
                        if (_nodePairs.TryGetValue((EditorNode)edge.input.node, out DialogueNodeStaticData outputDNode))
                        {
                            inputDNode.NextNodesID.Add(outputDNode.ID);
                        }
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
                    DialogueNodeStaticData dialogueNode = node.ToDialogueNode();
                    _nodePairs.Add(node, dialogueNode);
                    return;
                }

                if (graphElement is NoteNode note)
                {
                    NoteData noteData = note.ToNoteData();
                    _notes.Add(noteData);
                    return;
                }

                if (graphElement is StartNode startNode)
                {
                    _startNode = startNode;
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