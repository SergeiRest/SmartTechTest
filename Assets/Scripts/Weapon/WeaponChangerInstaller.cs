using Zenject;

namespace Game.Weapon
{
    public class WeaponChangerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponChanger>().FromNew().AsSingle().NonLazy();
        }
    }
}