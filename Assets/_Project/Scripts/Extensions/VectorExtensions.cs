using Assets._Project.Scripts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public static class VectorExtensions
    {
        public static Vector3 RotateAround(this Vector3 instance, Vector3 origin, float rotation)
        {
            return (Quaternion.Euler(0, 0, rotation) * (instance - origin)) + origin;
        }
        public static Vector2 RotateAround(this Vector2 instance, Vector2 origin, float rotation)
        {
            return (Quaternion.Euler(0, 0, rotation) * (instance - origin)).ToVector2() + origin;
        }
        public static float Angle(this Vector2 vector)
        {
            var normalized = vector.normalized;
            return Mathf.Atan2(normalized.y, normalized.x);
        }

        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 ToVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, vector.y, 0f);
        }

        public static Vector2 Direction(this float angle)
        {
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        }

        public static Vector2 Lengthen(this Vector2 vector, float length)
        {
            return vector * length;
        }
        public static float AngleTo(this Vector3 vector, Vector3 other)
        {
            return Mathf.Atan2(other.y - vector.y, other.x - vector.x);
        }

        public static Quaternion ToQuaternion(this float radians)
        {
            return Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            return new Vector2(
                MathHelper.CatmullRom(value1.x, value2.x, value3.x, value4.x, amount),
                MathHelper.CatmullRom(value1.y, value2.y, value3.y, value4.y, amount));
        }

        public static Vector3 Bezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            var u = 1.0f - t;
            var tt = t * t;
            var uu = u * u;
            var uuu = uu * u;
            var ttt = tt * t;

            var p = uuu * p0; //first term
            p += 3 * uu * t * p1; //second term
            p += 3 * u * tt * p2; //third term
            p += ttt * p3; //fourth term

            return p;
        }
    }
}
