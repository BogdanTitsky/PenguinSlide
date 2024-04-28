using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Skills
{
    public class DestroyRandomBlockSkill : MonoBehaviour
    {
        [SerializeField] private Button button;
        [Inject] private BlocksList blocks;


        public void DestroyRandomBlock()
        {
            if (blocks.list.Count == 0)
            {
                button.interactable = false;
                return;
            }

            var randomIndex = Random.Range(0, blocks.list.Count);
            var blockToDestroy = blocks.list[randomIndex];
           
            blockToDestroy.DestroyBlock();
            if (blocks.list.Count == 0)
                button.interactable = false;
        }
    }
}