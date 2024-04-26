using Music;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager audioManagerPrefab;


        public override void InstallBindings()
        {
            Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle().NonLazy();
        }
    }
}