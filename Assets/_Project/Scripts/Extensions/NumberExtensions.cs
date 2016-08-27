using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public static class NumberExtensions
    {
        public static int Wrap(this int value, int max)
        {
            if (value < 0)
                return (max + 1) + value;
            if (value > max)
                return (value - max) - 1;
            return value;
        }

        public static float ToRadians(this float degrees)
        {
            return degrees * Mathf.Deg2Rad;
        }

        public static float ToDegrees(this float radians)
        {
            return radians * Mathf.Rad2Deg;
        }
    }
}
