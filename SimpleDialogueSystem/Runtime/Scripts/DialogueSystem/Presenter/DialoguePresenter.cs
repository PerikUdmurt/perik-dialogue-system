using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Model;
using System.Collections.Generic;
using UnityEngine.UI;

namespace SimpleDialogueSystem
{
    public sealed class DialoguePresenter : IDialoguePresenter
    {
        private readonly IBaseDialogueWindow _dialogueWindow;
        private readonly DialogueModel _dialogueModel;
        private readonly Dictionary<int, Button> _availableButtons;

        public DialoguePresenter(IBaseDialogueWindow dialogueWindow, DialogueModel dialogueSystem)
        {
            _dialogueModel = dialogueSystem;
            _dialogueWindow = dialogueWindow;
            _availableButtons = new Dictionary<int, Button>();
        }
        
        public void OnEvent(OnBeginDialogueEventData @event)
        {
            _dialogueWindow?.Enable();
        }

        public void OnEvent(OnEndDialogueEventData @event)
        {
            _dialogueWindow?.Disable();
        }

        public void OnEvent(OnBeginPhraseEventData @event)
        {
            _dialogueWindow.ShowBlock(@event.currentBlockData);
        }

        public void OnEvent(OnEndPhraseEventData @event)
        {

        }

        public void OnEvent(OnDisplayChangedEventData @event)
        {
            
        }
    }
}