namespace SimpleDialogueSystem.DialogueSystem.View
{
    public class BasePresenter<TView> where TView : IView
    {
        protected TView _view;
        public BasePresenter(TView view)
        {
            _view = view;
        }
    }
}

