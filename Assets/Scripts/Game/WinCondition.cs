using System;
using PopUps;
using UnityEngine;
using Zenject;

namespace Game
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private Fish[] fishes;
        [SerializeField] private PopUpController winPopUp;
        [SerializeField] private PopUpController losePopUp;
        private int fishCount;
        [Inject] private Hp hp;
        [Inject] private MovesCount movesCount;
        [Inject] private PenguinMover penguinMover;


        private void Start()
        {
            fishCount = fishes.Length;
            foreach (var fish in fishes) fish.OnFishGrab += FishGrabbed;
        }

        private void OnEnable()
        {
            penguinMover.OnStop += CheckGameResults;
            hp.OnAllHpLose += GameLost;
            Pit.OnTriggerPit += GameLost;
        }

        private void OnDisable()
        {
            penguinMover.OnStop -= CheckGameResults;
            hp.OnAllHpLose -= GameLost;
            Pit.OnTriggerPit -= GameLost;
        }

        private void CheckGameResults()
        {
            Debug.Log("OnSTOP");

            if (movesCount.movesCount == 0 && fishCount > 0) GameLost();
            if (fishCount == 0) GameWon();
        }

        private void FishGrabbed()
        {
            fishCount--;
        }

        public event Action OnLevelWon;

        private void GameWon()
        {
            Debug.Log("GameWon");
            winPopUp.ShowPopUp();
            OnLevelWon?.Invoke();
        }

        private void GameLost()
        {
            Debug.Log("Gamelost");
            losePopUp.ShowPopUp();
        }
    }
}