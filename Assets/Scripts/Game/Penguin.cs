using System;
using System.Collections;
using Music;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Penguin : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public bool canDestroy;

        private readonly Color hurtColor = new(1, 0, 0, 0.5f);
        private readonly float invFramesDuration = 2;
        private readonly Color normalColor = Color.white;
        private readonly int numberOfFlashes = 5;
        [Inject] private AudioManager audioManager;

        private bool isHurt;

        private void OnEnable()
        {
            SpikesBlock.OnTriggerSpikes += OnHurt;
        }

        private void OnDisable()
        {
            SpikesBlock.OnTriggerSpikes -= OnHurt;
        }

        public event Action OnTakeDamage;

        private void OnHurt()
        {
            if (!isHurt)
            {
                OnTakeDamage?.Invoke();
                audioManager.PlaySfx(audioManager.onHurtSfx);
                isHurt = true;
                StartCoroutine(Invulnerability());
            }
        }

        private IEnumerator Invulnerability()
        {
            for (var i = 0; i < numberOfFlashes; i++)
            {
                spriteRenderer.color = hurtColor;
                yield return new WaitForSeconds(invFramesDuration / (numberOfFlashes * 2));
                spriteRenderer.color = normalColor;
                yield return new WaitForSeconds(invFramesDuration / (numberOfFlashes * 2));
            }

            isHurt = false;
        }
    }
}