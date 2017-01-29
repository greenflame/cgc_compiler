using System;

namespace cgc_compiler
{
	public class Judge
	{
		public GameWorld GameWorld { get; private set; }

		public Executer LeftExecuter { get; private set; }
		public Executer RightExecuter { get; private set; }

		public const string InputFile = "input.txt";
		public const string OutputFile = "output.txt";

		public PlayerController LeftController { get; private set; }
		public PlayerController RightController { get; private set; }

		public Judge(string leftProgramm, string rightProgramm, Action<string> logger)
		{
			GameWorld = new GameWorld (Configuration.WorldLength, logger);

			LeftExecuter = new Executer (leftProgramm, InputFile, OutputFile, "");
			RightExecuter = new Executer (rightProgramm, InputFile, OutputFile, "");

			LeftController = new PlayerController (GameWorld, Player.Left);
			RightController = new PlayerController (GameWorld, Player.Right);

			InitGameWorld();
		}

		private void InitGameWorld()
		{
			GameWorld.GameObjects.Add(new Forge(GameWorld, Player.Left, Configuration.ForgePosition));
			GameWorld.GameObjects.Add(new Tower(GameWorld, Player.Left, Configuration.FirstTowerPosition));

			GameWorld.GameObjects.Add(new Forge(GameWorld, Player.Right,
				GameWorld.InvertPosition(Configuration.ForgePosition)));
			GameWorld.GameObjects.Add(new Tower(GameWorld, Player.Right,
				GameWorld.InvertPosition(Configuration.FirstTowerPosition)));
		}

		public void Simulate(float simulationStep, float maxSimulationTime, float strategyRunInterval)
		{
			while (GameWorld.GlobalTime < maxSimulationTime)
			{
				for (float i = 0; i < strategyRunInterval; i += simulationStep)
				{
					GameWorld.Update (simulationStep);

					LeftController.ProduceMana (simulationStep);
					RightController.ProduceMana (simulationStep);
				}

				RunStrategies ();
			}
		}

		private void RunStrategies()
		{
			string leftInput = LeftController.GenerateInput ();
			string rightInput = RightController.GenerateInput ();

			string leftOutput, rightOutput;
			string leftComment, rightComment;

			ExecuteResult leftResult = LeftExecuter.Execute (leftInput, Configuration.MaxExecutionTime, out leftOutput, out leftComment);
			Console.WriteLine (string.Format("Left programm execution result: {0}", leftResult));

			ExecuteResult rightResult = LeftExecuter.Execute (rightInput, Configuration.MaxExecutionTime, out rightOutput, out rightComment);
			Console.WriteLine (string.Format("Right programm execution result: {0}", rightResult));
	
			if (leftResult == ExecuteResult.Ok)
			{
				LeftController.ProcessOutput (leftOutput);
			}

			if (rightResult == ExecuteResult.Ok)
			{
				RightController.ProcessOutput (rightOutput);
			}
		}
	}
}
