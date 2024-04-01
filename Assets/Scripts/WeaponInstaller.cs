using Game.Bullet;
using UnityEngine;
using Zenject;

namespace Game
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private LaserBulletConfig _laserConfig;
        [SerializeField] private ThirdBulletConfig _thirdBullet;
        [SerializeField] private DropBulletTemplate _bulletTemplate;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DropBulletTemplate>().FromInstance(_bulletTemplate).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletFactory>().FromNew().AsSingle().NonLazy();

            BulletConfigContainer configs = new BulletConfigContainer();

            Container.BindInterfacesAndSelfTo<BulletConfigContainer>().FromInstance(configs).AsSingle().NonLazy();

            configs.DefaultConfig = _bulletConfig;
            configs.Add(_laserConfig);
            configs.Add(_thirdBullet);

            Container.BindInterfacesAndSelfTo<DropBulletCalculator>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DropBulletCreator>().FromNew().AsSingle().NonLazy();
        }
    }
}