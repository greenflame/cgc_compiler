using System;
using System.Linq;

namespace cgc_compiler
{
    public class Halfling : Troop
    {
        private const int xp = 147;
        private const float speed = 1;
        private const float deployTime = 1;

        // Sling - ranged area
        private const float damage = 128;
        private const float cooldown = 1.9f;
        private const float range = 4.5f;
        private const float stoneSpeed = 2;
        private const float damageRange = 0.5f;
		private const ProjectileSprite sprite = ProjectileSprite.Stone;

        public Halfling(GameWorld world, Player owner, float position)
            : base(world, owner, position, xp, speed, deployTime)
        {
        }
            
        public override Weapon MakeWeapon()
        {
			return new AreaDamageRangedWeapon(this, damage, cooldown, range, stoneSpeed, damageRange, sprite);
        }

        public override GameObject FindTarget()
        {
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
        }
    }
}

