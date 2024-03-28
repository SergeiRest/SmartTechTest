using Game.Enemy;
using Zenject;

namespace Game
{
    public class GameBehavior
    {
        [InjectLocal] private GameGrid _gameGrid;
        [Inject] private ScoreCounter.ScoreCounter _scoreCounter;

        public void Restart()
        {
            
        }

        public void LevelComplete()
        {
            _gameGrid.Revive();
        }
    }
}