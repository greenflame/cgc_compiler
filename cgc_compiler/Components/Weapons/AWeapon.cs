using System;

namespace cgc_compiler
{
    public abstract class AWeapon : AComponent
    {
        public float Damage { get; protected set; }

        public float Cooldown { get; protected set; }

        public float Radius { get; protected set; }

        public float CooldownRest { get; protected set; }

        public AWeapon(AGameObject obj, float damage, float cooldown, float radius)
            : base(obj)
        {
            Damage = damage;
            Cooldown = cooldown;
            Radius = radius;

            CooldownRest = 0;
        }

        public bool IsInRange(AGameObject aim)
        {
            return Metrics.LessOrEquals(Metrics.Distance(Object, aim), Radius);
        }

        public abstract void Attack(AGameObject targer);

        public bool IsReady()
        {
            return CooldownRest == 0;
        }
    }
}

