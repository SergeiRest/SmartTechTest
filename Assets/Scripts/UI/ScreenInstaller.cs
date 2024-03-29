using Zenject;

namespace Game.UI
{
    public class ScreenInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScreenFactory>().FromNew().AsSingle().NonLazy();
        }
    }
}