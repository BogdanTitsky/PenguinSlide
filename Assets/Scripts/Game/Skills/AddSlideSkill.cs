using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Skills
{
    public class AddSlideSkill : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountSkills;
        [SerializeField] private Button button;
        [Inject] private GameData gameData;

        [Inject] private MovesCount movesCount;

        private void Start()
        {
            SetText();
        }

        public void AddSlidesSkill()
        {
            if (gameData.additionalSlideSkillBalance == 0)
            {
                button.interactable = false;
                return;
            }

            gameData.RemoveAdditionalSlideSkill();
            movesCount.IncreaseMoveCount();
            SetText();
        }

        private void SetText()
        {
            amountSkills.text = gameData.additionalSlideSkillBalance.ToString();
        }
    }
}