using System;
using UnityEngine;

namespace Game.Player.Input
{
    public interface IPlayerInput : IDisposable
    {
        public event Action<Vector3> DirectionSetted;
    }
}