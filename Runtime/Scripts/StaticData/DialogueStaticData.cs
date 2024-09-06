using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [CreateAssetMenu(fileName = "New Dialogue Static Data", menuName = "Simple Dialogue System/Dialogue Static Data")]
    public class DialogueStaticData : ScriptableObject
    {
        public string DialogueName;

        public DialogueNode StartNode;

        public List<DialogueNode> NodeDatas;

        public void Init(string dialogueName, DialogueNode startNode, List<DialogueNode> nodeDatas)
        {
            DialogueName = dialogueName;
            StartNode = startNode;
            NodeDatas = nodeDatas;
        }
    }

    [Serializable]
    public class DialogueNode
    {
        public string ID;
        public Vector2 Position;
        public List<string> NextNodesID;
        [SerializeReference]
        public List<IEvent> Events;
    }
}