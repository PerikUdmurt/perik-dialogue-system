using SimpleDialogueSystem.Events;

namespace SimpleDialogueSystem
{
    public interface IDialoguePresenter : OnBeginDialogueHandler, OnBeginPhraseHandler, OnEndDialogueHandler, OnDisplayChangedHandler, OnEndPhraseHandler
    { }
}