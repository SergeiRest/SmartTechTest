using System;
using Game.Player.Movement;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class Player : IDisposable
    {
        private Mover _mover;
        private Transform _body;

        public Player(Transform body)
        {
            _body = body;
        }
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _mover = new Mover(_body);
            
            diContainer.Inject(_mover);
        }

        public void Dispose()
        {
            _mover?.Dispose();
        }
    }
}