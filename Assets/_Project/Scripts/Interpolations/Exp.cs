using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public class Exp : Interpolation
    {
        private readonly float _value;
        private readonly float _power;
        private readonly float _min;
        private readonly float _scale;

        public Exp(float value, float power)
        {
            _value = value;
            _power = power;
            _min = (float) Math.Pow(value, -power);
            _scale = 1/(1 - _min);
        }

        public override float Apply(float a)
        {
            if (a <= 0.5f) return ((float) Math.Pow(_value, _power*(a*2 - 1)) - _min)*_scale/2;
            return (2 - ((float) Math.Pow(_value, -_power*(a*2 - 1)) - _min)*_scale)/2;
        }
    }
}