using System;

namespace cgc_compiler
{
    public abstract class Projectile : GameObject
    {
		public ProjectileSprite Sprite { get; private set; }

		public Projectile(GameWorld world, Player owner, float position, ProjectileSprite sprite)
            : base(world, owner, position)
        {
			Sprite = sprite;
        }
    }
}
