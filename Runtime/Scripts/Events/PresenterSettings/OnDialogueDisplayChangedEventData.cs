using SimpleDialogueSystem.DialogueSystemModel.View;
using SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer;
using SimpleDialogueSystem.Infrastructure.EventBus;
using UnityEngine;

namespace SimpleDialogueSystem.Events
{
    public interface IPresenterEventHandler<TPresenterSettings> :
        IEventHandler<IOnDisplayChangedEvent<TPresenterSettings>> 
        where TPresenterSettings : IPresenterSettings { }

    public interface IOnDisplayChangedEvent<TPresenterSettings> :
        IEvent where TPresenterSettings: IPresenterSettings 
    { 
        public TPresenterSettings settings { get; }
    }

    [NodeEvent("Настройки диалогового окна"), System.Serializable]
    public struct OnDialogueDisplayChangedEventData : 
        IOnDisplayChangedEvent<DialogueShowerPresenterSettings>
    {
        [field: SerializeField]
        private DialogueShowerPresenterSettings _settings;

        public DialogueShowerPresenterSettings settings { get => _settings; }
    }

}