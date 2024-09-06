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

        public void Init(string dialogueName, string startNode, List<DialogueNodeStaticData> nodeDatas)
        {
            DialogueName = dialogueName;
            StartNodeID = startNode;
            NodeDatas = nodeDatas;
        }
    }
}