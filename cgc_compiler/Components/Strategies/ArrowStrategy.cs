//using System;
//
//namespace cgc_compiler
//{
//    public class ArrowStrategy : AStrategy
//    {
//        public float Damage { get; private set; }
//
//        public GameObject Target { get; private set; }
//
//        private Mover Mover;
//
//        public ArrowStrategy(GameObject obj, GameObject target, float damage)
//            : base(obj)
//        {
//            Mover = Object.GetComponent<Mover>();    
//            Mover.Target = target;
//
//            Damage = damage;
//            Target = target;
//        }
//
//        public override void Update(float deltaTime)
//        {
//            if (Metrics.Equals(Metrics.Distance(Object, Target), 0))
//            {
//                Target.GetComponent<Health>().TakeDamage(Damage);
//                Object.Destroy();
//            }
//
//            if (!Object.World.GameObjects.Contains(Target))
//            {
//                Object.Destroy();
//            }
//        }
//    }
//}
//
