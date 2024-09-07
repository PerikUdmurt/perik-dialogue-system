using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [CreateAssetMenu(fileName = "New Dialogue Static Data", menuName = "Simple Dialogue System/Dialogue Static Data")]
    public class DialogueStaticData : ScriptableObject
    {
        [field: SerializeField] public string DialogueName { get; set; }

        [field: SerializeField] public string StartNodeID { get; set; }

        [field: SerializeField] public List<DialogueNodeStaticData> NodeDatas { get; set; }

        [field: SerializeField] public List<NoteData> Notes { get; set; }

        public void Init(string dialogueName, string startNode, List<DialogueNodeStaticData> nodeDatas, List<NoteData> notes)
        {
            DialogueName = dialogueName;
            StartNodeID = startNode;
            NodeDatas = nodeDatas;
            Notes = notes;
        }
    }

    [Serializable]
    public class NoteData
    {
        [field: SerializeField] public string ID { get; set; }
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public Vector2 Position { get; set; }
    }
}