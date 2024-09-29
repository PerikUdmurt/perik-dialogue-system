using SimpleDialogueSystem.DialogueSystemModel.View.ChoicesLayer;
using SimpleDialogueSystem.Infrastructure.ObjectPool;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleDialogueSystem.Infrastructure.Factories
{
    public class ButtonCreator
    {
        private ObjectPool<DialogueButton> _buttonPool;
        private List<DialogueButton> _createdButtons;

        public ButtonCreator(Button buttonPrefab, Transform parent, int prepareButton = 0)
        {
            _buttonPool = new(buttonPrefab.gameObject, parent, prepareButton);
            _createdButtons = new List<DialogueButton>();
        }

        public DialogueButton CreateButton(ButtonData buttonData)
        {
            DialogueButton button = _buttonPool.Get();

            TextMeshProUGUI tmpro = button.GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault();
            if (tmpro != null)
                tmpro.text = buttonData.text;

            _createdButtons.Add(button);

            return button;
        }

        public void ReleaseButton(IDialogueButton button)
        {
            _createdButtons.Remove((DialogueButton)button);
            _buttonPool.Release((DialogueButton)button);
        }

        public void ReleaseAllButtons()
        {
            for (int i = 0; i < _createdButtons.Count; i++)
            {
                ReleaseButton(_createdButtons[i]);
            }
        }
    }
}