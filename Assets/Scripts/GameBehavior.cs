using Game.Bullet;
using Game.Enemy;
using Zenject;

namespace Game
{
    public class GameBehavior
    {
        [InjectLocal] private GameGrid _gameGrid;
        [Inject] private ScoreCounter.ScoreCounter _scoreCounter;
        [Inject] private Player.Player _player;
        [Inject] private DropBulletCreator _bulletCreator;

        public void Restart()
        {
            _player.SetDefault();
            _scoreCounter.Clear();
            _gameGrid.Revive();
            _bulletCreator.Clear();
        }

        public void LevelComplete()
        {
            _gameGrid.Revive();
        }
    }
}