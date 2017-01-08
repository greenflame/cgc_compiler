using System;

namespace cgc_compiler
{
    public class Bow : Weapon
    {
        public float ArrowSpeed { get; private set; }

        public Bow(GameObject obj, float damage, float cooldown, float range, float arrowSpeed)
            : base(obj, damage, cooldown, range)
        {
            ArrowSpeed = arrowSpeed;
        }

        protected override void PerformDamageAction()
        {
            GameObject.GameWorld.GameObjects.Add(
                new Arrow(GameObject.GameWorld, GameObject.Owner, GameObject.Position, CurrentTarget, Damage, ArrowSpeed));
        }

    }
}

