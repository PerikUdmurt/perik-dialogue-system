using SimpleDialogueSystem.Model;

namespace SimpleDialogueSystem
{
    public class DialogueSystem
    {
        private readonly DialoguePresenter _presenter;
        private readonly DialogueModel _dialogueModel;

        public DialogueSystem(IBaseDialogueWindow dialogueWindow) 
        {
            _dialogueModel = new();
            _presenter = new DialoguePresenter(dialogueWindow, _dialogueModel);
        }
    }
}