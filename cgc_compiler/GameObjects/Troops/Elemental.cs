using System;
using System.Linq;

namespace cgc_compiler
{
	public class Elemental : Troop
	{
		private const int xp = 1900;
		private const float speed = 4f / 3f;
		private const float deployTime = 1;

		// Sword - melee single, tower targeted
		private const float damage = 120;
		private const float cooldown = 1.5f;
		private const float range = 0.8f;

		public Elemental(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp, speed, deployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetMeleeWeapon(this, damage, cooldown, range);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemyTurret(this);
		}
	}
}
