﻿using System;

namespace cgc_compiler
{
    public class ArrowStrategy : AStrategy
    {
        public float Damage { get; private set; }

        public AGameObject Target { get; private set; }

        private Mover Mover;

        public ArrowStrategy(AGameObject obj, AGameObject target, float damage)
            : base(obj)
        {
            Mover = Object.GetComponent<Mover>();    
            Mover.Target = target;

            Damage = damage;
            Target = target;

            Object.World.Logger.OnCreate(Object);
            Object.World.Logger.OnArrowFlight(Object, target, Mover.Speed);
        }

        public override void Update(float deltaTime)
        {
            if (Metrics.Equals(Metrics.Distance(Object, Target), 0))
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

