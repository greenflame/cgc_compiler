using System;

namespace cgc_compiler
{
	public abstract class Turret : GameObject, IDamagable
	{
		public Health Health { get; private set; }
		public Weapon Weapon { get; private set; }

		private enum TurretState
		{
			Idle,
			Attacking
		}

		private TurretState CurrentState { get; set; }

		public Turret(GameWorld world, Player owner, float position, float health)
			: base(world, owner, position)
		{
			Health = new Health(this, health);
			Weapon = MakeWeapon();

			CurrentState = TurretState.Idle;

			GameWorld.EventLlogger.TurretCreate(this);
		}

		public abstract Weapon MakeWeapon();

		public abstract GameObject FindTarget();

		public Health GetHealth()
		{
			return Health;
		}
			
		public override void Update(float deltaTime)
		{
			GameObject target = FindTarget();

			switch (CurrentState)
			{
			case TurretState.Attacking:
				ProcessAttackingState(target, deltaTime);
				return;

			case TurretState.Idle:
				ProcessIdleState(target, deltaTime);
				return;
			}
		}
			
		private void ProcessAttackingState(GameObject target, float deltaTime)
		{
			if (Weapon.IsAttackFinished())  // Attack finished
			{
				if (target != null && Weapon.IsInRange(target))	// Target is in range -> shoot
				{
//					GameWorld.EventLlogger.OnAttack(this, target);
					Weapon.InitiateAttack(target);
					Weapon.ProcessAttack(deltaTime);
					CurrentState = TurretState.Attacking;
				}
				else    // No target -> idle
				{
//					GameWorld.EventLlogger.OnIdle(this);
					CurrentState = TurretState.Idle;
				}
			}
			else    // Continue attack
			{
				Weapon.ProcessAttack(deltaTime);
			}
		}
			
		private void ProcessIdleState(GameObject target, float deltaTime)
		{
			if (target != null && Weapon.IsInRange(target))	// Traget is in range -> shoot
			{
//				GameWorld.EventLlogger.OnAttack(this, target);
				Weapon.InitiateAttack(target);
				Weapon.ProcessAttack(deltaTime);
				CurrentState = TurretState.Attacking;
			}
		}
			
	}
}

