using System;

namespace cgc_compiler
{
    public abstract class AComponent : IDynamic
    {
        public AGameObject Object { get; private set; }

        public AComponent(AGameObject obj)
        {
            Object = obj;
        }

        public void Destroy()
        {
            Object.Components.Remove(this);
        }

        public abstract void Update(float deltaTime);
    }
}
