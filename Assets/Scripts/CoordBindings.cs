using Screen;
using Zenject;

namespace Game
{
    public class CoordBindings : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IScreenCoordinates>().To<ScreenCoordinates>().FromNew().AsSingle().NonLazy();
        }
    }
}