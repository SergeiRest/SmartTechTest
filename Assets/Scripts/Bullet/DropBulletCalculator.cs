using System;
using System.Collections.Generic;
using Game.Weapon;
using Screen;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Bullet
{
    public class DropBulletCalculator
    {
        [Inject] private BulletConfigContainer _bulletConfig;
        [Inject] DropBulletCreator _creator;

        public void Calculate()
        {
            var selected = _bulletConfig.GetRandom<BulletConfig>();
            Sprite sprite = selected.ShowSprite;
            Debug.Log(selected.GetType());

            if (selected.GetType() == typeof(LaserBulletConfig))
            {
                _creator.Create(new LaserWeapon(), sprite);
            }
            else if (selected.GetType() == typeof(ThirdBulletConfig))
            {
                _creator.Create(new ThirdWeapon(), sprite);
            }
        }
    }

    public class DropBulletCreator
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private DropBulletTemplate _bulletTemplate;
        [Inject] private IScreenCoordinates _screen;

        private float xScreenOffset = 0.8f;
        private float yScreenOffset = 0.8f;

        private List<DropBulletTemplate> _bullets = new List<DropBulletTemplate>();
        
        public void Create(Weapon.Weapon weapon, Sprite sprite)
        {
            var model = _diContainer.InstantiatePrefabForComponent<DropBulletTemplate>(_bulletTemplate);
            model.Init(weapon, sprite);

            float x = Random.Range(_screen.Position.x * xScreenOffset, -_screen.Position.x * xScreenOffset);
            float y = Random.Range(_screen.Position.y * yScreenOffset, -_screen.Position.y * yScreenOffset);
            
            model.transform.position = new Vector3(x, y, 0);
            _diContainer.Inject(weapon);

            model.OnDestroy += Remove;
            _bullets.Add(model);
        }

        private void Remove(DropBulletTemplate template)
        {
            _bullets.Remove(template);
            template.OnDestroy -= Remove;
        }

        public void Clear()
        {
            foreach (var bullet in _bullets)
            {
                bullet.OnDestroy -= Remove;
                bullet.Dispose();
            }
            
            _bullets.Clear();
        }
        
    }
}