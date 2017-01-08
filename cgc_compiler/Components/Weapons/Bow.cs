using System;

namespace cgc_compiler
{
    public class Bow : Weapon
    {
        public float ArrowSpeed { get; private set; }

        public Bow(GameObject obj, float damage, float cooldown, float radius, float arrowSpeed)
            : base(obj, damage, cooldown, radius)
        {
            ArrowSpeed = arrowSpeed;
        }

        protected override void PerformDamageAction()
        {
            GameObject.gameWorld.gameObjects.Add(
                new Arrow(GameObject.gameWorld, GameObject.owner, GameObject.position, CurrentTarget, Damage, ArrowSpeed));
        }

    }
}

