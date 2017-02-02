using System;
using System.Linq;

namespace cgc_compiler
{
    public class Halfling : Troop
    {
		private const int Hitpoints = 147;
		private static float Speed = Configuration.BaseMotionSpeed * 60;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 128;
		private const float HitSpeed = 1.9f;
		private const float Range = 4.5f;
		private const float StoneSpeed = Configuration.ProjectileSpeed;
		private const float DamageRange = Configuration.AreaDamageRange;
		private static ProjectileType ProjectileType = ProjectileType.Stone;

        public Halfling(GameWorld world, Player owner, float position)
            : base(world, owner, position, Hitpoints, Speed, DeployTime)
        {
        }
            
        public override Weapon MakeWeapon()
        {
			return new AreaDamageRangedWeapon(this, Damage, HitSpeed, Range, StoneSpeed, DamageRange, ProjectileType);
        }

        public override GameObject FindTarget()
        {
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
        }
    }
}

