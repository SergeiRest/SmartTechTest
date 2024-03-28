using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyDeathContainer
    {
        [Inject] private ScoreCounter.ScoreCounter _scoreCounter;
        [Inject] private GameBehavior _game;
        
        private int _enemiesCount = 0;
        private int _deadEnemies = 0;

        public void Init(int enemiesCount)
        {
            _enemiesCount = enemiesCount;
            _deadEnemies = 0;
        }

        public void Apply()
        {
            _deadEnemies++;
            _scoreCounter.Increase();

            if (_deadEnemies == _enemiesCount)
            {
                _game.LevelComplete();
            }
        }
    }
}