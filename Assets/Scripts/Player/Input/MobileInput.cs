using System;
using UnityEngine;
using Zenject;

namespace Game.Player.Input
{
    public class MobileInput : IPlayerInput
    {
        private InputListener _inputListenerPrefab;
        private InputListener _handler;
        private Vector2 _input;
        
        public event Action<Vector3> DirectionSetted;

        public MobileInput(InputListener inputListenerPrefab)
        {
            _inputListenerPrefab = inputListenerPrefab;
        }
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _handler = diContainer.InstantiatePrefabForComponent<InputListener>(_inputListenerPrefab);
            _handler.OnPlayerDrag += Drag;
        }

        private void Drag(Vector2 position)
        {
            _input = position.normalized;
            DirectionSetted?.Invoke(_input);
        }

        public void Dispose()
        {
            DirectionSetted = null;
            _handler.OnPlayerDrag -= Drag;
        }
    }
}