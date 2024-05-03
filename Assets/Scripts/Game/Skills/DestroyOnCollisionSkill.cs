using System;
using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Skills
{
    public class DestroyOnCollisionSkill : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI amountSkills;
        [Inject] private GameData gameData;
        [Inject] private Penguin penguin;

        private void Start()
        {
            SetText();
        }

        public event Action OnCollisionSkillOn;

        public void MakeAbleToDestroy()
        {
            if (gameData.penguinBreakerSkillBalance == 0)
            {
                button.interactable = false;
                return;
            }

            gameData.RemovePenguinBreakerSkill();
            SetText();
            OnCollisionSkillOn?.Invoke();
            penguin.canDestroy = true;
            button.interactable = false;
        }

        private void SetText()
        {
            amountSkills.text = gameData.penguinBreakerSkillBalance.ToString();
        }
    }
}