using System;

namespace cgc_compiler
{
	public class SingleTargetMeleeWeapon : Weapon
	{
		public SingleTargetMeleeWeapon(GameObject obj, float damage, float cooldown, float radius)
			: base(obj, damage, cooldown, radius)
		{
		}

		protected override void PerformDamageAction()
		{
			(CurrentTarget as IDamagable).GetHealth().TakeDamage(Damage);
		}
	}
}

