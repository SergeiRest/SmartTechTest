using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Bullet
{
    public class BulletConfigContainer
    {
        private Dictionary<Type, BulletConfig> _container = new Dictionary<Type, BulletConfig>();
        public BulletConfig DefaultConfig { get; set; }

        public void Add(BulletConfig config)
        {
            Type type = config.GetType();
            _container.Add(type, config);
        }

        public T Get<T>() where T : BulletConfig
        {
            Type key = typeof(T);
            if (_container.TryGetValue(key, out var config))
            {
                return (T)config;
            }
            else
            {
                Debug.LogError("Config is not available");
                return null;
            }
        }

        public T GetRandom<T>() where T : BulletConfig
        {
            int random = Random.Range(0, _container.Count);
            
            return (T)_container.ElementAt(random).Value;
        }
    }
}