using Game.Bullet;
using Zenject;

namespace Game.Weapon
{
    public class ThirdWeapon : Weapon
    {
        [Inject]
        private void Construct(BulletConfigContainer configs)
        {
            Bullet = configs.Get<ThirdBulletConfig>().BulletPrefab;
        }
    }
}