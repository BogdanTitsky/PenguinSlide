using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Skills
{
    public class DestroyRandomBlockSkill : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI amountSkills;
        [Inject] private BlocksList blocks;
        [Inject] private GameData gameData;


        private void Start()
        {
            SetText();
        }

        public void DestroyRandomBlock()
        {
            if (gameData.blockBreakSkillBalance == 0)
            {
                button.interactable = false;
                return;
            }

            if (blocks.list.Count == 0)
            {
                button.interactable = false;
                return;
            }

            gameData.RemoveBlockBreakSkill();
            SetText();
            var randomIndex = Random.Range(0, blocks.list.Count);
            var blockToDestroy = blocks.list[randomIndex];

            blockToDestroy.DestroyBlock();
            if (blocks.list.Count == 0)
                button.interactable = false;
        }

        private void SetText()
        {
            amountSkills.text = gameData.blockBreakSkillBalance.ToString();
        }
    }
}