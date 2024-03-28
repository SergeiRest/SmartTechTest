using System;

namespace Game.ScoreCounter
{
    public class ScoreCounter : IDisposable
    {
        private int _killCount = 0;

        public Action<int> Increased;

        public void Increase()
        {
            _killCount++;
            Increased?.Invoke(_killCount);
        }

        public void Clear()
        {
            _killCount = 0;
        }

        public void Dispose()
        {
            Increased = null;
        }
    }
}