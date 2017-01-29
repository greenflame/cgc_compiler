using System;
using System.Linq;

namespace cgc_compiler
{
	public class Tower : Turret
    {
		private const int xp = 1400;

		// Gun - single target, ranged
		private const float damage = 50;
		private const float cooldown = 0.8f;
		private const float range = 7.5f;
		private const float arrowSpeed = 4;
		private const ProjectileSprite sprite = ProjectileSprite.Arrow;

		public Tower(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp)
		{
        }

		public override Weapon MakeWeapon ()
		{
			return new SingleTargetRangedWeapon(this, damage, cooldown, range, arrowSpeed, sprite);
		}

		public override GameObject FindTarget ()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemyTroop(this);
		}
    }
}
