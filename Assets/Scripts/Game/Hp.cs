using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Hp : MonoBehaviour
    {
        [SerializeField] private List<GameObject> hearts;

        private void OnEnable()
        {
            SpikesBlock.OnTriggerSpikes += GetHpDamage;
        }

        private void OnDisable()
        {
            SpikesBlock.OnTriggerSpikes -= GetHpDamage;
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