using System;

namespace cgc_compiler
{
    public class Health : Component
    {
        public float maxHealth { get; set; }

        public float currentHealth { get; private set; }

        public Health(GameObject obj, float maxHealth)
            : base(obj)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }
            
        public void TakeDamage(float damage)
        {
            currentHealth = Math.Max(0, currentHealth - damage);
            gameObject.gameWorld.eventLlogger.OnHealthUpdate(gameObject);

            if (currentHealth == 0)
            {
                gameObject.Destroy();
                gameObject.gameWorld.eventLlogger.OnDeath(gameObject);
            }
        }

        public bool IsAlive()
        {
            return currentHealth != 0;
        }
    }
}
