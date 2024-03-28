using UnityEngine;

namespace Game.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Data/Player/Config")]
    public class PlayerConfig : ScriptableObject
    {
        public float AttackInterval;
    }
}