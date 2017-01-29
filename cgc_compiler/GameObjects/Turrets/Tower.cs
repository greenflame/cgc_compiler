using System;
using System.Linq;

namespace cgc_compiler
{
	public class Tower : Turret
    {
		private const int xp = 1400;

		// Bow
		private const float damage = 50;
		private const float cooldown = 0.8f;
		private const float range = 7.5f;
		private const float arrowSpeed = 4;

		public Tower(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp)
        {
        }

		public override Weapon MakeWeapon ()
		{
			return new SingleTargetRangedWeapon(this, damage, cooldown, range, arrowSpeed, ProjectileSprite.Fireball);
		}

		public override GameObject FindTarget ()
		{
			return GameWorld.GameObjects
				.Where(o => o.Owner != Owner)    // Enemy
                .Where(o => o is Troop)    // Troop
				.Where(o => (o as IDeployable).GetDeploy().IsDeployed())    // Deployed
				.Aggregate((GameObject)null, (a, b) => Metrics.Closest(this, a, b));    // Closest
		}

    }
}
