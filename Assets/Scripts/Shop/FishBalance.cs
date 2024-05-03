using Infrastructure;
using TMPro;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class FishBalance : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;

        private int count;
        [Inject] private GameData gameData;

        private void OnEnable()
        {
            UpdateBalance();
            gameData.OnDataChanged += UpdateBalance;
        }

        private void OnDisable()
        {
            gameData.OnDataChanged -= UpdateBalance;
        }

        private void UpdateBalance()
        {
            count = gameData.fishBalance;
            SetText();
        }

        private void SetText()
        {
            countText.text = count.ToString();
        }
    }
}