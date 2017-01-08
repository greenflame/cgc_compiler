using System;

namespace cgc_compiler
{
    public class Mover : Component
    {
        public float speed { get; private set; }

        public Mover(GameObject obj, float speed)
            : base(obj)
        {
            this.speed = speed;
        }

        public void MoveTo(GameObject target, float deltaTime)
        {
            Metrics.MoveTo(gameObject, target, speed * deltaTime);
        }
    }
}

