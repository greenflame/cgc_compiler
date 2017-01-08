using System;

namespace cgc_compiler
{
    public class Sling : Weapon
    {
        public float StoneSpeed { get; private set; }
        public float DamageRange { get; set; }

        public Sling(GameObject obj, float damage, float cooldown, float range, float stoneSpeed, float damageRange)
            : base(obj, damage, cooldown, range)
        {
            StoneSpeed = stoneSpeed;
            DamageRange = damageRange;
        }

        protected override void PerformDamageAction()
        {
            GameObject.GameWorld.GameObjects.Add(
                new Stone(GameObject.GameWorld, GameObject.Owner, GameObject.Position,
                    CurrentTarget.Position, Damage, StoneSpeed, DamageRange));
        }

    }
}

