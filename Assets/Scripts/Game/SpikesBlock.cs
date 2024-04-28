using System;
using UnityEngine;

namespace Game
{
    public class SpikesBlock : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Penguin"))
                OnTriggerSpikes?.Invoke();
        }

        public static event Action OnTriggerSpikes;
    }
}