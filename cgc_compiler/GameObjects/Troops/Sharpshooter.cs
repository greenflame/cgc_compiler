using System;

namespace cgc_compiler
{
    public class Sharpshooter : ATroop
    {
        public Sharpshooter(GameWorld world, Player owner, float position)
            : base(world, owner, position, 125, 1, 1)
        {
            Components.Add(new Sword(this, 41, 1.2f, 5));
            Components.Add(new AngryTroopStrategy(this));
        }
    }
}

