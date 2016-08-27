using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public class Hermite : Interpolation
    {
        public override float Apply(float a)
        {
            return QLerp(0, 1f, a);
        }

        private float QLerp(float min, float max, float weight)
        {
            return SmoothStep(min, 0f, max, 0f, weight);
        }

        private float SmoothStep(float v1, float t1, float v2, float t2, float weight)
        {
            // value1, tangent1, value2, tangent2
            float sCubed = weight*weight*weight;
            float sSquared = weight*weight;
            float result = 0f;
            if (Math.Abs(weight) < 0.00001f)
            {
                result = v1;
            }
            else if (Math.Abs(weight - 1.0f) < 0.00001f)
            {
                result = v2;
            }
            else result = (2*v1 - 2*v2 + t2 + t1)*sCubed + (3*v2 - 3*v1 - 2*t1 - t2)*sSquared + t1*weight + v1;
            
            return result;
        }
    }
}