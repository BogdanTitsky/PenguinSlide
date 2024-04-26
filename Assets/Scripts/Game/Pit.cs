using System;
using UnityEngine;

namespace Game
{
    public class Pit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("WW");
            if (other.CompareTag("Penguin")) OnGameLost?.Invoke();
        }

        public event Action OnGameLost;
    }
}