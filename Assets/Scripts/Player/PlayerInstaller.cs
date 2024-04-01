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
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<MobileInput>().FromNew().AsSingle().WithArguments(_inputListenerPrefab).NonLazy();
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<Player>().FromNew().AsSingle().WithArguments(_playerTransform).NonLazy();
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<PlayerConfig>().FromInstance(_playerConfig).AsSingle().NonLazy();
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<WeaponPoint>().FromInstance(_weaponPoint).AsSingle().NonLazy();
        }
    }
}