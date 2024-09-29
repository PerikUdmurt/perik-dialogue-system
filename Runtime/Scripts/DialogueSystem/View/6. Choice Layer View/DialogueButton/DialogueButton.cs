using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleDialogueSystem.DialogueSystemModel.View.ChoicesLayer
{
    public class DialogueButton : Button, IDialogueButton
    {
        [SerializeField] private TextMeshProUGUI _buttonText;

        public void SetText(string text)
            => _buttonText.text = text;
    }
}