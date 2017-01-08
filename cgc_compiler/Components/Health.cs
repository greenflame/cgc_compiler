using System;

namespace cgc_compiler
{
    public class Health : Component
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; private set; }

        public Health(GameObject obj, float maxHealth)
            : base(obj)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
            
        public void TakeDamage(float damage)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - damage);
            GameObject.gameWorld.eventLlogger.OnHealthUpdate(GameObject);

            if (CurrentHealth == 0)
            {
                GameObject.Destroy();
                GameObject.gameWorld.eventLlogger.OnDeath(GameObject);
            }
        }

        public bool IsAlive()
        {
            return CurrentHealth != 0;
        }
    }
}
