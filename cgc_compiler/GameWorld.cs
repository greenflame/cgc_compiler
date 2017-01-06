using System;
using System.Collections.Generic;
using System.Linq;

namespace cgc_compiler
{
    public class GameWorld : IDynamic
    {
        public List<AGameObject> GameObjects { get; private set; }
        public float Time { get; private set; }
        public EventLogger Logger { get; private set; }

        public GameWorld(Action<string> loggerDelegate)
        {
            GameObjects = new List<AGameObject>();
            Logger = new EventLogger(this, loggerDelegate);
        }

        public void Update(float deltaTime)
        {
            List<AGameObject> freez = GameObjects
                .Select(o => o)
                .ToList();

            // Process strategies
            freez.ForEach(go => {
                go.Components
                    .Where(c => c is AStrategy)
                    .ToList()
                    .ForEach(c => c.Update(deltaTime));
            });

            // Process other components
            freez.ForEach(go => {
                go.Components
                    .Where(c => !(c is AStrategy || c is Mover))
                    .ToList()
                    .ForEach(c => c.Update(deltaTime));
            });

            // Process motion
            freez.ForEach(go => {
                go.Components
                    .Where(c => c is Mover)
                    .ToList()
                    .ForEach(c => c.Update(deltaTime));
            });
                
            Time += deltaTime;
        }
    }
}

