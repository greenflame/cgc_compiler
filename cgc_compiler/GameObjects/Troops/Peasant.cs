using System;
using System.Linq;

namespace cgc_compiler
{
    public class Peasant : Troop
    {
        private const int xp = 660;
		private static float speed = Configuration.BaseMotionSpeed;
        private const float deployTime = 1;

        // Sword - melee single
        private const float damage = 10;
        private const float cooldown = 0.5f;
		private static float range = Configuration.MeleeRange;

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
