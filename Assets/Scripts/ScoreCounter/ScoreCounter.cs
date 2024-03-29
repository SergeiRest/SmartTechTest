using System;

namespace Game.ScoreCounter
{
    public class ScoreCounter : IDisposable
    {
        private int _killCount = 0;

        public Action<int> KillCountChanged;

        public void Increase()
        {
            _killCount++;
            SendEvent();
        }

        public void Clear()
        {
            _killCount = 0;
            SendEvent();
        }

        private void SendEvent() 
            => KillCountChanged?.Invoke(_killCount);

        public void Dispose()
        {
            KillCountChanged = null;
        }
    }
}