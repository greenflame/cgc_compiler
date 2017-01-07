using System;

namespace cgc_compiler
{
    public abstract class ATroop : AGameObject
    {
        public ATroop(GameWorld world, Player owner, float position, float maxHealth, float speed, float spawnTime)
            : base(world, owner, position)
        {
            Components.Add(new Health(this, maxHealth));
            Components.Add(new Mover(this, speed));
            Components.Add(new Deploy(this, spawnTime));
        }
    }
}

