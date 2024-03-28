using System;
using UnityEngine;

namespace Game
{
    public static class Extensions
    {
        public static TimeSpan Sec(this float timer)
        {
            float milisec = timer * 1000;
            return new TimeSpan(0, 0, 0, 0, (int)milisec);
        }

    }
}