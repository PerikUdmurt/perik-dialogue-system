using SimpleDialogueSystem.DialogueSystemModel.View;
using SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer;
using SimpleDialogueSystem.Infrastructure.EventBus;

public class DialogueLayerPresenter : BasePresenter<DialogueLayerView, DialogueLayerPresenterSettings>
{
    private DialogueShowerPresenter _showerPresenter;

    public DialogueLayerPresenter(DialogueLayerView view, IEventBus model)
        : base(view, model)
    {
        RegisterSubPresenters();
    }

    //Лучше вытянуть в отдельный регистратор + рассмотреть DiConteiner
    private void RegisterSubPresenters()
    {
        _showerPresenter = new DialogueShowerPresenter(
            view: _view.DialogueShowerView,
            model: _eventBus);
    }
}
