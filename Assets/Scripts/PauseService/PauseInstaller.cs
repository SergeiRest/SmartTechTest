using Zenject;

namespace Game.PauseService
{
    public class PauseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GamePauser>().FromNew().AsSingle().NonLazy();
        }
    }
}