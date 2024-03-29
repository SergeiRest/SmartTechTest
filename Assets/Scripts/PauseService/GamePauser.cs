using UnityEngine;

namespace Game.PauseService
{
    public class GamePauser
    {
        public void Pause()
            => Time.timeScale = 0;

        public void Resume()
            => Time.timeScale = 1;
    }
}