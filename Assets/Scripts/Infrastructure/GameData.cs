using System;
using Constants;
using UnityEngine;

namespace Infrastructure
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game Data/Game Data", order = 1)]
    public class GameData : ScriptableObject
    {
        public int fishBalance;
        public int crystalsBalance;
        public int blockBreakSkillBalance;
        public int penguinBreakerSkillBalance;
        public int additionalSlideSkillBalance;
        public int unlockedLevels;

        private void OnEnable()
        {
            LoadGameData();
        }

        private void OnDisable()
        {
            SaveGameData();
        }

        public event Action OnDataChanged;

        public void AddCrystals(int amount)
        {
            crystalsBalance += amount;
            OnDataChanged?.Invoke();
            SaveGameData();
        }

        public void RemoveCrystals(int amount)
        {
            if (crystalsBalance >= amount)
            {
                crystalsBalance -= amount;
                OnDataChanged?.Invoke();
                SaveGameData();
            }
        }

        public void AddFish(int amount)
        {
            fishBalance += amount;
            OnDataChanged?.Invoke();
            SaveGameData();
        }

        public void RemoveFish(int amount)
        {
            if (fishBalance >= amount)
            {
                fishBalance -= amount;
                OnDataChanged?.Invoke();
                SaveGameData();
            }
        }

        public void AddBlockBreakSkill(int amount)
        {
            blockBreakSkillBalance += amount;
            OnDataChanged?.Invoke();
            SaveGameData();
        }

        public void RemoveBlockBreakSkill()
        {
            if (blockBreakSkillBalance >= 1)
            {
                blockBreakSkillBalance--;
                OnDataChanged?.Invoke();
                SaveGameData();
            }
        }

        public void AddAdditionalSlideSkill(int amount)
        {
            additionalSlideSkillBalance += amount;
            OnDataChanged?.Invoke();
            SaveGameData();
        }

        public void RemoveAdditionalSlideSkill()
        {
            if (additionalSlideSkillBalance >= 1)
            {
                additionalSlideSkillBalance--;
                OnDataChanged?.Invoke();
                SaveGameData();
            }
        }

        public void AddPenguinBreakerSkill(int amount)
        {
            penguinBreakerSkillBalance += amount;
            OnDataChanged?.Invoke();
            SaveGameData();
        }

        public void RemovePenguinBreakerSkill()
        {
            if (penguinBreakerSkillBalance >= 1)
            {
                penguinBreakerSkillBalance--;
                OnDataChanged?.Invoke();
                SaveGameData();
            }
        }

        private void SaveGameData()
        {
            PlayerPrefs.SetInt(PlayerPrefsConsts.FishBalance, fishBalance);
            PlayerPrefs.SetInt(PlayerPrefsConsts.CrystalsBalance, crystalsBalance);
            PlayerPrefs.SetInt(PlayerPrefsConsts.UnlockedLevels, unlockedLevels);
            PlayerPrefs.SetInt(PlayerPrefsConsts.BlockBreakSkillBalance, blockBreakSkillBalance);
            PlayerPrefs.SetInt(PlayerPrefsConsts.PenguinBreakerSkillBalance, penguinBreakerSkillBalance);
            PlayerPrefs.SetInt(PlayerPrefsConsts.AdditionalSlideSkillBalance, additionalSlideSkillBalance);
            PlayerPrefs.Save();
        }

        private void LoadGameData()
        {
            fishBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.FishBalance, 0);
            crystalsBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.CrystalsBalance, 0);
            unlockedLevels = PlayerPrefs.GetInt(PlayerPrefsConsts.UnlockedLevels, 1);
            blockBreakSkillBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.BlockBreakSkillBalance, 6);
            penguinBreakerSkillBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.PenguinBreakerSkillBalance, 2);
            additionalSlideSkillBalance = PlayerPrefs.GetInt(PlayerPrefsConsts.AdditionalSlideSkillBalance, 4);
        }
    }
}