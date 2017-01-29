using System;
using System.Linq;

namespace cgc_compiler
{
	public class AreaDamageMeleeWeapon : Weapon
	{
		public float DamageRange { get; set; }

		public AreaDamageMeleeWeapon(GameObject obj, float damage, float cooldown, float range,
			float projectileSpeed, float damageRange)
			: base(obj, damage, cooldown, range)
		{
			DamageRange = damageRange;
		}


		protected override void PerformDamageAction()
		{
			GameObject.GameWorld.GameObjects
				.Where(o => o.Owner != GameObject.Owner)  // Enenmy
				.Where(o => o is IDamagable)   // Damagable
				.Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)
				.Where(o => Metrics.LessOrEquals(Metrics.Distance(GameObject, o), DamageRange))
				.ToList()
				.ForEach(o => (o as IDamagable).GetHealth().TakeDamage(Damage));
			(CurrentTarget as IDamagable).GetHealth().TakeDamage(Damage);
		}
	}
}

