using SimpleDialogueSystem.DialogueSystemModel.GraphPlayers;
using SimpleDialogueSystem.DialogueSystemModel.View;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.Infrastructure.GraphProviders;
using UnityEngine;

namespace SimpleDialogueSystem.DialogueSystemModel
{
    public class DialogueSystem
    {
        private readonly IGraphProvider _graphProvider;
        private readonly IGraphPlayer _dialoguePlayer;
        private readonly IEventBus _eventBus;

        private DialogueSystemPresenter _presenter;

        public DialogueSystem()
        {
            _eventBus = new BaseEventBus();
            _graphProvider = new NodeGraphProvider();
            _dialoguePlayer = new DialoguePlayer(_eventBus, _graphProvider);
        }

        public DialogueSystem(DialogueSystemView view)
        {
            _eventBus = new BaseEventBus();
            _graphProvider = new NodeGraphProvider();
            _dialoguePlayer = new DialoguePlayer(_eventBus, _graphProvider);
            ConnectView(view);
        }

        public void Trigger(IEvent @event)
            {
                _eventBus.Trigger(@event);
            }

        public void ConnectView(DialogueSystemView view) =>
            _presenter = new DialogueSystemPresenter(view, _eventBus);
    }
}