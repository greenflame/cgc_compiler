using System;
using System.Linq;

namespace cgc_compiler
{
    public class Halfling : Troop
    {
        private const int xp = 147;
        private const float speed = 1;
        private const float deployTime = 1;

        // Sling
        private const float damage = 128;
        private const float cooldown = 1.9f;
        private const float range = 4.5f;
        private const float stoneSpeed = 2;
        private const float damageRange = 0.5f;

        public Halfling(GameWorld world, Player owner, float position)
            : base(world, owner, position, xp, speed, deployTime)
        {
        }
            
        public override Weapon MakeWeapon()
        {
			return new AreaDamageRangedWeapon(this, damage, cooldown, range, stoneSpeed, damageRange, ProjectileSprite.Stone);
        }

        public override GameObject FindTarget()
        {
            return GameWorld.GameObjects
                .Where(o => o.Owner != Owner)    // Enemy
                .Where(o => o is IDamagable)    // With health
                .Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)    // Deployed
                .Aggregate((GameObject)null, (a, b) => Metrics.Closest(this, a, b));    // Closest
        }

    }
}

