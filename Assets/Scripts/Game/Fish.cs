using System;
using Music;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private GameObject grabFx;
        [Inject] private AudioManager audioManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            audioManager.PlaySfx(audioManager.fishGrabSfx);
            OnFishGrab?.Invoke();
            var fx = Instantiate(grabFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(fx, 2f);
        }

        public event Action OnFishGrab;
    }
}