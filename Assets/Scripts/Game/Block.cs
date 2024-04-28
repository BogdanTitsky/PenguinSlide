using Game.Skills;
using Music;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private Collider2D collider2D;
        [SerializeField] private GameObject breakFx;

        [Inject] private AudioManager audioManager;
        [Inject] private BlocksList blocks;
        [Inject] private DestroyOnCollisionSkill destroyOnCollisionSkill;
        [Inject] private Penguin penguin;

        private void OnEnable()
        {
            destroyOnCollisionSkill.OnCollisionSkillOn += MakeColliderIsTrigger;
        }

        private void OnDisable()
        {
            destroyOnCollisionSkill.OnCollisionSkillOn -= MakeColliderIsTrigger;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (penguin.canDestroy) DestroyBlock();
        }

        public void DestroyBlock()
        {
            blocks.list.Remove(this);
            audioManager.PlatSfx(audioManager.fishGrabSfx);
            var fx = Instantiate(breakFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(fx, 2f);
        }

        private void MakeColliderIsTrigger()
        {
            collider2D.isTrigger = true;
        }
    }
}