using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Hp : MonoBehaviour
    {
        [SerializeField] private List<GameObject> hearts;
        [Inject] private Penguin penguin;

        private void OnEnable()
        {
            penguin.OnTakeDamage += GetHpDamage;
        }

        private void OnDisable()
        {
            penguin.OnTakeDamage -= GetHpDamage;
        }

        public event Action OnAllHpLose;

        private void GetHpDamage()
        {
            var heartToDestroy = hearts[0];
            hearts.RemoveAt(0);
            Destroy(heartToDestroy);
            if (hearts.Count == 0) OnAllHpLose?.Invoke();
        }
    }
}