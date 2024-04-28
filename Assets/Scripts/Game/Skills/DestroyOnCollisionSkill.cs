using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Skills
{
    public class DestroyOnCollisionSkill : MonoBehaviour
    {
        [SerializeField] private Button button;
        [Inject] private BlocksList blocks;
        [Inject] private Penguin penguin;

        public event Action OnCollisionSkillOn;

        public void MakeAbleToDestroy()
        {
            OnCollisionSkillOn?.Invoke();
            penguin.canDestroy = true;
            button.interactable = false;
        }
    }
}