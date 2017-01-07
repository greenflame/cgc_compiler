using System;

namespace cgc_compiler
{
    public class Metrics
    {
        public Metrics()
        {
        }

        public static float Distance(float p1, float p2)
        {
            return Math.Abs(p2 - p1);
        }

        public static float Distance(AGameObject o1, AGameObject o2)
        {
            return Distance(o1.Position, o2.Position);
        }

        public static void MoveTo(AGameObject obj, AGameObject aim, float dist)
        {
            float d = aim.Position - obj.Position;

            if (Math.Abs(d) < dist)
            {
                obj.Position += d;
            }
            else
            {
                obj.Position += d / Math.Abs(d) * dist;
            }
        }

        public static AGameObject Closest(AGameObject obj, AGameObject o1, AGameObject o2) {
            if (o1 == null)
            {
                return o2;
            }

            if (o2 == null)
            {
                return o1;
            }

            float d1 = Distance(obj, o1);
            float d2 = Distance(obj, o2);

            return d1 < d2 ? o1 : o2;
        }

        // Fuzzy compare
        public const float Epsilon = 0.001f;

        public static bool Equals(float a, float b)
        {
            return Math.Abs(a - b) < Epsilon;
        }

        public static bool Less(float a, float b)
        {
            return a < b && !Equals(a, b);
        }

        public static bool Greater(float a, float b)
        {
            return a > b && !Equals(a, b);
        }

        public static bool LessOrEquals(float a, float b)
        {
            return !Greater(a, b);
        }

        public static bool GreaterOrEquals(float a, float b)
        {
            return !Less(a, b);
        }
    }
}

