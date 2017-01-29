using System;
using System.Linq;

namespace cgc_compiler
{
	public class Archer : Troop
	{
		private const int xp = 340;
		private static float speed = Configuration.BaseMotionSpeed;
		private const float deployTime = 1;

		// Bow - ranged single
		private const float damage = 100;
		private const float cooldown = 1.1f;
		private const float range = 6;
		private const float arrowSpeed = 4;
		private const ProjectileSprite sprite = ProjectileSprite.Arrow;

		public Archer(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp, speed, deployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetRangedWeapon(this, damage, cooldown, range, arrowSpeed, sprite);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}

