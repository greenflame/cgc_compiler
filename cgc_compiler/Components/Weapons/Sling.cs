using System;

namespace cgc_compiler
{
    public class Sling : AWeapon
    {
        public float DamageRadius { get; private set; }

        private float TargetPosition;
        private bool ShotPerformed = false;

        public Sling(AGameObject obj, float damage, float cooldown, float radius,
            float damageRadius)
            : base(obj, damage, cooldown, radius)
        {
            DamageRadius = damageRadius;
        }

        public override void Update(float deltaTime)
        {
            if (Metrics.LessOrEquals(CooldownRest, Cooldown / 2) && !ShotPerformed)
            {
                Object.World.GameObjects.Add(new Bomb(Object.World, Object.Owner, Object.Position, TargetPosition, Damage, 1f, DamageRadius));
                ShotPerformed = true;
            }

            CooldownRest = Math.Max(0, CooldownRest - deltaTime);
        }

        public override void Attack(AGameObject target)
        {
            if (IsReady() && IsInRange(target))
            {
                TargetPosition = target.Position;
                ShotPerformed = false;
                CooldownRest = Cooldown;
            }
            else
            {
                throw new Exception("Cann't shot");
            }
        }
    }
}

