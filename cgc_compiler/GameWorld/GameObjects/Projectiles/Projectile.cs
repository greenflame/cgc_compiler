using System;

namespace cgc_compiler
{
    public abstract class Projectile : GameObject
    {
		public ProjectileType Sprite { get; private set; }

		public Projectile(GameWorld world, Player owner, float position, ProjectileType sprite)
            : base(world, owner, position)
        {
			Sprite = sprite;
        }
    }
}
