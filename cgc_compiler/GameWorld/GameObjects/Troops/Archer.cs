using System;
using System.Linq;

namespace cgc_compiler
{
	public class Archer : Troop
	{
		private const int Hitpoints = 340;
		private static float Speed = Configuration.BaseMotionSpeed * 60;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 100;
		private const float HitSpeed = 1.1f;
		private const float Range = 6;
		private const float ArrowSpeed = Configuration.ProjectileSpeed;
		private static ProjectileType ProjectileType = ProjectileType.Arrow;

		public Archer(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints, Speed, DeployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetRangedWeapon(this, Damage, HitSpeed, Range, ArrowSpeed, ProjectileType);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}

