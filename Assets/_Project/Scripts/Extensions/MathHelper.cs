using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Extensions
{
    public static class MathHelper
    {
        public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            double amountSquared = amount * amount;
            double amountCubed = amountSquared * amount;
            return (float)(0.5 * (2.0 * value2 +
                (value3 - value1) * amount +
                (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        public static float ClampAngle(float radians)
        {
            var degrees = radians * Mathf.Rad2Deg;

            while (degrees < 0)
                degrees += 360f;
            while (degrees > 360f)
                degrees -= 360f;

            return degrees * Mathf.Deg2Rad;
        }
    }
}
