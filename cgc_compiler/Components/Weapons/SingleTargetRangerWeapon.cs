using System;

namespace cgc_compiler
{
	public class SingleTargetRangedWeapon : Weapon
	{
		public float ProjectileSpeed { get; private set; }
		public ProjectileSprite ProjectileSprite { get; private set; }

		public SingleTargetRangedWeapon(GameObject obj, float damage, float cooldown, float range,
			float projectileSpeed, ProjectileSprite projectileSprite)
			: base(obj, damage, cooldown, range)
		{
			ProjectileSpeed = projectileSpeed;
			ProjectileSprite = projectileSprite;
		}

		protected override void PerformDamageAction()
		{
			GameObject.GameWorld.GameObjects.Add(
				new SingleTargetProjectile(GameObject.GameWorld, GameObject.Owner, GameObject.Position,
					ProjectileSprite, CurrentTarget, Damage, ProjectileSpeed));
		}
	}
}

