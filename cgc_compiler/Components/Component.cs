using System;

namespace cgc_compiler
{
    public abstract class Component
    {
        public GameObject gameObject { get; private set; }

        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}

