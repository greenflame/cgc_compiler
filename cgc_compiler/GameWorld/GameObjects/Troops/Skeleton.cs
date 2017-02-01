using System;
using System.Linq;

namespace cgc_compiler
{
	public class Skeleton : Troop
	{
		private const int Hitpoints = 80;
		private static float Speed = Configuration.BaseMotionSpeed * 120;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 50;
		private const float HitSpeed = 1.1f;
		private static float Range = Configuration.MeleeRange;

		public Skeleton(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints, Speed, DeployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetMeleeWeapon(this, Damage, HitSpeed, Range);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}
