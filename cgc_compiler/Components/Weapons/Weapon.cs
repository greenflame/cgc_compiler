using System;

namespace cgc_compiler
{
    public abstract class Weapon : Component
    {
        public float Damage { get; private set; }
        public float CooldownTime { get; private set; }
        public float Range { get; private set; }

        private float CooldownTimeRest { get; set; }
        protected GameObject CurrentTarget { get; set; }
        private bool DamagePerformed { get; set; }

        public Weapon(GameObject obj, float damage, float cooldown, float radius)
            : base(obj)
        {
            Damage = damage;
            CooldownTime = cooldown;
            Range = radius;

            CooldownTimeRest = 0;
            CurrentTarget = null;
            DamagePerformed = false;
        }

        public bool IsInRange(GameObject target)
        {
            return Metrics.LessOrEquals(Metrics.Distance(GameObject, target), Range);
        }

        public void InitiateAttack(GameObject target)
        {
            if (IsInRange(target) && IsAttackFinished())
            {
                this.CurrentTarget = target;
                CooldownTimeRest = CooldownTime;
                DamagePerformed = false;
            }
            else
            {

                throw new Exception("Cann't shot");
            }
        }

        public void ProcessAttack(float deltaTime)
        {
            if (Metrics.LessOrEquals(CooldownTimeRest, CooldownTime / 2) &&
                !DamagePerformed &&
                GameObject.GameWorld.GameObjects.Contains(CurrentTarget))
            {
                PerformDamageAction();
                CurrentTarget = null;
            }

            CooldownTimeRest = Math.Max(0, CooldownTimeRest - deltaTime);
        }
            
        protected abstract void PerformDamageAction();

        public bool IsAttackFinished()
        {
            return CooldownTimeRest == 0;
        }

    }
}

