//using System;
//
//namespace cgc_compiler
//{
//    public abstract class ATower : GameObject
//    {
//        public ATower(GameWorld world, Player owner, float position, float maxHealth,
//            float damage, float cooldown, float radius)
//            : base(world, owner, position)
//        {
//            Components.Add(new Health(this, maxHealth));
//            Components.Add(new Bow(this, damage, cooldown, radius));
//            Components.Add(new TowerStrategy(this));
//        }
//    }
//}
