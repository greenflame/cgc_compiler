using System;
using System.Linq;

namespace cgc_compiler
{
    public class AngryTroopStrategy : AStrategy
    {
        private enum StateE
        {
            Created,
            Deploying,
            Idle,
            Walking,
            Shooting
        }

        private StateE State;
        
        private AGameObject PrevWalkTarget;

        private AWeapon Weapon;

        private Deployer Deployer;

        private Mover Mover;

        public AngryTroopStrategy(AGameObject obj)
            : base(obj)
        {
            Object.World.Logger.OnDeclare(Object);
            Weapon = Object.GetComponent<AWeapon>();
            Deployer = Object.GetComponent<Deployer>();
            Mover = Object.GetComponent<Mover>();
        }

        private AGameObject FindTarget()
        {
            return Object.World.GameObjects
                .Where(o => o.Owner != Object.Owner)    // Enemy
                .Aggregate((AGameObject)null, (a, b) => Metrics.Closest(Object, a, b));    // Closest
        }

        public override void Update(float deltaTime)
        {
            AGameObject target = FindTarget();

            switch (State)
            {
                case StateE.Created:

                    Object.World.Logger.OnDeploy(Object);
                    State = StateE.Deploying;

                    return;

                case StateE.Deploying:

                    if (Deployer.IsFinished())  // Deployment finished
                    {
                        if (target != null)
                        {
                            if (Weapon.IsInRange(target))  // Target is in range -> shoot
                            {
                                Object.World.Logger.OnShot(Object, target);
                                State = StateE.Shooting;
                                Weapon.Attack(target);
                            }
                            else
                            {
                                Object.World.Logger.OnWalk(Object, target); // Target is not in range -> move
                                Mover.Target = target;
                                PrevWalkTarget = target;
                                State = StateE.Walking;
                            }
                        }
                        else    // No target -> idle
                        {
                            Object.World.Logger.OnIdle(Object);
                            State = StateE.Idle;
                        }
                    }

                    return;

                case StateE.Idle:

                    if (target != null)
                    {
                        if (Weapon.IsInRange(target))  // Traget is in range -> shoot
                        {
                            Object.World.Logger.OnShot(Object, target);
                            Weapon.Attack(target);
                            State = StateE.Shooting;
                        }
                        else    // Target is not in range -> move
                        {
                            Object.World.Logger.OnWalk(Object, target);
                            Mover.Target = target;
                            PrevWalkTarget = target;
                            State = StateE.Walking;
                        }
                    }

                    return;

                case StateE.Walking:

                    if (target != null)
                    {
                        if (Weapon.IsInRange(target))  // Target is in range -> shoot
                        {
                            Object.World.Logger.OnShot(Object, target);
                            Weapon.Attack(target);
                            State = StateE.Shooting;
                            Mover.Target = null;
                        }
                        else
                        {
                            if (target == PrevWalkTarget)   // Same target is not in range -> continue walk
                            {
                                Mover.Target = target;
                            }
                            else    // New target is not in range -> new walk
                            {
                                Object.World.Logger.OnWalk(Object, target);
                                Mover.Target = target;
                                PrevWalkTarget = target;
                            }
                        }
                    }
                    else    // No target -> idle
                    {
                        Object.World.Logger.OnIdle(Object);
                        State = StateE.Idle;
                        Mover.Target = null;
                    }

                    return;

                case StateE.Shooting:

                    if (Weapon.IsReady())  // Cooldowned
                    {
                        if (target != null)
                        {
                            if (Weapon.IsInRange(target))  // Target is in range -> shoot
                            {
                                Object.World.Logger.OnShot(Object, target); // To shoot
                                Weapon.Attack(target);
                                State = StateE.Shooting;
                            }
                            else    // Target is not in range
                            {
                                Object.World.Logger.OnWalk(Object, target); // To move
                                Mover.Target = target;
                                PrevWalkTarget = target;
                                State = StateE.Walking;
                            }
                        }
                        else    // No target
                        {
                            Object.World.Logger.OnIdle(Object); // To idle
                            State = StateE.Idle;
                        }
                    }

                    return;
            }
        }
    }
}

