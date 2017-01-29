using System;

namespace cgc_compiler
{
	public class AreaDamageRangedWeapon : Weapon
	{
		public float ProjectileSpeed { get; private set; }
		public float DamageRange { get; set; }
		public ProjectileSprite ProjectileSprite { get; private set; }

		public AreaDamageRangedWeapon(GameObject obj, float damage, float cooldown, float range,
			float projectileSpeed, float damageRange, ProjectileSprite projectileSprite)
			: base(obj, damage, cooldown, range)
		{
			ProjectileSpeed = projectileSpeed;
			DamageRange = damageRange;
			ProjectileSprite = projectileSprite;
		}

		protected override void PerformDamageAction()
		{
			GameObject.GameWorld.GameObjects.Add(
				new AreaDmageProjectile(GameObject.GameWorld, GameObject.Owner, GameObject.Position,
					ProjectileSprite ,CurrentTarget.Position, Damage, ProjectileSpeed, DamageRange));
		}
	}
}

