using System;

namespace cgc_compiler
{
    public class BombStrategy : AStrategy
    {
        float TargetPosition;
        float Damage;
        float DamageRadius;

        Mover Mover;

        public BombStrategy(AGameObject obj, float targetPos, float damage, float damageRad)
            :base(obj)
        {
            TargetPosition = targetPos;
            Damage = damage;
            DamageRadius = damageRad;

            Object.World.Logger.OnCreate(Object);
            Object.World.Logger.OnBombFlight(Object, targetPos, Mover.Speed);
        }
            
        public override void Update(float deltaTime)
        {
            if (Metrics.Equals(Metrics.Distance(Object.Position, TargetPosition), 0))
            {
                Target.GetComponent<Health>().TakeDamage(Damage);
                Object.World.Logger.OnDestroy(Object);
                Object.Destroy();
            }

            if (!Object.World.GameObjects.Contains(Target))
            {
                Object.World.Logger.OnDestroy(Object);
                Object.Destroy();
            }
        }
    }
}

