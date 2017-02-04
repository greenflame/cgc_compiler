using System;

namespace cgc_compiler
{
	public abstract class Projectile : GameObject, IMovable
    {
		public ProjectileType Sprite { get; private set; }
		public Mover Mover { get; protected set; }

		public Projectile(GameWorld world, Player owner, float position, ProjectileType sprite)
            : base(world, owner, position)
        {
			Sprite = sprite;
        }

		public Mover GetMover()
		{
			return Mover;
		}
    }
}
