using System;
using Game.Player.Movement;
using Game.Weapon;
using Screen;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class Player : IDisposable
    {
        private DiContainer _diContainer;
        private Mover _mover;
        private Transform _body;

        private float _attackInterval = 0f;
        private Weapon.Weapon _weapon;
        private IDisposable _shotDisposable;

        public Player(Transform body)
        {
            _body = body;
        }
        
        [Inject]
        private void Construct(DiContainer diContainer, PlayerConfig config)
        {
            _diContainer = diContainer;
            _mover = new Mover(_body);
            
            diContainer.Inject(_mover);

            _attackInterval = config.AttackInterval;
            SetWeapon<BaseWeapon>();
        }

        private void TryShoot()
        {
            _shotDisposable = Observable.Interval(_attackInterval.Sec()).Subscribe(_ =>
            {
                _weapon.Shoot();
            });
        }

        public void Dispose()
        {
            _mover?.Dispose();
            _shotDisposable?.Dispose();
        }

        public void SetWeapon<T>() where T : Weapon.Weapon, new()
        {
            _shotDisposable?.Dispose();
            _weapon = new T();
            _diContainer.Inject(_weapon);
            TryShoot();
        }
    }
}