using System;

namespace cgc_compiler
{
    public class Arrow : AGameObject
    {
        public float Damage { get; private set; }

        public Arrow(GameWorld world, Player owner, float positioin, AGameObject target, float damage, float speed)
            : base(world, owner, positioin)
        {
            Damage = damage;
            Components.Add(new Mover(this, speed));
            Components.Add(new ArrowStrategy(this, target, damage));
        }
    }
}

