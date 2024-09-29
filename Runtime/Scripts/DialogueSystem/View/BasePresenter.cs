using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using UnityEngine;

namespace SimpleDialogueSystem.DialogueSystemModel.View
{
    public class BasePresenter<TView> where TView : IView
    {
        protected TView _view;
        protected IEventBus _eventBus;

        public BasePresenter(TView view, IEventBus model)
        {
            _view = view;
            _eventBus = model;
            _view.Init();
        }
    }

    public class BasePresenter<TView, TPresenterSettings> :
        IPresenterEventHandler<TPresenterSettings>
        where TView : IView 
        where TPresenterSettings : struct, IPresenterSettings
    {
        protected TView _view;
        protected IEventBus _eventBus;
        protected TPresenterSettings _presenterSettings;

        public BasePresenter(TView view, IEventBus model)
        {
            _view = view;
            _eventBus = model;
            _view.Init();
            _eventBus.Register(this);
        }

        public void OnEvent(IOnDisplayChangedEvent<TPresenterSettings> @event)
        {
            _presenterSettings = @event.settings;
            Debug.Log($"Set new presenter settings on {this.ToString()}");
        }
    }

    public interface IPresenterSettings { }
}

