using System;
using System.Linq;

namespace cgc_compiler
{
	public class TargetSelectors
	{
		public static GameObject ClosestDamagableDeployedEnemy(GameObject obj)
		{
			return obj.GameWorld.GameObjects
				.Where(o => o.Owner != obj.Owner)	// Enemy
				.Where(o => o is IDamagable)		// Damagable
				.Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)	// Deployed
				.Aggregate((GameObject)null, (a, b) => Metrics.Closest(obj, a, b));				// Closest
		}

		public static GameObject ClosestDamagableDeployedEnemyTroop(GameObject obj)
		{
			return obj.GameWorld.GameObjects
				.Where(o => o is Troop)				// Troop
				.Where(o => o.Owner != obj.Owner)	// Enemy
				.Where(o => o is IDamagable)		// Damagable
				.Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)	// Deployed
				.Aggregate((GameObject)null, (a, b) => Metrics.Closest(obj, a, b));				// Closest
		}

		public static GameObject ClosestDamagableDeployedEnemyTurret(GameObject obj)
		{
			return obj.GameWorld.GameObjects
				.Where(o => o is Turret)			// Turret
				.Where(o => o.Owner != obj.Owner)	// Enemy
				.Where(o => o is IDamagable)		// Damagable
				.Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)	// Deployed
				.Aggregate((GameObject)null, (a, b) => Metrics.Closest(obj, a, b));				// Closest
		}
	}
}

