using Game.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.PauseService
{
    public class PauseScreen : UIScreen
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _remuse;

        [Inject] private GamePauser _gamePauser;
        [Inject] private ScreenFactory _screenFactory;
        [Inject] private GameBehavior _gameBehavior;
        
        [Inject]
        private void Construct()
        {
            _remuse.onClick.AddListener(Resume);
            _restart.onClick.AddListener(Restart);

            void Resume()
            {
                _gamePauser.Resume();
                _screenFactory.Remove<PauseScreen>();
            }

            void Restart()
            {
                _gameBehavior.Restart();
                Resume();
            }
        }
    }
}