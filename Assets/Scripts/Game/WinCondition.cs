using System;
using PopUps;
using UnityEngine;
using Zenject;

namespace Game
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private FishList fishes;
        [SerializeField] private PopUpController winPopUp;
        [SerializeField] private PopUpController losePopUp;
        [SerializeField] private PopUpController noSlidesPopUp;
        private int fishCount;
        [Inject] private Hp hp;
        [Inject] private MovesCount movesCount;
        [Inject] private PenguinMover penguinMover;


        private void Start()
        {
            fishCount = fishes.list.Count;
            foreach (var fish in fishes.list) fish.OnFishGrab += FishGrabbed;
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
            if (movesCount.movesCount == 0 && fishCount > 0) NoSlides();
            if (fishCount == 0) GameWon();
        }

        private void FishGrabbed()
        {
            fishCount--;
        }

        public event Action OnLevelWon;

        private void GameWon()
        {
            winPopUp.ShowPopUp();
            OnLevelWon?.Invoke();
        }

        private void GameLost()
        {
            losePopUp.ShowPopUp();
        }

        private void NoSlides()
        {
            noSlidesPopUp.ShowPopUp();
        }
    }
}