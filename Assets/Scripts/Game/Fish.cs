using System;
using Music;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Fish : MonoBehaviour
    {
        [Inject] private AudioManager audioManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            audioManager.PlatSfx(audioManager.fishGrabSfx);
            OnFishGrab?.Invoke();
            Destroy(gameObject);
        }

        public event Action OnFishGrab;
    }
}