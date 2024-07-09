using EasyUI.PickerWheelUI;
using Infrastructure;
using PopUps;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop
{
    public class WheelReward : MonoBehaviour
    {
        [SerializeField] private Button spinButton;
        [SerializeField] private TextMeshProUGUI spinButtonText;

        [SerializeField] private PickerWheel pickerWheel;
        [SerializeField] private PopUpController NotEnoughtCrystalsPopUp;

        [Inject] private GameData gameData;

        private void Start()
        {
            spinButton.onClick.AddListener(Spin);
        }

        private void Spin()
        {
            if (!CheckEnoughBalance()) return;
            gameData.RemoveCrystals(1);
            spinButton.interactable = false;
            spinButtonText.text = "Spinning...";
            pickerWheel.OnSpinEnd(wheelPiece =>
            {
                if (wheelPiece.Label == "Crystal") gameData.AddCrystals(wheelPiece.Amount);
                if (wheelPiece.Label == "Star") gameData.AddFish(wheelPiece.Amount);
                if (wheelPiece.Label == "Breaker") gameData.AddPenguinBreakerSkill(wheelPiece.Amount);
                if (wheelPiece.Label == "Slide") gameData.AddAdditionalSlideSkill(wheelPiece.Amount);
                spinButton.interactable = true;
                spinButtonText.text = "Spin";
            });
            pickerWheel.Spin();
        }

        private bool CheckEnoughBalance()
        {
            if (gameData.crystalsBalance < 1)
            {
                NotEnoughtCrystalsPopUp.ShowPopUp();
                return false;
            }

            return true;
        }
    }
}