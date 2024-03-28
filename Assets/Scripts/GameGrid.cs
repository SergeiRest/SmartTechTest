using Game.Enemy;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameGrid : MonoBehaviour
    {
        [Inject] private EnemyDeathContainer _deathContainer;
        
        [field: SerializeField] public Transform[] EnemyPoints { get; private set; }

        private EnemyFactory _enemyFactory;

        public EnemyTemplate[] Enemies { get; private set; }
        
        [Inject]
        private void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            Enemies = new EnemyTemplate[EnemyPoints.Length];
            for (int i = 0; i < EnemyPoints.Length; i++)
            {
                EnemyTemplate template = _enemyFactory.Get();
                template.transform.position = EnemyPoints[i].position;
                Enemies[i] = template;
            }
            
            InitContainer(Enemies.Length);
        }

        public void Revive()
        {
            foreach (var enemy in Enemies)
            {
                enemy.gameObject.SetActive(true);
            }
            
            InitContainer(Enemies.Length);
        }

        private void InitContainer(int enemiesCount) 
            => _deathContainer.Init(enemiesCount);
    }
}