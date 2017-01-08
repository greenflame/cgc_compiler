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

        public void OnCreate(GameObject obj)
        {
            Logger(string.Format("CREATE {0} {1} {2} {3} {4}",
                World.globalTime,
                obj.id,
                obj.position,

                obj.GetType().ToString().Split('.').Last(),
                obj.owner));
        }

        public void OnDeploy(GameObject obj)
        {
            Logger(string.Format("DEPLOY {0} {1} {2}",
                World.globalTime,
                obj.id,
                obj.position));
        }

        public void OnIdle(GameObject obj)
        {
            Logger(string.Format("IDLE {0} {1} {2}",
                World.globalTime,
                obj.id,
                obj.position));
        }

        public void OnWalk(GameObject obj, GameObject target)
        {
            Logger(string.Format("WALK {0} {1} {2} {3} {4}",
                World.globalTime,
                obj.id,
                obj.position,

                target.id,
                (obj as IMovable).GetMover().Speed));
        }

        public void OnAttack(GameObject obj, GameObject target)
        {
            Logger(string.Format("ATTACK {0} {1} {2} {3}",
                World.globalTime,
                obj.id,
                obj.position,

                target.id));
        }

        public void OnHealthUpdate(GameObject obj)
        {
            Logger(string.Format("HEALTH {0} {1} {2} {3} {4}",
                World.globalTime,
                obj.id,
                obj.position,

                (obj as IDamagable).GetHealth().CurrentHealth,
                (obj as IDamagable).GetHealth().MaxHealth));
        }

        public void OnDeath(GameObject obj)
        {
            Logger(string.Format("DEATH {0} {1} {2}",
                World.globalTime,
                obj.id,
                obj.position));
        }

        public void OnArrowFlight(GameObject obj, GameObject target, float speed)
        {
            Logger(string.Format("ARROW_FLIGHT {0} {1} {2} {3} {4}",
                World.globalTime,
                obj.id,
                obj.position,

                target.id,
                speed));
        }

        public void OnBombFlight(GameObject obj, GameObject target, float speed)  // todo
        {
            Logger(string.Format("BOMB_FLIGHT {0} {1} {2} {3} {4}",
                World.globalTime,
                obj.id,
                obj.position,

                target.id,
                speed));
        }

        public void OnDestroy(GameObject obj)
        {
            Logger(string.Format("DESTROY {0} {1} {2}",
                World.globalTime,
                obj.id,
                obj.position));
        }
    }
}
