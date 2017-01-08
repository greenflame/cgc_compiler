using System;
using System.Collections.Generic;
using System.Linq;

namespace cgc_compiler
{
    public class GameWorld : IDynamic
    {
        public List<GameObject> gameObjects { get; private set; }
        public float globalTime { get; private set; }
        public EventLogger eventLlogger { get; private set; }

        public GameWorld(Action<string> loggerDelegate)
        {
            gameObjects = new List<GameObject>();
            eventLlogger = new EventLogger(this, loggerDelegate);
        }

        public void Update(float deltaTime)
        {
            gameObjects
                .Select(o => o)
                .ToList()
                .ForEach(o => o.Update(deltaTime));

            globalTime += deltaTime;
        }
    }
}

