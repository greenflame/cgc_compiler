using System;
using System.Linq;

namespace cgc_compiler
{
    public class Sharpshooter : Troop
    {
		private const int Hitpoints = 120;
		private static float Speed = Configuration.BaseMotionSpeed * 60;
		private const float DeployTime = Configuration.BaseDeployTime;

		private const float Damage = 41;
		private const float HitSpeed = 1.2f;
		private const float Range = 5;
		private const float ArrowSpeed = Configuration.ProjectileSpeed;
		private const ProjectileType ProjectileType = ProjectileType.Arrow;

        public Sharpshooter(GameWorld world, Player owner, float position)
            : base(world, owner, position, Hitpoints, Speed, DeployTime)
        {
        }

        public override Weapon MakeWeapon()
        {
			return new SingleTargetRangedWeapon(this, Damage, HitSpeed, Range, ArrowSpeed, ProjectileType);
        }

        public override GameObject FindTarget()
        {
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
        }
    }
}

