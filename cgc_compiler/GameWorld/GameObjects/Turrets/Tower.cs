using System;
using System.Linq;

namespace cgc_compiler
{
	public class Tower : Turret
    {
		private const int Hitpoints = 1400;

		private const float Damage = 50;
		private const float HitSpeed = 0.8f;
		private const float Range = 7.5f;
		private const float ArrowSpeed = Configuration.ProjectileSpeed;
		private static ProjectileType ProjectileType = ProjectileType.Arrow;

		public Tower(GameWorld world, Player owner, float position)
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
