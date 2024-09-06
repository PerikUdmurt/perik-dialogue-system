using UnityEngine;

namespace SimpleDialogueSystem.StaticDatas
{
    [CreateAssetMenu(fileName = "asdfsadfs", menuName = "Simple Dialogue System/adfasdf")]
    public class ASSADAS : ScriptableObject
    {
        public string DialogueName;
        public int adfadsf;
        public float dfdadf;

        public void Play()
        {
            Debug.Log($"{DialogueName}, {adfadsf}, {dfdadf}");
        }
    }
}