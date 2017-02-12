using System;
using System.Linq;

namespace cgc_compiler
{
	public class Halberdier : Troop
	{
		private const int Hitpoints = 600;
		private static float Speed = Configuration.BaseMotionSpeed * 90;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 325;
		private const float Cooldown = 1.8f;
		private static float Range = Configuration.MeleeRange;

		public Halberdier(GameWorld world, Player owner, float position)
			: base(world, owner, position, Hitpoints, Speed, DeployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetMeleeWeapon(this, Damage, Cooldown, Range);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}
