﻿using Game.Bullet;
using Zenject;

namespace Game.Weapon
{
    public class LaserWeapon : Weapon
    {
        [Inject]
        private void Construct(BulletConfigContainer configs)
        {
            Bullet = configs.Get<LaserBulletConfig>().BulletPrefab;
        }
    }
}