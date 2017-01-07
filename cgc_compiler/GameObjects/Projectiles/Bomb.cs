using System;

namespace cgc_compiler
{
    public class Bomb : AProjectile
    {
        public Bomb(GameWorld world, Player owner, float position,
            float targetPosition, float damage, float speed, float damageRadius)
            : base(world, owner, position)
        {
        }
    }
}

