using UnityEngine;
using Zenject;

namespace Game
{
    public class MovesCount : MonoBehaviour
    {
        public int movesCount = 3;
        [Inject] private PenguinMover penguinMover;

        private void OnEnable()
        {
            penguinMover.onDragRelease += DecreaseMoveCount;
        }

        private void OnDisable()
        {
            penguinMover.onDragRelease -= DecreaseMoveCount;
        }

        private void DecreaseMoveCount()
        {
            movesCount--;
        }
    }
}