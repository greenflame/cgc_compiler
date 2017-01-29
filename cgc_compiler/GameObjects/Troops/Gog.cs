using System;
using System.Linq;

namespace cgc_compiler
{
	public class Gog : Troop
	{
		private const int xp = 52;
		private const float speed = 2;
		private const float deployTime = 1;

		// Bow - ranged single
		private const float damage = 24;
		private const float cooldown = 1.3f;
		private const float range = 5;
		private const float arrowSpeed = 4;
		private const ProjectileSprite sprite = ProjectileSprite.Fireball;

		public Gog(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp, speed, deployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetRangedWeapon(this, damage, cooldown, range, arrowSpeed, sprite);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy (this);
		}
	}
}

