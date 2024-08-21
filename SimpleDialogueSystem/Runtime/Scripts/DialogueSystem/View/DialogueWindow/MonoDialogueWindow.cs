using SimpleDialogueSystem.Infrastructure.Factories;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleDialogueSystem
{
    public class MonoDialogueWindow: BaseMonoDialogueWindow
    {
        [SerializeField] private GameObject _buttonContainer;
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private GameObject _blockContainer;
        [SerializeField] private PhraseBlock _blockPrefab;
        private ButtonCreator _buttonCreator;
        private BlockCreator _blockCreator;

        public override event Action Skipped;
        
        private void Awake()
        {
            _buttonCreator = new ButtonCreator(_buttonPrefab, _buttonContainer.transform);
            _blockCreator = new BlockCreator(_blockPrefab, _blockContainer.transform);
        }

        public override IDialogueButton CreateButton(ButtonData buttonData)
            =>_buttonCreator.CreateButton(buttonData);

        public override void Disable()
            => gameObject.SetActive(false);

        public override void Enable()
            => gameObject.SetActive(true);

        public override void HideLog()
            => Debug.Log("HideLog");

        public override void ReleaseAllBlocks()
            => _blockCreator.ReleaceAllBlocks();

        public override void ReleaseAllButtons()
            => _buttonCreator.ReleaseAllButtons();

        public override void ReleaseBlock(PhraseBlock block)
            => _blockCreator.ReleasePhraseBlock(block);

        public override void ReleaseButton(IDialogueButton button)
            => _buttonCreator.ReleaseButton(button);

        public override void ShowBlock(BlockData blockData)
            => _blockCreator.CreateBlock(blockData);

        public override void ShowLog()
            => Debug.Log("ShowLog");

    }
}