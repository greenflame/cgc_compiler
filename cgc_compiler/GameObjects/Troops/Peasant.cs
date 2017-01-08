using System;
using System.Linq;

namespace cgc_compiler
{
    public class Peasant : Troop
    {
        private const int xp = 600;
        private const float cooldown = 1;
        private const float speed = 1;

        public Peasant(GameWorld world, Player owner, float position)
            : base(world, owner, position, 600, 1, 1)
        {
            weapon = new Sword(this, 10, 0.5f, 0.8f);   // todo
        }

        public override GameObject FindTarget()
        {
            return gameWorld.gameObjects
                .Where(o => o.owner != owner)    // Enemy
                .Where(o => o is IDeployable ? (o as IDeployable).GetDeploy().IsDeployed() : true)    // Deployed
                .Aggregate((GameObject)null, (a, b) => Metrics.Closest(this, a, b));    // Closest
        }
    }
}
