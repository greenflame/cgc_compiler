using System;

namespace cgc_compiler
{
	public class SingleTargetProjectile : Projectile
	{
		public GameObject Target { get; private set; }
		public float Damage { get; private set; }
		public Mover Mover { get; private set; }

		public SingleTargetProjectile(GameWorld world, Player owner, float positioin, ProjectileSprite sprite,
			GameObject target, float damage, float speed)
			: base(world, owner, positioin, sprite)
		{
			Target = target;
			Damage = damage;
			Mover = new Mover(this, speed);

			GameWorld.EventLlogger.OnCreate(this);
			GameWorld.EventLlogger.OnArrowFlight(this, target, Mover.Speed);
		}

		public override void Update(float deltaTime)
		{
			if (!GameWorld.GameObjects.Contains(Target))    // Target died
			{
				GameWorld.EventLlogger.OnDestroy(this);
				Destroy();
			}

			if (Metrics.Equals(Mover.DistanceTo(Target), 0, Mover.Speed * deltaTime))    // Target reached
			{
				(Target as IDamagable).GetHealth().TakeDamage(Damage);
				GameWorld.EventLlogger.OnDestroy(this);
				Destroy();
			}
			else    // Flying
			{
				Mover.MoveTo(Target, deltaTime);
			}
		}
	}
}

