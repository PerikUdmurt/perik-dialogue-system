using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleDialogueSystem.DialogueSystem.View
{
    public class DialogueView : MonoBehaviour, IView
    {
        [SerializeField] DialogueShowerView _showerView;

        public void Init()
        {
            
        }
    }

    public class DialogueSystemPresenter : BasePresenter<DialogueView, IEventBus>
    {
        public DialogueSystemPresenter(DialogueView view, IEventBus model) : base(view, model)
        {

        }
    }

    public class DialogueShowerView : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _blockSpawnPoint;
        [SerializeField] private PhraseBlock _blockPrefab;
        [SerializeField] private List<Button> _clickableZones;

        private BlockCreator _blockCreator;
        private List<PhraseBlock> _createdBlocks;

        public event Action ClickableZoneClicked;

        public void Init()
        {
            _blockCreator = new BlockCreator(_blockPrefab, _blockSpawnPoint.transform);

            foreach (var zone in _clickableZones)
            {
                zone.onClick.AddListener(() => ClickableZoneClicked?.Invoke());
            }
        }

        public void Dispose()
        {
            ClearBlocks();

            foreach(var zone in _clickableZones)
            {
                zone.onClick.RemoveAllListeners();
            }
        }

        public void ShowBlock(BlockData data) =>
            _blockCreator.CreateBlock(data);

        public void ClearBlocks() =>
            _blockCreator.ReleaceAllBlocks();
    }

    public class DialogueShowerPresenter : BasePresenter<DialogueShowerView, IEventBus>, 
        IEventHandler<OnPlayGraphEventData>,
        IEventHandler<OnPlayPhraseEventData>, 
        IEventHandler<OnEndGraphEventData>,
        IEventHandler<OnDialogueDisplayChangedEventData>
    {
        public DialogueShowerPresenter(DialogueShowerView view, IEventBus model) : base(view, model)
        {
            view.ClickableZoneClicked += OnClicked;
        }

        private void OnClicked()
        {
            _model.Trigger(new OnSkippedEventData());
        }

        public void OnEvent(OnPlayGraphEventData @event) => ShowDialogueWindow();

        public void OnEvent(OnPlayPhraseEventData @event)
        {
            ShowDialogueWindow();
            _view.ShowBlock(@event.blockData);
        }

        public void OnEvent(OnEndGraphEventData @event) => HideDialogueWindow();

        public void OnEvent(OnDialogueDisplayChangedEventData @event)
        {
            Debug.Log("OnDisplayChanged");
        }

        private void ShowDialogueWindow()
        {
            Debug.Log("ShowDialogueWindow");
        }

        private void HideDialogueWindow()
        {
            Debug.Log("HideDialogueWindow");
        }

    }
}

