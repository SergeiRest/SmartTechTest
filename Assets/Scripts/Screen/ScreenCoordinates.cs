using UnityEngine;
using Zenject;

namespace Screen
{
    public class ScreenCoordinates
    {
        public Vector3 Position { get; private set; }

        [Inject]
        private void Construct()
        {
            Position = Camera.main.ScreenToWorldPoint(Vector3.zero);
        }
    }
}