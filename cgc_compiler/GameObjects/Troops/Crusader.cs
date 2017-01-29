using System;
using System.Linq;

namespace cgc_compiler
{
	public class Crusader : Troop
	{
		private const int xp = 880;
		private const float speed = 1;
		private const float deployTime = 1;

		// Sword - melee single
		private const float damage = 120;
		private const float cooldown = 1.5f;
		private const float range = 0.8f;
		private const float damageRange = 0.82f;

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
