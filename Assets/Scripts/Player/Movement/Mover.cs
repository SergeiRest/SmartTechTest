using System;
using Game.Player.Input;
using Screen;
using UnityEngine;
using Zenject;

namespace Game.Player.Movement
{
    public class Mover : IDisposable
    {
        [Inject] private IScreenCoordinates _coordinates;
        private IPlayerInput _playerInput;
        private Transform _moveable;
        private Vector3 _defaultPosition;
        private float speed = 30;
        private float offset = 0.5f;

        public Mover(Transform moveable)
        {
            _moveable = moveable;
            _defaultPosition = moveable.position;
        }

        [Inject]
        private void Construct(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
            _playerInput.DirectionSetted += Move;
        }

        private void Move(Vector3 direction)
        {
            Vector3 position = Vector3.Lerp(_moveable.position, _moveable.position + direction, speed * Time.deltaTime);

            position.x = Math.Clamp(position.x, _coordinates.Position.x + offset, -_coordinates.Position.x - offset);
            position.y = _moveable.position.y;
            position.z = _moveable.position.z;

            Debug.Log(_coordinates.Position);

            _moveable.transform.position = position;
        }

        public void SetDefault() => _moveable.position = _defaultPosition;

        public void Dispose()
        {
            _playerInput.DirectionSetted -= Move;
        }
    }
}