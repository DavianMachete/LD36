using System;

namespace Assets._Project.Scripts.Tweens.Interpolations
{
    public abstract class Interpolation
    {
        public abstract float Apply(float a);

        public virtual float Apply(float start, float end, float a)
        {
            return start + (end - start)*Apply(a);
        }

        public static readonly Interpolation Linear = new Linear();
        public static readonly Interpolation Pow2 = new Pow(2);
        public static readonly Interpolation Pow3 = new Pow(3);
        public static readonly Interpolation Pow4 = new Pow(4);
        public static readonly Interpolation Pow5 = new Pow(5);
        public static readonly Interpolation PowIn2 = new PowIn(2);
        public static readonly Interpolation PowIn3 = new PowIn(3);
        public static readonly Interpolation PowIn4 = new PowIn(4);
        public static readonly Interpolation PowIn5 = new PowIn(5);
        public static readonly Interpolation PowOut2 = new PowOut(2);
        public static readonly Interpolation PowOut3 = new PowOut(3);
        public static readonly Interpolation PowOut4 = new PowOut(4);
        public static readonly Interpolation PowOut5 = new PowOut(5);
        public static readonly Interpolation Exp5 = new Exp(2, 5);
        public static readonly Interpolation Exp10 = new Exp(2, 10);
        public static readonly Interpolation Elastic = new Elastic(2, 10);
        public static readonly Interpolation Cubic = new Hermite();

        public static Interpolation Get(InterpolationType type)
        {
            switch (type)
            {
                case InterpolationType.Linear: return Linear;
                case InterpolationType.Pow2: return Pow2;
                case InterpolationType.Pow3: return Pow3;
                case InterpolationType.Pow4: return Pow4;
                case InterpolationType.Pow5: return Pow5;
                case InterpolationType.PowIn2: return PowIn2;
                case InterpolationType.PowIn3: return PowIn3;
                case InterpolationType.PowIn4: return PowIn4;
                case InterpolationType.PowIn5: return PowIn5;
                case InterpolationType.PowOut2: return PowOut2;
                case InterpolationType.PowOut3: return PowOut3;
                case InterpolationType.PowOut4: return PowOut4;
                case InterpolationType.PowOut5: return PowOut5;
                case InterpolationType.Exp5: return Exp5;
                case InterpolationType.Exp10: return Exp10;
                case InterpolationType.Elastic: return Elastic;
                case InterpolationType.Cubic: return Cubic;
            }
            throw new ArgumentException(type.ToString());
        }
    }
}