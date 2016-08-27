using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public class Pow : Interpolation
    {
        protected readonly int Power;

        public Pow(int power)
        {
            Power = power;
        }

        public override float Apply(float a)
        {
            if (a <= 0.5f) return (float) Math.Pow(a*2, Power)/2;
            return (float) Math.Pow((a - 1)*2, Power)/(Power%2 == 0 ? -2 : 2) + 1;
        }
    }
}