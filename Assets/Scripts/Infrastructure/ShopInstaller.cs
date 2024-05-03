using Shop;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class ShopInstaller : MonoInstaller
    {
        [SerializeField] private CrystalBalance crystalBalance;
        [SerializeField] private FishBalance fishBalance;

        public override void InstallBindings()
        {
            // Container.Bind<FishBalance>().FromInstance(fishBalance).AsSingle().NonLazy();
            // Container.Bind<CrystalBalance>().FromComponentInNewPrefab(crystalBalance).AsSingle().NonLazy();
        }
    }
}