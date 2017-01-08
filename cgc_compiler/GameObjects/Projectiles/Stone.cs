using System;
using System.Linq;

namespace cgc_compiler
{
    public class Stone : Projectile
    {
        public float Target { get; private set; }
        public float Damage { get; private set; }
        public float DamageRange { get; set; }
        public Mover Mover { get; private set; }

        public Stone(GameWorld world, Player owner, float positioin, float target, float damage, float speed, float damageRange)
            : base(world, owner, positioin)
        {
            Target = target;
            Damage = damage;
            DamageRange = damageRange;
            Mover = new Mover(this, speed);

            GameWorld.EventLlogger.OnCreate(this);
            GameWorld.EventLlogger.OnBombFlight(this, target, Mover.Speed);
        }

        public override void Update(float deltaTime)
        {
            if (Metrics.Equals(Mover.DistanceTo(Target), 0))    // Target reached
            {
                GameWorld.GameObjects
                    .Where(o => o.Owner != Owner)  // Enenmy
                    .Where(o => o is IDamagable)   // Damagable
                    .Where(o => Metrics.LessOrEquals(Metrics.Distance(o.Position, Target), DamageRange))
                    .ToList()
                    .ForEach(o => (o as IDamagable).GetHealth().TakeDamage(Damage));

                GameWorld.EventLlogger.OnDestroy(this);
                Destroy();
            }
            else    // Flying
            {
                Mover.MoveTo(Target, deltaTime);
            }
        }

    }
}

