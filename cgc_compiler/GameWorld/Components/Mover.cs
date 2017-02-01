using System;

namespace cgc_compiler
{
    public class Mover : Component
    {
        public float Speed { get; private set; }

        public Mover(GameObject obj, float speed)
            : base(obj)
        {
            Speed = speed;
        }

        public float DistanceTo(float target)
        {
            return Metrics.Distance(GameObject.Position, target);
        }

        public float DistanceTo(GameObject target)
        {
            return Metrics.Distance(GameObject, target);
        }

        public void MoveTo(float target, float deltaTime)
        {
            Metrics.MoveTo(GameObject, target, Speed * deltaTime);
        }

        public void MoveTo(GameObject target, float deltaTime)
        {
            Metrics.MoveTo(GameObject, target, Speed * deltaTime);
        }
    }
}

