using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public class PowIn : Pow
    {
        public PowIn(int power) : base(power)
        {
        }

        public override float Apply(float a)
        {
            return (float)Math.Pow(a, Power);
        }
    }
}