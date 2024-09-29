using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using UnityEngine;

namespace SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer
{
    public class DialogueShowerPresenter : BasePresenter<DialogueShowerView, DialogueShowerPresenterSettings>, 
        IEventHandler<OnPlayGraphEventData>,
        IEventHandler<OnPlayPhraseEventData>, 
        IEventHandler<OnEndGraphEventData>
    {
        public DialogueShowerPresenter(DialogueShowerView view, IEventBus model) 
            : base(view, model)
        {
            model.Register<OnPlayGraphEventData>(this);
            model.Register<OnPlayPhraseEventData>(this);
            model.Register<OnEndGraphEventData>(this);
            view.ClickableZoneClicked += OnClicked;
        }

        private void OnClicked()
        {
            _eventBus.Trigger(new OnSkippedEventData());
        }

        public void OnEvent(OnPlayGraphEventData @event) => ShowDialogueWindow();

        public void OnEvent(OnPlayPhraseEventData @event)
        {
            Debug.Log("ShowerPresenter: ShowBlock");
            ShowDialogueWindow();
            _view.ClearBlocks();
            _view.ShowBlock(@event.blockData);
        }

        public void OnEvent(OnEndGraphEventData @event) => HideDialogueWindow();

        private void ShowDialogueWindow()
        {
            Debug.Log("ShowDialogueWindow");
        }

        private void HideDialogueWindow()
        {
            Debug.Log("HideDialogueWindow");
        }
    }

    [Serializable]
    public struct DialogueShowerPresenterSettings : IPresenterSettings
    {
        public int textSize;
    }
}

