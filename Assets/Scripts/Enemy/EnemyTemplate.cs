using System;
using Game.Bullet;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyTemplate : MonoBehaviour
    {
        [Inject] private DropBulletCalculator _bulletCalculator;
        private EnemyTrigger _trigger;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _trigger = new EnemyTrigger(gameObject);
            
            diContainer.Inject(_trigger);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _bulletCalculator.Calculate();
            if (col.TryGetComponent(out Bullet.Bullet bullet))
            {
                bullet.Dispose();
                _trigger.Triggered();
            }
        }
    }

    public class EnemyTrigger
    {
        [Inject] private EnemyDeathContainer _enemyDeathContainer;

        private GameObject _model;

        public EnemyTrigger(GameObject model)
        {
            _model = model;
        }
        
        public void Triggered()
        {
            _model.SetActive(false);
            _enemyDeathContainer.Apply();
        }
    }
}