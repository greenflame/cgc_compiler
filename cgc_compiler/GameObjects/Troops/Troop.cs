using System;

namespace cgc_compiler
{
    public abstract class Troop : GameObject, IMovable, IDamagable, IDeployable
    {
        private Health health;
        private Mover mover;
        private Deploy deploy;
        protected Weapon weapon;

        private GameObject prevMotionTarget;

        private enum StateE
        {
            Created,
            Deploying,
            Idle,
            Walking,
            Attacking
        }

        private StateE State;

        public Troop(GameWorld world, Player owner, float position, float health, float speed, float deployTime)
            : base(world, owner, position)
        {
            this.health = new Health(this, health);
            this.mover = new Mover(this, speed);
            this.deploy = new Deploy(this, deployTime);
            // todo weapon

            gameWorld.eventLlogger.OnCreate(this);
            gameWorld.eventLlogger.OnHealthUpdate(this);
        }

        public Mover GetMover()
        {
            return mover;
        }

        public Health GetHealth()
        {
            return health;
        }

        public Deploy GetDeploy()
        {
            return deploy;
        }

        public abstract void InitWeapon();

        public abstract GameObject FindTarget();

        public override void Update(float deltaTime)
        {
            GameObject target = FindTarget();

            switch (State)
            {
                case StateE.Created:

                    gameWorld.eventLlogger.OnDeploy(this);
                    State = StateE.Deploying;
                    deploy.ProcessDeploy(deltaTime);

                    return;

                case StateE.Deploying:

                    if (deploy.IsDeployed())  // Deployment finished
                    {
                        if (target != null)
                        {
                            if (weapon.IsInRange(target))  // Target is in range -> shoot
                            {
                                gameWorld.eventLlogger.OnAttack(this, target);
                                State = StateE.Attacking;
                                weapon.InitiateAttack(target);
                                weapon.ProcessAttack(deltaTime);
                            }
                            else
                            {
                                gameWorld.eventLlogger.OnWalk(this, target); // Target is not in range -> move
                                mover.MoveTo(target, deltaTime);
                                prevMotionTarget = target;
                                State = StateE.Walking;
                            }
                        }
                        else    // No target -> idle
                        {
                            gameWorld.eventLlogger.OnIdle(this);
                            State = StateE.Idle;
                        }
                    }
                    else
                    {
                        deploy.ProcessDeploy(deltaTime);
                    }

                    return;

                case StateE.Idle:

                    if (target != null)
                    {
                        if (weapon.IsInRange(target))  // Traget is in range -> shoot
                        {
                            gameWorld.eventLlogger.OnAttack(this, target);
                            weapon.InitiateAttack(target);
                            weapon.ProcessAttack(deltaTime);
                            State = StateE.Attacking;
                        }
                        else    // Target is not in range -> move
                        {
                            gameWorld.eventLlogger.OnWalk(this, target);
                            mover.MoveTo(target, deltaTime);
                            prevMotionTarget = target;
                            State = StateE.Walking;
                        }
                    }

                    return;

                case StateE.Walking:

                    if (target != null)
                    {
                        if (weapon.IsInRange(target))  // Target is in range -> attack
                        {
                            gameWorld.eventLlogger.OnAttack(this, target);
                            weapon.InitiateAttack(target);
                            weapon.ProcessAttack(deltaTime);
                            State = StateE.Attacking;
                        }
                        else
                        {
                            if (target == prevMotionTarget)   // Same target is not in range -> continue walk
                            {
                                mover.MoveTo(target, deltaTime);
                            }
                            else    // New target is not in range -> new walk
                            {
                                gameWorld.eventLlogger.OnWalk(this, target);
                                mover.MoveTo(target, deltaTime);
                                prevMotionTarget = target;
                            }
                        }
                    }
                    else    // No target -> idle
                    {
                        gameWorld.eventLlogger.OnIdle(this);
                        State = StateE.Idle;
                    }

                    return;

                case StateE.Attacking:

                    if (weapon.IsAttackFinished())  // Cooldowned
                    {
                        if (target != null)
                        {
                            if (weapon.IsInRange(this))  // Target is in range -> shoot
                            {
                                gameWorld.eventLlogger.OnAttack(this, target); // To shoot
                                weapon.InitiateAttack(target);
                                weapon.ProcessAttack(deltaTime);
                                State = StateE.Attacking;
                            }
                            else    // Target is not in range
                            {
                                gameWorld.eventLlogger.OnWalk(this, target); // To move
                                mover.MoveTo(target, deltaTime);
                                prevMotionTarget = target;
                                State = StateE.Walking;
                            }
                        }
                        else    // No target
                        {
                            gameWorld.eventLlogger.OnIdle(this); // To idle
                            State = StateE.Idle;
                        }
                    }
                    else
                    {
                        weapon.ProcessAttack(deltaTime);
                    }

                    return;

            }   // Switch end

        }   // Func end
    }
}

