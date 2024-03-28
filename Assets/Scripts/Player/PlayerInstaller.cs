using Game.Player.Input;
using Game.Weapon;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputListener _inputListenerPrefab;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private WeaponPoint _weaponPoint;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MobileInput>().FromNew().AsSingle().WithArguments(_inputListenerPrefab).NonLazy();
            Container.BindInterfacesAndSelfTo<Player>().FromNew().AsSingle().WithArguments(_playerTransform).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerConfig>().FromInstance(_playerConfig).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponPoint>().FromInstance(_weaponPoint).AsSingle().NonLazy();
        }
    }
}