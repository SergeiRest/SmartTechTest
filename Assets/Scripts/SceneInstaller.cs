using Screen;
using Zenject;

namespace Game
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScreenCoordinates>().FromNew().AsSingle().NonLazy();
        }
    }
}