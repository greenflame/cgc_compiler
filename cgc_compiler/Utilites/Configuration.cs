using System;

namespace cgc_compiler
{
	public class Configuration
	{
		// Troops
		public const float BaseMotionSpeed = 1f / 60f;
		public const float MeleeRange = 0.8f;
		public const float BaseDeployTime = 1;
		public const float ProjectileSpeed = 4;
		public const float AreaDamageRange = 0.5f;

		// Spawner
		public const float SpawnDispersion = 0.2f;

		// World config
		public const float WorldLength = 20;
		public const float ForgePosition = 0;
		public const float FirstTowerPosition = 5;
		public const float MaxSpawnPosFirstPhase = 10;
		public const float MaxSpawnPosSecondPhase = 15;

		// Executer
		public const float MaxExecutionTime = 1;

		// Mana controller
		public const float InitialMana = 5;
		public const float ManaProductionSpeed = 1f / 2.8f;
		public const float MaxMana = 8;

		// Card queue
		public const int AvailableCards = 4;

		// Judge
		public const string InputFile = "input.txt";
		public const string OutputFile = "output.txt";

		public const float SimulationStep = 0.01f;
		public const float MaxSimulationTime = 180;
		public const float StrategyRunInterval = 1;

		public const float VsMessageTime = 4;
		public const float VictoryMessageTime = float.MaxValue;
	}
}

