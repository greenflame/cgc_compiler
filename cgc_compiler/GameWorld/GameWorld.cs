using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cgc_compiler
{
    public class GameWorld : IDynamic
    {
		public float Length { get; private set; }
        public List<GameObject> GameObjects { get; private set; }
        public float GlobalTime { get; private set; }
        public EventLogger EventLogger { get; private set; }

        public GameWorld(float length, Action<string> loggerDelegate)
        {
			Length = length;
            GameObjects = new List<GameObject>();
            EventLogger = new EventLogger(this, loggerDelegate);
        }

        public void Update(float deltaTime)
        {
            GameObjects
                .Select(o => o)
                .ToList()
                .ForEach(o => o.Update(deltaTime));

            GlobalTime += deltaTime;
        }

		public float InvertPosition(float position)
		{
			return Length - position;
		}
    }
}

