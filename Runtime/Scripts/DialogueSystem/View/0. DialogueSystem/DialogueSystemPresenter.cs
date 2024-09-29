using SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;

namespace SimpleDialogueSystem.DialogueSystemModel.View
{
    public class DialogueSystemPresenter : BasePresenter<DialogueSystemView>
    {
        private DialogueLayerPresenter _dialogueLayerPresenter;

        public DialogueSystemPresenter(DialogueSystemView view, IEventBus model) : base(view, model)
        {
            RegisterSubPresenters();
        }

        private void RegisterSubPresenters()
        {
            _dialogueLayerPresenter = new DialogueLayerPresenter(
                view: _view.DialogueLayerView,
                model: _eventBus);
        }
    }
}

