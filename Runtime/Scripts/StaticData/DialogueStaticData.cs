using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [CreateAssetMenu(fileName = "New Dialogue Static Data", menuName = "Simple Dialogue System/Dialogue Static Data")]
    public class DialogueStaticData : ScriptableObject
    {
        [field: SerializeField] public string StartNodeID { get; set; }

        [field: SerializeField] public List<DialogueNodeStaticData> NodeDatas { get; set; }

        [field: SerializeField] public List<NoteData> Notes { get; set; }

        [field: SerializeField] public Vector2Data StartNodePosition { get; set; }

        public void Init(string startNode, Vector2Data startPosition, List<DialogueNodeStaticData> nodeDatas, List<NoteData> notes)
        {
            StartNodeID = startNode;
            NodeDatas = nodeDatas;
            Notes = notes;
            StartNodePosition = startPosition;
        }
    }
}