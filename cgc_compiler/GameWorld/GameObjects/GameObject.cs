using System;
using System.Collections.Generic;
using System.Linq;

namespace cgc_compiler
{
    public abstract class GameObject : IDynamic
    {
        public Player Owner { get; set; }

        public float Position { get; set; }

        public GameWorld GameWorld { get; private set; }

        public int Id { get; private set; }

        private static int NextId = 0;

        public GameObject(GameWorld world, Player owner, float position)
        {
            Owner = owner;
            Position = position;
            GameWorld = world;
            Id = NextId++;
        }

        public abstract void Update(float deltaTime);

        public void Destroy()
        {
            GameWorld.GameObjects.Remove(this);
        }
    }
}

