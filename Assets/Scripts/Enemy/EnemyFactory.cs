using Zenject;

namespace Game.Enemy
{
    public class EnemyFactory
    {
        [Inject] private DiContainer _diContainer;
        
        private EnemyTemplate prefab;

        public EnemyFactory(EnemyTemplate template)
        {
            prefab = template;
        }

        public EnemyTemplate Get()
        {
            return _diContainer.InstantiatePrefabForComponent<EnemyTemplate>(prefab);
        }
    }
}