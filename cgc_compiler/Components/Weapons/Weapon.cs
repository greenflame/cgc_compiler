using System;

namespace cgc_compiler
{
    public abstract class Weapon : Component
    {
        public float damage;
        public float cooldownTime;
        public float range;

        public float cooldownTimeRest;
        public GameObject currentTarget;

        public Weapon(GameObject obj, float damage, float cooldown, float radius)
            : base(obj)
        {
            this.damage = damage;
            this.cooldownTime = cooldown;
            this.range = radius;

            cooldownTimeRest = 0;
            currentTarget = null;
        }

        public bool IsInRange(GameObject target)
        {
            return Metrics.LessOrEquals(Metrics.Distance(gameObject, target), range);
        }

        public void InitiateAttack(GameObject target)
        {
            if (IsInRange(target) && IsAttackFinished())
            {
                this.currentTarget = target;
                cooldownTimeRest = cooldownTime;
            }
            else
            {
                throw new Exception("Cann't shot");
            }
        }

        public void ProcessAttack(float deltaTime)
        {
            // First appropriate moment -> core damage action
            if (Metrics.LessOrEquals(cooldownTimeRest, cooldownTime / 2) && currentTarget != null)
            {
                PerformDamageAction();
                currentTarget = null;
            }

            cooldownTimeRest = Math.Max(0, cooldownTimeRest - deltaTime);
        }

        public bool IsAttackFinished()
        {
            return cooldownTimeRest == 0;
        }

        protected abstract void PerformDamageAction();
    }
}

