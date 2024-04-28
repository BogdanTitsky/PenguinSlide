using System;
using UnityEngine;

namespace Game
{
    public class Pit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Penguin")) OnTriggerPit?.Invoke();
        }

        public static event Action OnTriggerPit;
    }
}