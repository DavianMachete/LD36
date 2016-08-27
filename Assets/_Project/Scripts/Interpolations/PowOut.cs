using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public class PowOut : Pow
    {
        public PowOut(int power) : base(power)
        {
        }

        public override float Apply(float a)
        {
            return (float)Math.Pow(a - 1, Power) * (Power % 2 == 0 ? -1 : 1) + 1;
        }
    }
}