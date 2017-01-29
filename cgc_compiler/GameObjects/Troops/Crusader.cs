using System;
using System.Linq;

namespace cgc_compiler
{
	public class Crusader : Troop
	{
		private const int xp = 880;
		private static float speed = Configuration.BaseMotionSpeed;
		private const float deployTime = 1;

		// Sword - melee single
		private const float damage = 120;
		private const float cooldown = 1.5f;
		private float range = Configuration.MeleeRange;
		private float damageRange = Configuration.MeleeRange + 0.05f;

		public Crusader(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp, speed, deployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new AreaDamageMeleeWeapon(this, damage, cooldown, range, damageRange);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}
