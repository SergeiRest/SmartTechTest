using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Weapon
{
    public class WeaponChanger
    {
        [Inject] private Player.Player _player;

        public WeaponChanger()
        {
            Debug.Log("Start");
            Observable.Timer(5f.Sec()).Subscribe(_ =>
            {
                SetWeapon();
            });
        }
        
        public void SetWeapon()
        {
            Debug.Log("Change");
            _player.SetWeapon<LaserWeapon>();
        }
    }
}