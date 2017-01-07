using System;

namespace cgc_compiler
{
    public class Halfling : ATroop
    {
        public Halfling(GameWorld world, Player owner, float position)
            : base(world, owner, position, 147, 1, 1)
        {
            Components.Add(new Sling());
            Components.Add(new AngryTroopStrategy(this));
        }
    }
}

