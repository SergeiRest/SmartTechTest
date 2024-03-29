using UnityEngine;

namespace Game.UI
{
    public class UIScreen : MonoBehaviour, IUI
    {
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}