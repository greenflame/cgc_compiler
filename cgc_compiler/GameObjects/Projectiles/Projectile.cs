using System;

namespace cgc_compiler
{
    public abstract class Projectile : GameObject
    {
        public Projectile(GameWorld world, Player owner, float position)
            : base(world, owner, position)
        {
        }
    }
}

