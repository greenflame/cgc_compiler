using System;

namespace cgc_compiler
{
    public class Knight : ATroop
    {
        public Knight(GameWorld world, Player owner, float position)
            : base(world, "Knight", owner, position, 600, 10, 0.5f, 3, 1, 1)
        {
            Components.Add(new AngryTroopStrategy(this));
        }
    }
}
