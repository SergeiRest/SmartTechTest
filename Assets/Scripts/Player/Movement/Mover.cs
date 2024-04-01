﻿using System;
using Game.Player.Input;
using UnityEngine;
using Zenject;

namespace Game.Player.Movement
{
    public class Mover : IDisposable
    {
        private IPlayerInput _playerInput;
        private Transform _moveable;
        private Vector3 _defaultPosition;

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
            Vector3 position = Vector3.Lerp(_moveable.position, _moveable.position + direction, 10 * Time.deltaTime);
            position.y = _moveable.position.y;
            position.z = _moveable.position.z;

            _moveable.transform.position = position;
        }

        public void SetDefault() => _moveable.position = _defaultPosition;

        public void Dispose()
        {
            _playerInput.DirectionSetted -= Move;
        }
    }
}