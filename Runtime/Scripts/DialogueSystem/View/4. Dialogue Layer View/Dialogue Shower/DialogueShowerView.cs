using SimpleDialogueSystem.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleDialogueSystem.DialogueSystemModel.View.DialogueLayer
{
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
}

