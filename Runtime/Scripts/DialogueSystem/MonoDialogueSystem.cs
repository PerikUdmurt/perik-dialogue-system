using SimpleDialogueSystem.DialogueSystem.View;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using UnityEngine;

namespace SimpleDialogueSystem.DialogueSystem
{
    public class MonoDialogueSystem : MonoBehaviour
    {
        [Serializable]
        public class DialogueSystemEditorData
        {
            [SerializeReference] public IEvent Event;
        }

        public DialogueSystemEditorData EditorData;

        [SerializeField] private DialogueShowerView _dialogueView;

        private DialogueSystem _dialogueSystem;

        private void Awake()
        {
            _dialogueSystem = new();
            DontDestroyOnLoad(gameObject);
        }

        public void Trigger(IEvent @event) => _dialogueSystem.Trigger(@event);
    }
}