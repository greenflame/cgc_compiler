using System;

namespace cgc_compiler
{
    public class Deploy : Component
    {
        public float Time { get; private set; }

        public float TimeRest { get; private set; }

        public Deploy(GameObject obj, float time)
            : base(obj)
        {
            Time = time;
            TimeRest = Time;
        }

        public void ProcessDeploy(float deltaTime)
        {
            TimeRest = Math.Max(0, TimeRest - deltaTime);
        }

        public bool IsDeployed()
        {
            return TimeRest == 0;
        }
    }
}

