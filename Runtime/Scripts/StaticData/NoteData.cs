using System;
using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [Serializable]
    public class NoteData
    {
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public Vector2 Position { get; set; }
    }
}