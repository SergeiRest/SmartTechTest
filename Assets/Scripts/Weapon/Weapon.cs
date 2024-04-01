using System.Collections.Generic;
using Game.Bullet;
using UnityEngine;
using Zenject;

namespace Game.Weapon
{
    public abstract class Weapon : IWeapon
    {
        [Inject] private BulletFactory _bulletFactory;
        [Inject] private WeaponPoint _weaponPoint;
        
        protected Bullet.Bullet Bullet;
        private List<Bullet.Bullet> _bullets = new List<Bullet.Bullet>();
        
        public virtual void Shoot()
        {
            var bullet = _bulletFactory.Get(Bullet);
            bullet.transform.position = _weaponPoint.transform.position;
            bullet.Kill += Remove;
            
            _bullets.Add(bullet);
        }

        private void Remove(Bullet.Bullet bullet)
        {
            _bullets.Remove(bullet);
            bullet.Kill = null;
        }

        public void Clear()
        {
            foreach (var bullet in _bullets)
            {
                bullet.Kill = null;
                bullet.Dispose();
            }
            
            _bullets.Clear();
        }
    }
}