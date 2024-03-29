using Game.Bullet;
using Zenject;

namespace Game.Weapon
{
    public class LaserWeapon : Weapon
    {
        [Inject]
        private void Construct(LaserBulletConfig config)
        {
            Bullet = config.BulletPrefab;
        }
    }
}