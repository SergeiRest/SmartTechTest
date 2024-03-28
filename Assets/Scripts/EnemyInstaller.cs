using Game.Enemy;
using UnityEngine;
using Zenject;

namespace Game
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyTemplate _enemyPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyFactory>().FromNew().AsSingle().WithArguments(_enemyPrefab)
                .NonLazy();

            Container.BindInterfacesAndSelfTo<ScoreCounter.ScoreCounter>().FromNew().AsSingle().NonLazy();
        }
    }
}