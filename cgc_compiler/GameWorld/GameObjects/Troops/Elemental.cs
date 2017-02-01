using System;
using System.Linq;

namespace cgc_compiler
{
	public class Elemental : Troop
	{
		private const int Hitpoints = 1900;
		private static float Speed = Configuration.BaseMotionSpeed * 45;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 120;
		private const float HitSpeed = 1.5f;
		private static float Range = Configuration.MeleeRange;

		public Elemental(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints, Speed, DeployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetMeleeWeapon(this, Damage, HitSpeed, Range);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemyTurret(this);
		}
	}
}
