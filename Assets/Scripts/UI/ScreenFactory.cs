using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class ScreenFactory
    {
        [Inject] private DiContainer _diContainer;
        
        private Dictionary<Type, UIScreen> _screens = new Dictionary<Type, UIScreen>();

        public void Get<T>() where T : UIScreen
        {
            T prefab = Resources.LoadAll<T>("Screens").First();
            T screen = _diContainer.InstantiatePrefabForComponent<T>(prefab);
            
            _screens.Add(typeof(T), screen);
        }

        public void Remove<T>() where T : UIScreen
        {
            Type type = typeof(T);
            if (_screens.TryGetValue(type, out var screen))
            {
                screen.Close();
                _screens.Remove(type);
            }
        }
    }
}