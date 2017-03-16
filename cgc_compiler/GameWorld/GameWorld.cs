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

        public Player LeftPlayer { get; private set; }
        public Player RightPlayer { get; private set; }

        public GameWorld(float length, Action<string> loggerDelegate)
        {
			Length = length;
            GameObjects = new List<GameObject>();
            EventLogger = new EventLogger(this, loggerDelegate);

            LeftPlayer = new Player(this, "Left");
            RightPlayer = new Player(this, "Right");

            SpawnTowers();
        }

        public void Update(float deltaTime)
        {
            GameObjects
                .Select(o => o)
                .ToList()
                .ForEach(o => o.Update(deltaTime));

            LeftPlayer.ManaFlask.Produce(deltaTime);
            RightPlayer.ManaFlask.Produce(deltaTime);

            GlobalTime += deltaTime;
        }

		public float InvertPosition(float position)
		{
			return Length - position;
		}

        private void SpawnTowers()
        {
            GameObjects.Add(new Forge(this, LeftPlayer, Configuration.ForgePosition));
            GameObjects.Add(new Tower(this, LeftPlayer, Configuration.FirstTowerPosition));

            GameObjects.Add(new Forge(this, RightPlayer, InvertPosition(Configuration.ForgePosition)));
            GameObjects.Add(new Tower(this, RightPlayer, InvertPosition(Configuration.FirstTowerPosition)));
        }

        public bool IsAnyoneWin()
        {
            return GameObjects
                .Where(o => o is Forge)
                .Count() != 2;
        }

        public Player GetWinner()
        {
            if (LeftPlayer.GetBuildingsHealth() > RightPlayer.GetBuildingsHealth())
            {
                return LeftPlayer;
            }
            else
            {
                return RightPlayer;
            }
        }
    }
}

