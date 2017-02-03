using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessArena.Utilities
{
    struct Vec2
    {
        public double X { get; }
        public double Y { get; }
        public double Magnitude { get; }

        public Vec2(double x, double y)
        {
            X = x;
            Y = y;
            Magnitude = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public static Vec2 operator +(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vec2 operator -(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vec2 operator -(Vec2 v1)
        {
            return new Vec2(-v1.X, -v1.Y);
        }

        public static bool operator <(Vec2 v1, Vec2 v2)
        {
            return v1.Magnitude < v2.Magnitude;
        }

        public static bool operator >(Vec2 v1, Vec2 v2)
        {
            return v1.Magnitude > v2.Magnitude;
        }

        public static bool operator <=(Vec2 v1, Vec2 v2)
        {
            return v1.Magnitude <= v2.Magnitude;
        }

        public static bool operator >=(Vec2 v1, Vec2 v2)
        {
            return v1.Magnitude >= v2.Magnitude;
        }
    }
}
