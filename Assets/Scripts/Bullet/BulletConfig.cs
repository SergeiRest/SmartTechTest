using UnityEngine;

namespace Game.Bullet
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Data/Bullet/BaseBullet")]
    public class BulletConfig : ScriptableObject
    {
        public Bullet BulletPrefab;
        public int Damage;
    }
}