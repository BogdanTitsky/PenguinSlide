using Constants;
using Game;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class ResourceReward : MonoBehaviour
    {
        [SerializeField] private int fishRewardAmount = 2;
        [SerializeField] private int crystalRewardAmount = 2;
        [Inject] private WinCondition winCondition;

        private void OnEnable()
        {
            winCondition.OnLevelWon += GrantRewards;
        }

        private void OnDisable()
        {
            winCondition.OnLevelWon -= GrantRewards;
        }

        private void GrantRewards()
        {
            var oldFishBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.FishBalance);
            PlayerPrefs.SetInt(PlayerPrefsConsts.FishBalance, oldFishBalance + fishRewardAmount);
            var oldCrystalBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.CrystalsBalance);
            PlayerPrefs.SetInt(PlayerPrefsConsts.CrystalsBalance, oldCrystalBalance + crystalRewardAmount);
            Debug.Log("Rewards granted: Fish and Crystals");
        }
    }
}