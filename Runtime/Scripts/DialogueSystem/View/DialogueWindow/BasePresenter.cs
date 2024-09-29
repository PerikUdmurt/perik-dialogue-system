using SimpleDialogueSystem.Infrastructure.EventBus;

namespace SimpleDialogueSystem.DialogueSystem.View
{
    public class BasePresenter<TView, TModel> where TView : IView where TModel : IEventBus
    {
        protected TView _view;
        protected TModel _model;
        public BasePresenter(TView view, TModel model)
        {
            _view = view;
            _model = model;
            _view.Init();
        }
    }
}

