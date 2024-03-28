using System;
using Screen;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Bullet
{
    public class Bullet : MonoBehaviour, IDisposable
    {
        private BulletMover _mover;
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _mover = new BulletMover(transform, this);

            diContainer.Inject(_mover);
        }

        public void Dispose()
        {
            _mover.Dispose();
            
            Destroy(gameObject);
        }
    }

    public class BulletMover : IDisposable
    {
        [Inject] private IScreenCoordinates _coordinates;
        
        private float speed = 10;
        private IDisposable _moveDisposable;
        private Transform _transform;
        private IDisposable _mainDisposable;

        public BulletMover(Transform transform, IDisposable main)
        {
            _transform = transform;
            _mainDisposable = main;
            StartMove();
        }
        
        private void StartMove()
        {
            _moveDisposable = Observable.EveryUpdate().Subscribe(_ =>
            {
                Move();
            });
        }

        private void Move()
        {
            _transform.position = Vector3.Lerp(_transform.position, _transform.position + Vector3.up,
                speed * Time.deltaTime);
            
            if(!IsOnView())
                _mainDisposable.Dispose();
        }

        private bool IsOnView()
        {
            if (_transform.position.y > _coordinates.Position.y * 1.5f)
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            _moveDisposable?.Dispose();
        }
    }
}