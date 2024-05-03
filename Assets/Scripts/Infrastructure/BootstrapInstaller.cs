using Music;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager audioManagerPrefab;
        [SerializeField] private GameData gameData;


        public override void InstallBindings()
        {
            Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle().NonLazy();
            Container.Bind<GameData>().FromInstance(gameData).AsSingle().NonLazy();
        }
    }
}