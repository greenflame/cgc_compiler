using System;
using System.Linq;

namespace cgc_compiler
{
    public class Sharpshooter : Troop
    {
        private const int xp = 125;
        private const float speed = 1;
        private const float deployTime = 1;

        // Bow - ranged single
        private const float damage = 41;
        private const float cooldown = 1.2f;
        private const float range = 5;
        private const float arrowSpeed = 4;
		private const ProjectileSprite sprite = ProjectileSprite.Arrow;

        public Sharpshooter(GameWorld world, Player owner, float position)
            : base(world, owner, position, xp, speed, deployTime)
        {
        }

        public override Weapon MakeWeapon()
        {
			return new SingleTargetRangedWeapon(this, damage, cooldown, range, arrowSpeed, sprite);
        }

        public override GameObject FindTarget()
        {
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
        }
    }
}

