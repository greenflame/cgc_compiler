using System;

namespace cgc_compiler
{
    public class EventLogger
    {
        public GameWorld World { get; private set; }

        public EventLogger(GameWorld world)
        {
            World = world;
        }

        public void OnDeclare(AGameObject obj)
        {
            Console.WriteLine(string.Format("{0} DECLARE {1} {2} {3}",
                World.Time,
                obj.Id,
                obj.Name,
                obj.Owner));
        }

        public void OnDeploy(AGameObject obj)
        {
            Console.WriteLine(string.Format("{0} DEPLOY {1} {2}",
                World.Time,
                obj.Id,
                obj.Position));
        }

        public void OnIdle(AGameObject obj)
        {
            Console.WriteLine(string.Format("{0} IDLE {1} {2}",
                World.Time,
                obj.Id,
                obj.Position));
        }

        public void OnWalk(AGameObject obj, AGameObject target)
        {
            Console.WriteLine(string.Format("{0} WALK {1} {2} {3}",
                World.Time,
                obj.Id,
                obj.Position,
                target.Id));
        }

        public void OnShot(AGameObject obj, AGameObject target)
        {
            Console.WriteLine(string.Format("{0} SHOT {1} {2} {3}",
                World.Time,
                obj.Id,
                obj.Position,
                target.Id));
        }

        public void OnHealthUpdate(AGameObject obj)
        {
            Console.WriteLine(string.Format("{0} HEALTH {1} {2}",
                World.Time,
                obj.Id,
                obj.GetComponent<Health>().CurrentHealth));
        }

        public void OnDeath(AGameObject obj)
        {
            Console.WriteLine(string.Format("{0} DEATH {1}",
                World.Time,
                obj.Id));
        }
    }
}

