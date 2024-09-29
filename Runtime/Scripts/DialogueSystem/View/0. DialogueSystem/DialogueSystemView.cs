using SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer;
using UnityEngine;

namespace SimpleDialogueSystem.DialogueSystemModel.View
{
    public class DialogueSystemView : MonoBehaviour, IView
    {
        [SerializeField] 
        private DialogueLayerView _dialogueLayerView;

        public DialogueLayerView DialogueLayerView {  get => _dialogueLayerView; }

        public void Init()
        {
            
        }
    }
}

