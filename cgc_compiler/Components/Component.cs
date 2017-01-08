using System;

namespace cgc_compiler
{
    public abstract class Component
    {
        public GameObject GameObject { get; private set; }

        public Component(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}

