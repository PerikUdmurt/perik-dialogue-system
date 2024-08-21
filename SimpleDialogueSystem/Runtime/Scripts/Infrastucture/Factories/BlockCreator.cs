using SimpleDialogueSystem.Infrastructure.ObjectPool;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.Factories
{
    public class BlockCreator
    {
        private ObjectPool<PhraseBlock> _blockPool;
        private List<PhraseBlock> _createdBlocks;
        
        public BlockCreator(PhraseBlock phraseBlock, Transform parent, int preparePrefabs = 0)
        {
            _blockPool = new(phraseBlock.gameObject, parent, preparePrefabs);
            _createdBlocks = new List<PhraseBlock>();
        }

        public PhraseBlock CreateBlock(BlockData blockData)
        {
            PhraseBlock block = _blockPool.Get();
            block.Init(blockData);

            _createdBlocks.Add(block);

            return block;
        }

        public void ReleasePhraseBlock(PhraseBlock block)
        {
            _createdBlocks.Remove(block);
            _blockPool.Release(block);
        }

        public void ReleaceAllBlocks()
        {
            for (int i = 0; _createdBlocks.Count > i; i++)
            {
                ReleasePhraseBlock(_createdBlocks[i]);
            }
        }
    }

    public class PhraseBlock: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Init(BlockData blockData)
        {
            text.text = blockData.text;
        }
    }
}