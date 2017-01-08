//using System;
//using System.Linq;
//
//namespace cgc_compiler
//{
//    public class AngryTroopStrategy : AStrategy
//    {
//        private enum StateE
//        {
//            Created,
//            Deploying,
//            Idle,
//            Walking,
//            Attacking
//        }
//
//        private StateE State;
//        
//        private GameObject PrevWalkTarget;
//
//        private AWeapon Weapon;
//
//        private Deploy Deploy;
//
//        private Mover Mover;
//
//        public AngryTroopStrategy(GameObject obj)
//            : base(obj)
//        {
//            Object.World.Logger.OnCreate(Object);
//            Weapon = Object.GetComponent<AWeapon>();
//            Deploy = Object.GetComponent<Deploy>();
//            Mover = Object.GetComponent<Mover>();
//        }
//
//        private GameObject FindTarget()
//        {
//            return Object.World.GameObjects
//                .Where(o => o.Owner != Object.Owner)    // Enemy
//                .Where(o => o.HasComponent<Deploy>() ? o.GetComponent<Deploy>().IsDeployed() : true)    // Deployed
//                .Aggregate((GameObject)null, (a, b) => Metrics.Closest(Object, a, b));    // Closest
//        }
//
//        public override void Update(float deltaTime)
//        {
//            GameObject target = FindTarget();
//
//            switch (State)
//            {
//                case StateE.Created:
//
//                    Object.World.Logger.OnDeploy(Object);
//                    State = StateE.Deploying;
//
//                    return;
//
//                case StateE.Deploying:
//
//                    if (Deploy.IsDeployed())  // Deployment finished
//                    {
//                        if (target != null)
//                        {
//                            if (Weapon.IsInRange(target))  // Target is in range -> shoot
//                            {
//                                Object.World.Logger.OnAttack(Object, target);
//                                State = StateE.Attacking;
//                                Weapon.Attack(target);
//                            }
//                            else
//                            {
//                                Object.World.Logger.OnWalk(Object, target); // Target is not in range -> move
//                                Mover.Target = target;
//                                PrevWalkTarget = target;
//                                State = StateE.Walking;
//                            }
//                        }
//                        else    // No target -> idle
//                        {
//                            Object.World.Logger.OnIdle(Object);
//                            State = StateE.Idle;
//                        }
//                    }
//
//                    return;
//
//                case StateE.Idle:
//
//                    if (target != null)
//                    {
//                        if (Weapon.IsInRange(target))  // Traget is in range -> shoot
//                        {
//                            Object.World.Logger.OnAttack(Object, target);
//                            Weapon.Attack(target);
//                            State = StateE.Attacking;
//                        }
//                        else    // Target is not in range -> move
//                        {
//                            Object.World.Logger.OnWalk(Object, target);
//                            Mover.Target = target;
//                            PrevWalkTarget = target;
//                            State = StateE.Walking;
//                        }
//                    }
//
//                    return;
//
//                case StateE.Walking:
//
//                    if (target != null)
//                    {
//                        if (Weapon.IsInRange(target))  // Target is in range -> attack
//                        {
//                            Object.World.Logger.OnAttack(Object, target);
//                            Weapon.Attack(target);
//                            State = StateE.Attacking;
//                            Mover.Target = null;
//                        }
//                        else
//                        {
//                            if (target == PrevWalkTarget)   // Same target is not in range -> continue walk
//                            {
//                                Mover.Target = target;
//                            }
//                            else    // New target is not in range -> new walk
//                            {
//                                Object.World.Logger.OnWalk(Object, target);
//                                Mover.Target = target;
//                                PrevWalkTarget = target;
//                            }
//                        }
//                    }
//                    else    // No target -> idle
//                    {
//                        Object.World.Logger.OnIdle(Object);
//                        State = StateE.Idle;
//                        Mover.Target = null;
//                    }
//
//                    return;
//
//                case StateE.Attacking:
//
//                    if (Weapon.IsReady())  // Cooldowned
//                    {
//                        if (target != null)
//                        {
//                            if (Weapon.IsInRange(target))  // Target is in range -> shoot
//                            {
//                                Object.World.Logger.OnAttack(Object, target); // To shoot
//                                Weapon.Attack(target);
//                                State = StateE.Attacking;
//                            }
//                            else    // Target is not in range
//                            {
//                                Object.World.Logger.OnWalk(Object, target); // To move
//                                Mover.Target = target;
//                                PrevWalkTarget = target;
//                                State = StateE.Walking;
//                            }
//                        }
//                        else    // No target
//                        {
//                            Object.World.Logger.OnIdle(Object); // To idle
//                            State = StateE.Idle;
//                        }
//                    }
//
//                    return;
//            }
//        }
//    }
//}
//
