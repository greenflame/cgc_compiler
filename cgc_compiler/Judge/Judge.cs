using System;
using System.IO;
using System.Linq;

namespace cgc_compiler
{
	public class Judge
	{
		public GameWorld GameWorld { get; private set; }
		public Action<string> ExecutionLogger { get; private set; }
		public Action<string> BriefInfoLogger { get; private set; }

		public Executer LeftExecuter { get; private set; }
		public Executer RightExecuter { get; private set; }

		public PlayerController LeftController { get; private set; }
		public PlayerController RightController { get; private set; }

		public int TurnNum { get; private set; } = 0;

		public Judge(string leftProgramm, string rightProgramm, Action<string> gameLogger, Action<string> executionLogger, Action<string> briefInfoLogger)
		{
			GameWorld = new GameWorld(Configuration.WorldLength, gameLogger);
			ExecutionLogger = executionLogger;
			BriefInfoLogger = briefInfoLogger;

			LeftExecuter = new Executer(leftProgramm, Configuration.InputFile, Configuration.OutputFile);
			RightExecuter = new Executer(rightProgramm, Configuration.InputFile, Configuration.OutputFile);

			LeftController = new PlayerController(GameWorld, Player.Left);
			RightController = new PlayerController(GameWorld, Player.Right);

			GameWorld.EventLogger.NameUpdate(Player.Left, ExtractStrategyName(leftProgramm));
			GameWorld.EventLogger.NameUpdate(Player.Right, ExtractStrategyName(rightProgramm));

			InitGameWorld();
		}

		private void InitGameWorld()
		{
			GameWorld.GameObjects.Add(new Forge(GameWorld, Player.Left, Configuration.ForgePosition));
			GameWorld.GameObjects.Add(new Tower(GameWorld, Player.Left, Configuration.FirstTowerPosition));

			GameWorld.GameObjects.Add(new Forge(GameWorld, Player.Right, GameWorld.InvertPosition(Configuration.ForgePosition)));
			GameWorld.GameObjects.Add(new Tower(GameWorld, Player.Right, GameWorld.InvertPosition(Configuration.FirstTowerPosition)));
		}

		private string ExtractStrategyName(string executionString)
		{
			string path = executionString.Split('|')[0];
			string name = Path.GetFileNameWithoutExtension(path);
			return name.Replace(" ", "_");
		}

		private bool IsAnyoneWin()
		{
			return GameWorld.GameObjects
				.Where(o => o is Forge)
				.Count() != 2;
		}

		private float GetBuildingsHealth(Player player)
		{
			return GameWorld.GameObjects
				.Where(o => o is Turret)
				.Where(o => o.Owner == player)
				.Select(o => (o as IDamagable).GetHealth().CurrentHealth)
				.Sum();
		}

		private Player GetWinner()
		{
			if (GetBuildingsHealth(Player.Left) > GetBuildingsHealth(Player.Right))
			{
				return Player.Left;
			}
			else
			{
				return Player.Right;
			}
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

					if (IsAnyoneWin())
					{
						GameWorld.EventLogger.GameEnd(GetWinner());
						BriefInfoLogger(GetWinner().ToString() + " strategy won");
						return;
					}
				}

				RunStrategies();
				TurnNum++;
			}

			// Time limit exceeded
			GameWorld.EventLogger.GameEnd(GetWinner());
			BriefInfoLogger(GetWinner().ToString() + " strategy won");
		}

		private void RunStrategies()
		{
			string briefLogStr = string.Format("Turn: {0} / {1}", TurnNum,
				(int)Math.Floor(Configuration.MaxSimulationTime / Configuration.StrategyRunInterval));
			
			ExecutionLogger(string.Format("---------- Turn: {0} World time: {1} ----------", TurnNum, GameWorld.GlobalTime));

			ExecutionLogger(string.Format("----- Left strategy: {0}", LeftExecuter.ProgramExecutable));
			RunStrategy(LeftExecuter, LeftController, ref briefLogStr);

			ExecutionLogger(string.Format("----- Right strategy: {0}", RightExecuter.ProgramExecutable));
			RunStrategy(RightExecuter, RightController, ref briefLogStr);

			BriefInfoLogger(briefLogStr);
		}

		private void RunStrategy(Executer executer, PlayerController controller, ref string briefLogStr)
		{
			string input = controller.GenerateInput();

			ExecutionLogger("----- Input:");
			ExecutionLogger(input);

			string output, comment;
			ExecuteResult result = executer.Execute(input, Configuration.MaxExecutionTime, out output, out comment);

			briefLogStr += string.Format(" {0}: {1}", controller.Player, result);
			ExecutionLogger(string.Format("----- Executer verdict: {0} Comment: {1}", result, comment));
			GameWorld.EventLogger.VerdictUpdate(controller.Player, result.ToString());

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
