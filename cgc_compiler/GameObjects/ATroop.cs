using System;

namespace cgc_compiler
{
    public abstract class ATroop : AGameObject
    {
        public ATroop(GameWorld world, string name, Player owner, float position, float maxHealth,
                      float damage, float cooldown, float radius, float speed, float spawnTime)
            : base(world, name, owner, position)
        {
            Components.Add(new Health(this, maxHealth));
            Components.Add(new Sword(this, damage, cooldown, radius));
            Components.Add(new Mover(this, speed));
            Components.Add(new Deployer(this, spawnTime));
        }
    }
}

