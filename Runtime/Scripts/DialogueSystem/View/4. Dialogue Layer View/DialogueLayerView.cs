using SimpleDialogueSystem.DialogueSystemModel.View;
using SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueLayerView : MonoBehaviour, IView
{
    [SerializeField]
    private DialogueShowerView _dialogueShowerView;

    public DialogueShowerView DialogueShowerView { get => _dialogueShowerView; }

    public void Init()
    {
        
    }
}
