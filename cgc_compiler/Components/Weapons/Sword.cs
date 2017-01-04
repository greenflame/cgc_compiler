using System;

namespace cgc_compiler
{
    public class Sword : AWeapon
    {
        private AGameObject Target;

        public Sword(AGameObject obj, float damage, float cooldown, float radius)
            : base(obj, damage, cooldown, radius)
        {
        }

        public override void Update(float deltaTime)
        {
            if (Metrics.LessOrEquals(CooldownRest, Cooldown / 2) && Target != null)
            {
                Target.GetComponent<Health>().TakeDamage(Damage);
                Target = null;
            }

            CooldownRest = Math.Max(0, CooldownRest - deltaTime);
        }
            
        public override void Attack(AGameObject target)
        {
            if (IsReady() && IsInRange(target))
            {
                Target = target;
                CooldownRest = Cooldown;
            }
            else
            {
                throw new Exception("Cann't attack");
            }
        }
    }
}

