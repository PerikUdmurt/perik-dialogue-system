using UnityEngine;

namespace SimpleDialogueSystem
{
    public class MonoDialogueSystem: MonoBehaviour
    {
        [SerializeField] private IBaseDialogueWindow _dialogueWindow; 
        private DialogueSystem _dialogueSystem;
        private void Awake()
        {
            DontDestroyOnLoad(this);
            _dialogueSystem = new(_dialogueWindow);
        }
    }
}