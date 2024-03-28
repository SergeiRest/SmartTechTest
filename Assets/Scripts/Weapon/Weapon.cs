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
        
        public virtual void Shoot()
        {
            var bullet = _bulletFactory.Get(Bullet);
            bullet.transform.position = _weaponPoint.transform.position;
        }
    }
}