using System;
using System.Linq;

namespace cgc_compiler
{
	public class Forge : Turret
	{
		private const int xp = 2400;

		// Bow
		private const float damage = 50;
		private const float cooldown = 1;
		private const float range = 7;
		private const float arrowSpeed = 4;
		private const ProjectileSprite sprite = ProjectileSprite.Arrow;

		public Forge(GameWorld world, Player owner, float position)
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
