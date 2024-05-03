using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class ResourceReward : MonoBehaviour
    {
        [SerializeField] private int fishRewardAmount = 2;
        [SerializeField] private int crystalRewardAmount = 2;
        [SerializeField] private TextMeshProUGUI fishRewardText;
        [SerializeField] private TextMeshProUGUI crystalRewardText;
        [Inject] private GameData gameData;

        [Inject] private WinCondition winCondition;

        private void Start()
        {
            fishRewardText.text = $"+{fishRewardAmount.ToString()}";
            crystalRewardText.text = $"+{crystalRewardAmount.ToString()}";
        }

        private void OnEnable()
        {
            winCondition.OnLevelWon += GrantRewards;
            winCondition.OnLevelWon += LevelCompleted;
        }

        private void OnDisable()
        {
            winCondition.OnLevelWon -= GrantRewards;
            winCondition.OnLevelWon -= LevelCompleted;
        }

        private void GrantRewards()
        {
            gameData.AddCrystals(crystalRewardAmount);
            gameData.AddFish(fishRewardAmount);
        }

        private void LevelCompleted()
        {
            if (gameData.unlockedLevels == SceneManager.GetActiveScene().buildIndex) gameData.unlockedLevels++;
        }
    }
}