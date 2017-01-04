using System;

namespace cgc_compiler
{
    public class Health : AComponent
    {
        public float MaxHealth { get; set; }

        public float CurrentHealth { get; private set; }

        public Health(AGameObject obj, float maxHealth)
            : base(obj)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        public override void Update(float deltaTime)
        {
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - damage);
            Object.World.Logger.OnHealthUpdate(Object);

            if (CurrentHealth == 0)
            {
                Object.World.Logger.OnDeath(Object);
                Object.Destroy();
            }
        }

        public bool IsAlive()
        {
            return CurrentHealth != 0;
        }
    }
}
