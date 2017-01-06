using System;

namespace cgc_compiler
{
    public class Peasant : ATroop
    {
        public Peasant(GameWorld world, Player owner, float position)
            : base(world, owner, position, 600, 10, 0.5f, 0.8f, 1, 1)
        {
            Components.Add(new AngryTroopStrategy(this));
        }
    }
}
