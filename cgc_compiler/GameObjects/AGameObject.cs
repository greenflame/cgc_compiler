using System;
using System.Collections.Generic;
using System.Linq;

namespace cgc_compiler
{
    public abstract class AGameObject
    {
        public string Name { get; private set; }

        public Player Owner { get; set; }

        public float Position { get; set; }

        public GameWorld World { get; private set; }

        public List<AComponent> Components { get; private set; }

        public String Id { get; private set; }

        public AGameObject(GameWorld world, string name, Player owner, float position)
        {
            Name = name;
            Owner = owner;
            Position = position;
            World = world;
            Components = new List<AComponent>();
//            Id = Guid.NewGuid();
            Id = "id" + new Random().Next() % 100;
        }

        public List<T> GetComponents<T >() where T : AComponent
        {
            return (List<T>) Components
                .Where(c => c is T)
                .Select(c => c as T)
                .ToList();
        }

        public T GetComponent<T>() where T : AComponent
        {
            return GetComponents<T>().First();
        }

        public bool HasComponent<T>() where T : AComponent
        {
            return GetComponents<T>().Count != 0;
        }

        public void Destroy()
        {
            World.GameObjects.Remove(this);
        }
    }
}

