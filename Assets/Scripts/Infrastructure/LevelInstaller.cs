using Game;
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

        public override void InstallBindings()
        {
            Container.Bind<PenguinMover>().FromInstance(penguinMover).AsSingle().NonLazy();
            Container.Bind<WinCondition>().FromInstance(winCondition).AsSingle().NonLazy();
            Container.Bind<ResourceReward>().FromInstance(resourceReward).AsSingle().NonLazy();
        }
    }
}