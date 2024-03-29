using Game.Bullet;
using UnityEngine;
using Zenject;

namespace Game
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private LaserBulletConfig _laserConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BulletFactory>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletConfig>().FromInstance(_bulletConfig).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LaserBulletConfig>().FromInstance(_laserConfig).AsSingle().NonLazy();
        }
    }
}