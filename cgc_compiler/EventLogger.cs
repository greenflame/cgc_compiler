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

        public void OnCreate(AGameObject obj)
        {
            Logger(string.Format("CREATE {0} {1} {2} {3} {4}",
                World.Time,
                obj.Id,
                obj.Position,

                obj.GetType().ToString().Split('.').Last(),
                obj.Owner));
        }

        public void OnDeploy(AGameObject obj)
        {
            Logger(string.Format("DEPLOY {0} {1} {2}",
                World.Time,
                obj.Id,
                obj.Position));
        }

        public void OnIdle(AGameObject obj)
        {
            Logger(string.Format("IDLE {0} {1} {2}",
                World.Time,
                obj.Id,
                obj.Position));
        }

        public void OnWalk(AGameObject obj, AGameObject target)
        {
            Logger(string.Format("WALK {0} {1} {2} {3}",
                World.Time,
                obj.Id,
                obj.Position,

                target.Id));
        }

        public void OnAttack(AGameObject obj, AGameObject target)
        {
            Logger(string.Format("ATTACK {0} {1} {2} {3}",
                World.Time,
                obj.Id,
                obj.Position,

                target.Id));
        }

        public void OnHealthUpdate(AGameObject obj)
        {
            Logger(string.Format("HEALTH {0} {1} {2} {3}",
                World.Time,
                obj.Id,
                obj.Position,

                obj.GetComponent<Health>().CurrentHealth));
        }

        public void OnDeath(AGameObject obj)
        {
            Logger(string.Format("DEATH {0} {1} {2}",
                World.Time,
                obj.Id,
                obj.Position));
        }
    }
}

