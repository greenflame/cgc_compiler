using System;
using System.Linq;

namespace cgc_compiler
{
    public class Sharpshooter : Troop
    {
        private const int xp = 125;
        private const float speed = 1;
        private const float deployTime = 1;

        // Bow
        private const float damage = 41;
        private const float cooldown = 1.2f;
        private const float range = 5;
        private const float arrowSpeed = 4;

        public Sharpshooter(GameWorld world, Player owner, float position)
            : base(world, owner, position, xp, speed, deployTime)
        {
        }

        public override Weapon MakeWeapon()
        {
            return new Bow(this, damage, cooldown, range, arrowSpeed);
        }

        public override GameObject FindTarget()
        {
            return GameWorld.GameObjects
                .Where(o => o.Owner != Owner)    // Enemy
                .Where(o => o is IDamagable)
                .Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)    // Deployed
                .Aggregate((GameObject)null, (a, b) => Metrics.Closest(this, a, b));    // Closest
        }
    }
}

