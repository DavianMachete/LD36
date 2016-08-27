using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public class Elastic : Interpolation
    {
        private readonly float _value;
        private readonly float _power;

        public Elastic(float value, float power)
        {
            _value = value;
            _power = power;
        }

        public override float Apply(float a)
        {
            if (a <= 0.5f)
            {
                a *= 2;
                return (float) Math.Pow(_value, _power*(a - 1))*(float) Math.Sin(a*20)*1.0955f/2;
            }
            a = 1 - a;
            a *= 2;
            return 1 - (float) Math.Pow(_value, _power*(a - 1))*(float) Math.Sin((a)*20)*1.0955f/2;
        }
    }
}