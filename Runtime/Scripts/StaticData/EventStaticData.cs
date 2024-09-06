using System;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [Serializable]
    public class EventStaticData
    {
        [field: SerializeField] public string typeName;
        [field: SerializeField] public string json;
    }
}