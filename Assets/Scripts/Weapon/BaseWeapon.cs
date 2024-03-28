using Game.Bullet;
using Zenject;

namespace Game.Weapon
{
    public class BaseWeapon : Weapon
    {
        [Inject]
        private void Construct(BulletConfig bulletConfig)
        {
            Bullet = bulletConfig.BulletPrefab;
        }
    }
}