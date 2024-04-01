using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Weapon
{
    public class WeaponChanger
    {
        [Inject] private Player.Player _player;

        public void SetWeapon<T>(T weapon) where T : Weapon
        {
            Debug.Log("Change");
            _player.SetWeapon<T>(weapon);
        }
    }
}