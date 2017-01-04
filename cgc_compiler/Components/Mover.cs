using System;

namespace cgc_compiler
{
    public class Mover : AComponent
    {
        public float Speed { get; private set; }

        public AGameObject Target { get; set; }

        public Mover(AGameObject obj, float speed)
            : base(obj)
        {
            Speed = speed;
        }

        public override void Update(float deltaTime)
        {
            if (Target != null)
            {
                Metrics.MoveTo(Object, Target, Speed * deltaTime);
            }
        }
    }
}

