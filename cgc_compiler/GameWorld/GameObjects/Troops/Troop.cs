using System;

namespace cgc_compiler
{
    public abstract class Troop : GameObject, IMovable, IDamagable, IDeployable
    {
        public Health Health { get; private set; }
        public Mover Mover { get; private set; }
        public Deploy Deploy { get; private set; }
        public Weapon Weapon { get; private set; }

        private enum TroopState
        {
            Deploying,
            Idle,
            Walking,
            Attacking
        }

        private TroopState CurrentState { get; set; }
        private GameObject PreviousMotionTarget { get; set; }

        public Troop(GameWorld world, Player owner, float position, float health, float speed, float deployTime)
            : base(world, owner, position)
        {
            Health = new Health(this, health);
            Mover = new Mover(this, speed);
            Deploy = new Deploy(this, deployTime);
            Weapon = MakeWeapon();

            CurrentState = TroopState.Deploying;

			GameWorld.EventLlogger.TroopSpawn(this);
        }

        public abstract Weapon MakeWeapon();

        public abstract GameObject FindTarget();

        public Mover GetMover()
        {
            return Mover;
        }

        public Health GetHealth()
        {
            return Health;
        }

        public Deploy GetDeploy()
        {
            return Deploy;
        }

        public override void Update(float deltaTime)
        {
            GameObject target = FindTarget();

            switch (CurrentState)
            {
                case TroopState.Deploying:
                    ProcessDeployingState(target, deltaTime);
                    return;

                case TroopState.Idle:
                    ProcessIdleState(target, deltaTime);
                    return;

                case TroopState.Walking:
                    ProcessWalkingState(target, deltaTime);
                    return;

                case TroopState.Attacking:
                    ProcessAttackingState(target, deltaTime);
                    return;

            }
        }

        private void ProcessDeployingState(GameObject target, float deltaTime)
        {
            if (Deploy.IsDeployed())  // Deployment finished
            {
                if (target != null)
                {
                    if (Weapon.IsInRange(target))  // Target is in range -> shoot
                    {
						GameWorld.EventLlogger.TroopAttack(this, target);
                        CurrentState = TroopState.Attacking;
                        Weapon.InitiateAttack(target);
                        Weapon.ProcessAttack(deltaTime);
                    }
                    else    // Target is not in range -> move
                    {
						GameWorld.EventLlogger.TroopWalk(this, target);
                        Mover.MoveTo(target, deltaTime);
                        PreviousMotionTarget = target;
                        CurrentState = TroopState.Walking;
                    }
                }
                else    // No target -> idle
                {
					GameWorld.EventLlogger.TroopIdle(this);
                    CurrentState = TroopState.Idle;
                }
            }
            else    // Continue deploy
            {
                Deploy.ProcessDeploy(deltaTime);
            }
        }

        private void ProcessIdleState(GameObject target, float deltaTime)
        {
            if (target != null)
            {
                if (Weapon.IsInRange(target))  // Traget is in range -> shoot
                {
					GameWorld.EventLlogger.TroopAttack(this, target);
                    Weapon.InitiateAttack(target);
                    Weapon.ProcessAttack(deltaTime);
                    CurrentState = TroopState.Attacking;
                }
                else    // Target is not in range -> move
                {
					GameWorld.EventLlogger.TroopWalk(this, target);
                    Mover.MoveTo(target, deltaTime);
                    PreviousMotionTarget = target;
                    CurrentState = TroopState.Walking;
                }
            }
        }

        private void ProcessWalkingState(GameObject target, float deltaTime)
        {
            if (target != null)
            {
                if (Weapon.IsInRange(target))  // Target is in range -> attack
                {
					GameWorld.EventLlogger.TroopAttack(this, target);
                    Weapon.InitiateAttack(target);
                    Weapon.ProcessAttack(deltaTime);
                    CurrentState = TroopState.Attacking;
                }
                else
                {
                    if (target == PreviousMotionTarget)   // Same target is not in range -> continue walk
                    {
                        Mover.MoveTo(target, deltaTime);
                    }
                    else    // New target is not in range -> new walk
                    {
						GameWorld.EventLlogger.TroopWalk(this, target);
                        Mover.MoveTo(target, deltaTime);
                        PreviousMotionTarget = target;
                    }
                }
            }
            else    // No target -> idle
            {
				GameWorld.EventLlogger.TroopIdle(this);
                CurrentState = TroopState.Idle;
            }
        }

        private void ProcessAttackingState(GameObject target, float deltaTime)
        {
            if (Weapon.IsAttackFinished())  // Attack finished
            {
                if (target != null)
                {
                    if (Weapon.IsInRange(target))  // Target is in range -> shoot
                    {
                        GameWorld.EventLlogger.TroopAttack(this, target);
                        Weapon.InitiateAttack(target);
                        Weapon.ProcessAttack(deltaTime);
                        CurrentState = TroopState.Attacking;
                    }
                    else    // Target is not in range -> move
                    {
                        GameWorld.EventLlogger.TroopWalk(this, target);
                        Mover.MoveTo(target, deltaTime);
                        PreviousMotionTarget = target;
                        CurrentState = TroopState.Walking;
                    }
                }
                else    // No target -> idle
                {
                    GameWorld.EventLlogger.TroopIdle(this);
                    CurrentState = TroopState.Idle;
                }
            }
            else    // Continue attack
            {
                Weapon.ProcessAttack(deltaTime);
            }
        }
            
    }
}

