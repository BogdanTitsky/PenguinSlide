using System;
using UnityEngine;

namespace Game
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private Fish[] fishes;

        private int fishCount;

        private void Start()
        {
            fishCount = fishes.Length;
            foreach (var fish in fishes) fish.OnFishGrab += FishGrabbed;
        }

        public event Action OnLevelWon;

        private void FishGrabbed()
        {
            fishCount--;
            if (fishCount == 0) GameWon();
        }

        private void GameWon()
        {
            OnLevelWon?.Invoke();
        }
    }
}