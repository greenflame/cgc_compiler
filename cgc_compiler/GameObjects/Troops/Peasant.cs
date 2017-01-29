using System;
using System.Linq;

namespace cgc_compiler
{
    public class Peasant : Troop
    {
        private const int xp = 600;
        private const float speed = 1;
        private const float deployTime = 1;

        // Sword
        private const float damage = 10;
        private const float cooldown = 0.5f;
        private const float range = 0.8f;

        public Peasant(GameWorld world, Player owner, float position)
            : base(world, owner, position, xp, speed, deployTime)
        {
        }

        public override Weapon MakeWeapon()
        {
			return new SingleTargetMeleeWeapon(this, damage, cooldown, range);
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
