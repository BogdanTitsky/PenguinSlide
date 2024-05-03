using Infrastructure;
using PopUps;
using TMPro;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] private int price;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private PopUpController NotEnoughFish;

        [Inject] private GameData gameData;

        private void Start()
        {
            priceText.text = price.ToString();
        }

        public void BuyCrystal()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddCrystals(1);
        }

        public void Buy10Crystals()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddCrystals(10);
        }

        public void BuyAdditionalSlideSkill()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddAdditionalSlideSkill(1);
        }

        public void BuyAdditionalSlideSkillX10()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddAdditionalSlideSkill(10);
        }

        public void BuyBlockBreakSkill()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddBlockBreakSkill(1);
        }

        public void BuyBlockBreakSkillX10()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddBlockBreakSkill(10);
        }

        public void BuyPenguinBreakerSkill()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddPenguinBreakerSkill(1);
        }

        public void BuyPenguinBreakerSkillX10()
        {
            if (!CheckEnoughBalance()) return;

            gameData.RemoveFish(price);
            gameData.AddPenguinBreakerSkill(10);
        }

        private bool CheckEnoughBalance()
        {
            if (price > gameData.fishBalance)
            {
                NotEnoughFish.ShowPopUp();
                return false;
            }

            return true;
        }
    }
}