using System;
using System.Linq;

namespace cgc_compiler
{
	public class Halebardier : Troop
	{
		private const int xp = 600;
		private static float speed = Configuration.BaseMotionSpeed * 1.5f;
		private const float deployTime = 1;

		// Sword - melee single
		private const float damage = 325;
		private const float cooldown = 1.8f;
		private float range = Configuration.MeleeRange;

		public Halebardier(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp, speed, deployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetMeleeWeapon(this, damage, cooldown, range);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}
