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
			GameObject.GameWorld.EventLlogger.SetHealth(GameObject);

            if (CurrentHealth == 0)
            {
				if (GameObject is Troop)
				{
					GameObject.GameWorld.EventLlogger.TroopDie(GameObject);
					GameObject.Destroy();
				}
				else if (GameObject is Turret)
				{
					GameObject.GameWorld.EventLlogger.TurretDestroy(GameObject);
					GameObject.Destroy();
				}
				else
				{
					GameObject.Destroy();
				}
            }
        }

        public bool IsAlive()
        {
            return CurrentHealth != 0;
        }
    }
}
