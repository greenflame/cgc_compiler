using System;
using System.Collections.Generic;
using System.Linq;

namespace cgc_compiler
{
    public abstract class GameObject : IDynamic
    {
        public Player owner { get; set; }

        public float position { get; set; }

        public GameWorld gameWorld { get; private set; }

        public int id { get; private set; }

        private static int nextId = 0;

        public GameObject(GameWorld world, Player owner, float position)
        {
            this.owner = owner;
            this.position = position;
            gameWorld = world;
            id = nextId++;
        }

        public abstract void Update(float deltaTime);

        public void Destroy()
        {
            gameWorld.gameObjects.Remove(this);
        }
    }
}

