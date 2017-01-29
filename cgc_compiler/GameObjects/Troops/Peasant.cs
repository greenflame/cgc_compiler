using System;
using System.Linq;

namespace cgc_compiler
{
    public class Peasant : Troop
    {
        private const int xp = 600;
        private const float speed = 1;
        private const float deployTime = 1;

        // Sword - melee single
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
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
        }
    }
}
