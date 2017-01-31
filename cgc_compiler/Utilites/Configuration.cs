using System;

namespace cgc_compiler
{
	public class Configuration
	{
		// Troops
		public static float BaseMotionSpeed = 1;
		public static float MeleeRange = 0.8f;

		// World config
		public const float WorldLength = 20;
		public const float ForgePosition = 0;
		public const float FirstTowerPosition = 5;

		// Executer
		public const float MaxExecutionTime = 1;

		// Player conteroller
		public const float InitialMana = 5;
		public const float ManaProductionSpeed = 1f / 2.8f;
		public const float MaxMana = 8;

		public const int MaxCardQueueLength = 100;
		public const int VisibleCards = 5;
		public const int AvailableCards = 4;
	}
}

