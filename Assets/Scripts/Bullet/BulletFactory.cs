using Zenject;

namespace Game.Bullet
{
    public class BulletFactory
    {
        [Inject] private DiContainer _diContainer;

        public T Get<T>(T prefab) where T : Bullet
        {
            return _diContainer.InstantiatePrefabForComponent<T>(prefab);
        }
    }
}