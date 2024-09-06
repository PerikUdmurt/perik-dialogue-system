using SimpleDialogueSystem.Infrastructure.Factories;
using System;
using UnityEngine;

namespace SimpleDialogueSystem
{
    public interface IBaseDialogueWindow
    {
        public abstract event Action Skipped;
        public abstract IDialogueButton CreateButton(ButtonData buttonData);
        public abstract void ReleaseButton(IDialogueButton button);
        public abstract void ReleaseAllButtons();
        public abstract void ShowBlock(BlockData blockData);
        public abstract void ReleaseBlock(PhraseBlock block);
        public abstract void ReleaseAllBlocks();
        public abstract void ShowLog();
        public abstract void HideLog();
        public abstract void Enable();
        public abstract void Disable();
    }

    public abstract class BaseMonoDialogueWindow : MonoBehaviour, IBaseDialogueWindow
    {
        public abstract event Action Skipped;

        public abstract IDialogueButton CreateButton(ButtonData buttonData);

        public abstract void Disable();

        public abstract void Enable();

        public abstract void HideLog();

        public abstract void ReleaseAllBlocks();

        public abstract void ReleaseAllButtons();

        public abstract void ReleaseBlock(PhraseBlock block);

        public abstract void ReleaseButton(IDialogueButton button);

        public abstract void ShowBlock(BlockData blockData);

        public abstract void ShowLog();
    }
}