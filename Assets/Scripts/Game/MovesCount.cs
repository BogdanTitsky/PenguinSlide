using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public class MovesCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private int maxMovesCount = 3;
        public int movesCount = 3;
        [Inject] private PenguinMover penguinMover;

        private void Start()
        {
            movesCount = maxMovesCount;
            LoadMovesCount();
        }

        private void OnEnable()
        {
            penguinMover.OnDragRelease += DecreaseMoveCount;
            LoadMovesCount();
        }

        private void OnDisable()
        {
            penguinMover.OnDragRelease -= DecreaseMoveCount;
        }

        private void DecreaseMoveCount()
        {
            movesCount--;
            LoadMovesCount();
        }

        public void IncreaseMoveCount()
        {
            movesCount++;
            LoadMovesCount();
        }

        private void LoadMovesCount()
        {
            countText.text = $"{movesCount}/{maxMovesCount}";
        }
    }
}