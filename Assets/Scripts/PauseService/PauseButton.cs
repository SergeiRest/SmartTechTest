using Game.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.PauseService
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _interactable;
     
        [Inject] private GamePauser _gamePauser;
        [Inject] private ScreenFactory _screenFactory;

        [Inject]
        private void Construct()
        {
            _interactable.onClick.AddListener(Pause);

            void Pause()
            {
                _screenFactory.Get<PauseScreen>();
                _gamePauser.Pause();
            }
        }
    }
}