using SimpleDialogueSystem.DialogueSystem.GraphPlayers;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.Infrastructure.GraphProviders;

namespace SimpleDialogueSystem.DialogueSystem
{
    public class DialogueSystem
    {
        private readonly IGraphProvider _graphProvider;
        private readonly IGraphPlayer _dialoguePlayer;
        private readonly IEventBus _eventBus;

        public DialogueSystem()
        {
            _eventBus = new BaseEventBus();
            _graphProvider = new NodeGraphProvider();
            _dialoguePlayer = new DialoguePlayer(_eventBus, _graphProvider);
        }

        public void Trigger(IEvent @event) => _eventBus.Trigger(@event);
    }
}