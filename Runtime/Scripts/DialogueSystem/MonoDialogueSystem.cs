using SimpleDialogueSystem.DialogueSystemModel.View;
using SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using UnityEngine;

namespace SimpleDialogueSystem.DialogueSystemModel
{
    public class MonoDialogueSystem : MonoBehaviour
    {
        [Serializable]
        public class DialogueSystemEditorData { [SerializeReference] public IEvent Event; }

        public DialogueSystemEditorData EditorData;

        [SerializeField] private DialogueSystemView _dialogueView;

        private DialogueSystem _dialogueSystem;

        private void Awake()
        {
            _dialogueSystem = new(_dialogueView);
            DontDestroyOnLoad(gameObject);
        }

        public void Trigger(IEvent @event) => _dialogueSystem.Trigger(@event);
    }
}