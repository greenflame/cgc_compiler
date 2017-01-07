using System;

namespace cgc_compiler
{
    public class AProjectile : AGameObject
    {
        public AProjectile(GameWorld world, Player owner, float position)
            : base(world, owner, position)
        {
        }
    }
}

