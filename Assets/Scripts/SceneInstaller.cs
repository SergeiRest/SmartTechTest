using Game.Enemy;
using UnityEngine;
using Zenject;

namespace Game
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameGrid _gridInstance;

        public override void InstallBindings()
        {
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<GameBehavior>().FromNew().AsSingle().NonLazy();
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<GameGrid>().FromInstance(_gridInstance).AsSingle();
            ProjectContext.Instance.Container.BindInterfacesAndSelfTo<EnemyDeathContainer>().FromNew().AsSingle()
                .NonLazy();

        }

    }
}
    