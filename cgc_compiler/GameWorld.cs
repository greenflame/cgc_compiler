using System;
using System.Collections.Generic;
using System.Linq;

namespace cgc_compiler
{
    public class GameWorld : IDynamic
    {
        public List<GameObject> GameObjects { get; private set; }
        public float GlobalTime { get; private set; }
        public EventLogger EventLlogger { get; private set; }

        public GameWorld(Action<string> loggerDelegate)
        {
            GameObjects = new List<GameObject>();
            EventLlogger = new EventLogger(this, loggerDelegate);
        }

        public void Update(float deltaTime)
        {
            GameObjects
                .Select(o => o)
                .ToList()
                .ForEach(o => o.Update(deltaTime));

            GlobalTime += deltaTime;
        }
    }
}

