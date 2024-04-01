using Zenject;

namespace Game.Weapon
{
    public class WeaponChangerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<WeaponChanger>().FromNew().AsSingle().NonLazy();
        }
    }
}