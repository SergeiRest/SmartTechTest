using Game.Player.Input;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputListener _inputListenerPrefab;
        [SerializeField] private Transform _playerTransform;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MobileInput>().FromNew().AsSingle().WithArguments(_inputListenerPrefab).NonLazy();
            Container.BindInterfacesAndSelfTo<Player>().FromNew().AsSingle().WithArguments(_playerTransform).NonLazy();
        }
    }
}