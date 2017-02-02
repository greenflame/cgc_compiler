using System;

namespace cgc_compiler
{
	public class Judge
	{
		public GameWorld GameWorld { get; private set; }
		public Action<string> ExecutionLogger { get; private set; }

		public Executer LeftExecuter { get; private set; }
		public Executer RightExecuter { get; private set; }

		public PlayerController LeftController { get; private set; }
		public PlayerController RightController { get; private set; }

		public int TurnNum { get; private set; } = 0;

		public Judge(string leftProgramm, string rightProgramm, Action<string> gameLogger, Action<string> executionLogger)
		{
			GameWorld = new GameWorld(Configuration.WorldLength, gameLogger);
			ExecutionLogger = executionLogger;

			LeftExecuter = new Executer(leftProgramm, Configuration.InputFile, Configuration.OutputFile);
			RightExecuter = new Executer(rightProgramm, Configuration.InputFile, Configuration.OutputFile);

			LeftController = new PlayerController(GameWorld, Player.Left);
			RightController = new PlayerController(GameWorld, Player.Right);

			InitGameWorld();
		}

		private void InitGameWorld()
		{
			GameWorld.GameObjects.Add(new Forge(GameWorld, Player.Left, Configuration.ForgePosition));
			GameWorld.GameObjects.Add(new Tower(GameWorld, Player.Left, Configuration.FirstTowerPosition));

			GameWorld.GameObjects.Add(new Forge(GameWorld, Player.Right, GameWorld.InvertPosition(Configuration.ForgePosition)));
			GameWorld.GameObjects.Add(new Tower(GameWorld, Player.Right, GameWorld.InvertPosition(Configuration.FirstTowerPosition)));
		}

		public void RunSimulation(float simulationStep, float maxSimulationTime, float strategyRunInterval)
		{
			while (GameWorld.GlobalTime < maxSimulationTime)
			{
				while (GameWorld.GlobalTime < strategyRunInterval * TurnNum)
				{
					GameWorld.Update(simulationStep);

					LeftController.ManaController.Produce(simulationStep);
					RightController.ManaController.Produce(simulationStep);
				}

				RunStrategies();
				TurnNum++;
			}
		}

		private void RunStrategies()
		{
			ExecutionLogger(string.Format("---------- Turn: {0} World time: {1} ----------", TurnNum, GameWorld.GlobalTime));

			ExecutionLogger(string.Format("----- Left strategy: {0}", LeftExecuter.ProgramExecutable));
			RunStrategy(LeftExecuter, LeftController);

			ExecutionLogger(string.Format("----- Right strategy: {0}", RightExecuter.ProgramExecutable));
			RunStrategy(RightExecuter, RightController);
		}

		private void RunStrategy(Executer executer, PlayerController controller)
		{
			string input = controller.GenerateInput();

			ExecutionLogger("----- Input:");
			ExecutionLogger(input);

			string output, comment;
			ExecuteResult result = executer.Execute(input, Configuration.MaxExecutionTime, out output, out comment);

			ExecutionLogger(string.Format("----- Executer verdict: {0} Comment: {1}", result, comment));

			if (result == ExecuteResult.Ok)
			{
				ExecutionLogger("----- Output:");
				ExecutionLogger(output);

				ExecutionLogger("----- Output processor:");
				controller.ProcessOutput(output, ExecutionLogger);
			}
		}
	}
}
