using TMPro;
using UnityEngine;

namespace SimpleDialogueSystem.Infrastructure.Factories
{
    public class PhraseBlock: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Init(BlockData blockData)
        {
            text.text = blockData.text;
        }
    }
}