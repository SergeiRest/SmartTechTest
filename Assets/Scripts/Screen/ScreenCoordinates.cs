using UnityEngine;
using Zenject;

namespace Screen
{
    public class ScreenCoordinates : IScreenCoordinates
    {
        public Vector3 Position { get; private set; }

        [Inject]
        private void Construct()
        {
            Position = Camera.main.ScreenToWorldPoint(Vector3.zero);
        }
    }

    public interface IScreenCoordinates
    {
        public Vector3 Position { get; }
    }
}