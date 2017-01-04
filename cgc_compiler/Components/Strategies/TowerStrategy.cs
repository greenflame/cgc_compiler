using System;
using System.Linq;

namespace cgc_compiler
{
    public class TowerStrategy : AStrategy
    {
        private enum StateE {
            Created,
            Idle,
            Shooting
        }

        private StateE State;

        private AWeapon Weapon;

        public TowerStrategy(AGameObject obj)
            : base(obj)
        {
            Object.World.Logger.OnDeclare(Object);
            State = StateE.Created;
            Weapon = Object.GetComponent<AWeapon>();
        }

        private AGameObject FindTarget()
        {
            return Object.World.GameObjects
                .Where(o => o.Owner != Object.Owner)    // Enemy
                .Where(o => o is ATroop)    // Troop
                .Aggregate((AGameObject)null, (a, b) => Metrics.Closest(Object, a, b));    // Closest
        }

        public override void Update(float deltaTime)
        {
            AGameObject target = FindTarget();
                
            switch (State)
            {
                case StateE.Created:

                    if (target != null && Weapon.IsInRange(target)) // Target is is in range -> shot
                    {
                        Object.World.Logger.OnShot(Object, target);
                        State = StateE.Shooting;
                        Weapon.Attack(target);
                    }
                    else    // No proper target -> idle
                    {
                        Object.World.Logger.OnIdle(Object);
                        State = StateE.Idle;
                    }

                    return;

                case StateE.Idle:
                
                    if (target != null && Weapon.IsInRange(target))    // Target appears -> shot
                    {
                        Object.World.Logger.OnShot(Object, target);
                        Weapon.Attack(target);
                        State = StateE.Shooting;
                    }

                    return;

                case StateE.Shooting:

                    if (Weapon.IsReady())  // Cooldowned
                    {
                        if (target != null && Weapon.IsInRange(target))    // New target -> shoot
                        {
                            Object.World.Logger.OnShot(Object, target);
                            Weapon.Attack(target);
                        }
                        else    // No available target -> idle
                        {
                            Object.World.Logger.OnIdle(Object);
                            State = StateE.Idle;
                        }
                    }

                    return;
            }
        }
    }
}

