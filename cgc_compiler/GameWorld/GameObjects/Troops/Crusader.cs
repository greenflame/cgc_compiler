using System;
using System.Linq;

namespace cgc_compiler
{
	public class Crusader : Troop
	{
		private const int Hitpoints = 880;
		private static float Speed = Configuration.BaseMotionSpeed * 60;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 120;
		private const float HitSpeed = 1.5f;
		private static float Range = Configuration.MeleeRange;
		private static float DamageRange = Configuration.MeleeRange * 1.1f;

		public Crusader(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints, Speed, DeployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new AreaDamageMeleeWeapon(this, Damage, HitSpeed, Range, DamageRange);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}
