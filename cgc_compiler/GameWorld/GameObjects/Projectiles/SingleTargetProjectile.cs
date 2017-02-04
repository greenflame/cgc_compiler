using System;

namespace cgc_compiler
{
	public class SingleTargetProjectile : Projectile
	{
		public GameObject Target { get; private set; }
		public float Damage { get; private set; }

		public SingleTargetProjectile(GameWorld world, Player owner, float positioin, ProjectileType sprite,
			GameObject target, float damage, float speed)
			: base(world, owner, positioin, sprite)
		{
			Target = target;
			Damage = damage;
			Mover = new Mover(this, speed);

			GameWorld.EventLlogger.ProjectileTargetShot(this, target);
		}

		public override void Update(float deltaTime)
		{
			if (!GameWorld.GameObjects.Contains(Target))    // Target died
			{
				GameWorld.EventLlogger.Destroy(this);
				Destroy();
			}
			else if (Metrics.Equals(Mover.DistanceTo(Target), 0, Mover.Speed * deltaTime))    // Target reached
			{
				(Target as IDamagable).GetHealth().TakeDamage(Damage);
				GameWorld.EventLlogger.Destroy(this);
				Destroy();
			}
			else        // Flying
			{
				Mover.MoveTo(Target, deltaTime);
			}
		}
	}
}

