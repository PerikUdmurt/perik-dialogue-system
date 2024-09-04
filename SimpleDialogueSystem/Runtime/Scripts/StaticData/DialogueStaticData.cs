using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [CreateAssetMenu(fileName = "New Dialogue Static Data", menuName = "Simple Dialogue System/Dialogue Static Data")]
    public class DialogueStaticData : ScriptableObject
    {
        [field: SerializeField] public string DialogueName { get; set; }

        [field: SerializeField] public List<DialogueNode> NodeDatas { get; set; } = new List<DialogueNode>();

        public void Init(string dialogueName, List<DialogueNode> nodeDatas)
        {
            DialogueName = dialogueName;
            NodeDatas = nodeDatas;
        }
    }

    [Serializable]
    public class DialogueNode
    {
        [field: SerializeField] public string ID { get; set; }
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public Vector2 Position { get; set; }
        [field: SerializeField] public List<DialogueNode> NextNodes { get; set; }
    }
}