using System;
using System.Linq;

namespace cgc_compiler
{
	public class Gog : Troop
	{
		private const int Hitpoints = 52;
		private static float Speed = Configuration.BaseMotionSpeed * 120;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 24;
		private const float HitSpeed = 1.3f;
		private const float Range = 5;
		private const float ArrowSpeed = Configuration.ProjectileSpeed;
		private static ProjectileType ProjectileType = ProjectileType.Fireball;

		public Gog(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints, Speed, DeployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetRangedWeapon(this, Damage, HitSpeed, Range, ArrowSpeed, ProjectileType);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy (this);
		}
	}
}

