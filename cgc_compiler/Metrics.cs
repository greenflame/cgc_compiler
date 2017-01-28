using System;

namespace cgc_compiler
{
    public static class Metrics
    {
        // Distance
        public static float Distance(float p1, float p2)
        {
            return Math.Abs(p1 - p2);
        }

        public static float Distance(GameObject o1, GameObject o2)
        {
            return Distance(o1.Position, o2.Position);
        }
            
        public static void MoveTo(GameObject obj, float target, float dist)
        {
            float d = target - obj.Position;

            if (Math.Abs(d) < dist)
            {
                obj.Position += d;
            }
            else
            {
                obj.Position += d / Math.Abs(d) * dist;
            }
        }

        public static void MoveTo(GameObject obj, GameObject target, float dist)
        {
            MoveTo(obj, target.Position, dist);
        }

        public static GameObject Closest(GameObject obj, GameObject o1, GameObject o2) {
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

		public static bool Equals(float a, float b, float epsilon = Epsilon)
        {
            return Math.Abs(a - b) < epsilon;
        }

		public static bool Less(float a, float b, float epsilon = Epsilon)
        {
			return a < b && !Equals(a, b, epsilon);
        }

		public static bool Greater(float a, float b, float epsilon = Epsilon)
        {
			return a > b && !Equals(a, b, epsilon);
        }

		public static bool LessOrEquals(float a, float b, float epsilon = Epsilon)
        {
			return !Greater(a, b,  epsilon);
        }

		public static bool GreaterOrEquals(float a, float b, float epsilon = Epsilon)
        {
			return !Less(a, b, epsilon);
        }
    }
}

