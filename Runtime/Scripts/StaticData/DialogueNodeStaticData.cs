using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [Serializable]
    public class DialogueNodeStaticData
    {
        [field: SerializeField] public string ID;
        [field: SerializeField] public Vector2Data Position;
        [field: SerializeField] public List<string> NextNodesID;
        [field: SerializeField] public List<EventStaticData> EventDatas;
    }
}