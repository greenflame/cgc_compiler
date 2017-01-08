using System;

namespace cgc_compiler
{
    public class Arrow : Projectile
    {
        public GameObject Target { get; private set; }
        public float Damage { get; private set; }
        public Mover Mover { get; private set; }

        public Arrow(GameWorld world, Player owner, float positioin, GameObject target, float damage, float speed)
            : base(world, owner, positioin)
        {
            Target = target;
            Damage = damage;
            Mover = new Mover(this, speed);

            gameWorld.eventLlogger.OnCreate(this);
            gameWorld.eventLlogger.OnArrowFlight(this, target, Mover.Speed);
        }

        public override void Update(float deltaTime)
        {
            if (!gameWorld.gameObjects.Contains(Target))    // Target died
            {
                gameWorld.eventLlogger.OnDestroy(this);
                Destroy();
            }

            if (Metrics.Equals(Mover.DistanceTo(Target), 0))    // Target reached
            {
                (Target as IDamagable).GetHealth().TakeDamage(Damage);
                gameWorld.eventLlogger.OnDestroy(this);
                Destroy();
            }
            else    // Flying
            {
                Mover.MoveTo(Target, deltaTime);
            }
        }
    }
}

