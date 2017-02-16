using System;
using System.Linq;

namespace cgc_compiler
{
    public class EventLogger
    {
        public GameWorld World { get; private set; }
        public Action<string> Logger;

        public EventLogger(GameWorld world, Action<string> logger)
        {
            World = world;
            Logger = logger;
        }

		private float EnemyDirectionPos(GameObject obj)
		{
			return obj.Owner == Player.Right ?
				obj.Position - 1 : 
				obj.Position + 1;
		}

		public void TroopSpawn(GameObject obj)
		{
			Create(obj);
			SetPosition(obj);
			MotionReset(obj);
			SetHealth(obj);
			SetDirectionPos(obj, EnemyDirectionPos(obj));
			AnimationSpawn(obj);
		}

		public void TroopIdle(GameObject obj)
		{
			SetPosition(obj);
			MotionReset(obj);
			AnimationIdle(obj);
		}

		public void TroopWalk(GameObject obj, GameObject target)
		{
			SetPosition(obj);
			SetDirectionTarget(obj, target);
			MotionLinearTarget(obj, target);
			AnimationWalk(obj);
		}

		public void TroopAttack(GameObject obj, GameObject target)
		{
			SetPosition(obj);
			SetDirectionTarget(obj, target);
			MotionReset(obj);
			AnimationAttack(obj);
		}

		public void TroopDie(GameObject obj)
		{
			SetPosition(obj);
			MotionReset(obj);
			AnimationDie(obj);
			DestroyDelayed(obj, 4);
		}

		public void ProjectileTargetShot(GameObject obj, GameObject target)
		{
			Create(obj);
			SetPosition(obj);
			SetDirectionTarget(obj, target);
			MotionParabolicTarget(obj, target);
		}

		public void ProjectilePosShot(GameObject obj, float pos)
		{
			Create(obj);
			SetPosition(obj);
			SetDirectionPos(obj, pos);
			MotionParabolicPos(obj, pos);
		}

		public void TurretCreate(GameObject obj)
		{
			Create(obj);
			SetPosition(obj);
			SetDirectionPos(obj, EnemyDirectionPos(obj));
			SetHealth(obj);
		}

		public void TurretDestroy(GameObject obj)
		{
			Destroy(obj);
		}

        public void Create(GameObject obj)
        {
			string objType = obj is Projectile ?
				(obj as Projectile).Sprite.ToString() :
				obj.GetType ().ToString ().Split ('.').Last ();

            Logger(string.Format("CREATE {0} {1} {2} {3}",
                World.GlobalTime,
				obj.Id,

				objType,
                obj.Owner));
        }

		public void Destroy(GameObject obj)
		{
			Logger(string.Format("DESTROY {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void DestroyDelayed(GameObject obj, float time)
		{
			Logger(string.Format("DESTROY_DELAYED {0} {1} {2}",
				World.GlobalTime,
				obj.Id,

				time));
		}

		public void SetHealth(GameObject obj)
		{
			Logger(string.Format("SET_HEALTH {0} {1} {2} {3}",
				World.GlobalTime,
				obj.Id,

				(obj as IDamagable).GetHealth().CurrentHealth,
				(obj as IDamagable).GetHealth().MaxHealth));
		}

		public void SetPosition(GameObject obj)
		{
			Logger(string.Format("SET_POSITION {0} {1} {2}",
				World.GlobalTime,
				obj.Id,

				obj.Position));
		}

		public void SetDirectionTarget(GameObject obj, GameObject target)
		{
			Logger(string.Format("SET_DIRECTION_TARGET {0} {1} {2}",
				World.GlobalTime,
				obj.Id,

				target.Id));
		}

		public void SetDirectionPos(GameObject obj, float pos)
		{
			Logger(string.Format("SET_DIRECTION_POS {0} {1} {2}",
				World.GlobalTime,
				obj.Id,

				pos));
		}

		public void MotionReset(GameObject obj)
		{
			Logger(string.Format("MOTION_RESET {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void MotionLinearTarget(GameObject obj, GameObject target)
		{
			Logger(string.Format("MOTION_LINEAR_TARGET {0} {1} {2} {3}",
				World.GlobalTime,
				obj.Id,
			
				target.Id,
				(obj as IMovable).GetMover().Speed));
		}


		public void MotionLinearPos(GameObject obj, float pos)
		{
			Logger(string.Format("MOTION_LINEAR_POS {0} {1} {2} {3}",
				World.GlobalTime,
				obj.Id,

				pos,
				(obj as IMovable).GetMover().Speed));
		}

		public void MotionParabolicTarget(GameObject obj, GameObject target)
		{
			Logger(string.Format("MOTION_PARABOLIC_TARGET {0} {1} {2} {3}",
				World.GlobalTime,
				obj.Id,

				target.Id,
				(obj as IMovable).GetMover().Speed));
		}


		public void MotionParabolicPos(GameObject obj, float pos)
		{
			Logger(string.Format("MOTION_PARABOLIC_POS {0} {1} {2} {3}",
				World.GlobalTime,
				obj.Id,

				pos,
				(obj as IMovable).GetMover().Speed));
		}
			
		public void AnimationSpawn(GameObject obj)
		{
			Logger(string.Format("ANIMATION_SPAWN {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void AnimationIdle(GameObject obj)
		{
			Logger(string.Format("ANIMATION_IDLE {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void AnimationWalk(GameObject obj)
		{
			Logger(string.Format("ANIMATION_WALK {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void AnimationAttack(GameObject obj)
		{
			Logger(string.Format("ANIMATION_ATTACK {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void AnimationDie(GameObject obj)
		{
			Logger(string.Format("ANIMATION_DIE {0} {1}",
				World.GlobalTime,
				obj.Id));
		}

		public void InventoryUpdate(PlayerController controller)
		{
			CardsUpdate(controller.CardQueueController, controller.Player);
			ManaUpdate(controller.ManaController, controller.Player);
		}

		public void CardsUpdate(CardQueueController controller, Player player)
		{
			Logger(string.Format("CARDS_UPDATE {0} {1} {2}",
				World.GlobalTime,

				player.ToString(),
				string.Join(" ", controller.Queue.Select(i => i.ToString()))));
		}

		public void ManaUpdate(ManaController controller, Player player)
		{
			Logger(string.Format("MANA_UPDATE {0} {1} {2}",
				World.GlobalTime,

				player.ToString(),
				controller.CurrentMana));
		}

		public void NameUpdate(Player player, string name)
		{
			Logger(string.Format("NAME_UPDATE {0} {1} {2}",
				World.GlobalTime,

				player.ToString(),
				name));
		}

		public void VerdictUpdate(Player player, string verdict)
		{
			Logger(string.Format("VERDICT_UPDATE {0} {1} {2}",
				World.GlobalTime,

				player.ToString(),
				verdict));
		}

		public void VsMessage(string leftName, string rightName)
		{
			FreezeMessage(Configuration.VsMessageTime, string.Format("{0}   vs   {1}", leftName, rightName));
		}

		public void Victory(string name)
		{
			FreezeMessage(Configuration.VictoryMessageTime, string.Format("{0}   wins!", name));
		}

		public void FreezeMessage(float time, string message)
		{
			Logger(string.Format("FREEZE_MESSAGE {0} {1} {2}",
				World.GlobalTime,

				time,
				message));
		}
    }
}
