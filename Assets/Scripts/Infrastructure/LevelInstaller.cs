using Game;
using Game.Skills;
using Shop;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PenguinMover penguinMover;
        [SerializeField] private WinCondition winCondition;
        [SerializeField] private ResourceReward resourceReward;
        [SerializeField] private Penguin penguin;
        [SerializeField] private DestroyOnCollisionSkill destroyOnCollisionSkill;
        [SerializeField] private BlocksList blocksList;
        [SerializeField] private MovesCount movesCount;
        [SerializeField] private Hp hp;

        public override void InstallBindings()
        {
            Container.Bind<PenguinMover>().FromInstance(penguinMover).AsSingle().NonLazy();
            Container.Bind<WinCondition>().FromInstance(winCondition).AsSingle().NonLazy();
            Container.Bind<ResourceReward>().FromInstance(resourceReward).AsSingle().NonLazy();
            Container.Bind<Penguin>().FromInstance(penguin).AsSingle().NonLazy();
            Container.Bind<DestroyOnCollisionSkill>().FromInstance(destroyOnCollisionSkill).AsSingle().NonLazy();
            Container.Bind<BlocksList>().FromInstance(blocksList).AsSingle().NonLazy();
            Container.Bind<MovesCount>().FromInstance(movesCount).AsSingle().NonLazy();
            Container.Bind<Hp>().FromInstance(hp).AsSingle().NonLazy();
        }
    }
}