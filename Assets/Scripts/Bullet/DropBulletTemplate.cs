using System;
using Game.Weapon;
using UnityEngine;
using Zenject;

namespace Game.Bullet
{
    public class DropBulletTemplate : MonoBehaviour
    {
        [Inject] private WeaponChanger _weaponChanger;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private Weapon.Weapon _weapon;

        public event Action<DropBulletTemplate> OnDestroy;

        public void Init(Weapon.Weapon weapon, Sprite sprite)
        {
            _weapon = weapon;
            _spriteRenderer.sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Bullet bullet))
            {
                bullet.Dispose();
                OnDestroy?.Invoke(this);
                
                Dispose();
                _weaponChanger.SetWeapon(_weapon);
            }
        }

        public void Dispose()
        {
            OnDestroy = null;
            Destroy(gameObject);
        }
    }
}