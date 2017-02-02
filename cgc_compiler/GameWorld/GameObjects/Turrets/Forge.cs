using System;
using System.Linq;

namespace cgc_compiler
{
	public class Forge : Turret
	{
		private const int Hitpoints = 2400;

		private const float Damage = 50;
		private const float HitSpeed = 1;
		private const float Range = 7;
		private const float ArrowSpeed = Configuration.ProjectileSpeed;
		private static ProjectileType ProjectileType = ProjectileType.Arrow;

		public Forge(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints)
		{
		}

		public override Weapon MakeWeapon ()
		{
			return new SingleTargetRangedWeapon(this, Damage, HitSpeed, Range, ArrowSpeed, ProjectileType);
		}

		public override GameObject FindTarget ()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemyTroop(this);
		}
	}
}
