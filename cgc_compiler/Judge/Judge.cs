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

		public string LeftName { get; private set; }
		public string RightName { get; private set; }

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

			LeftName = ExtractStrategyName(leftProgramm);
			RightName = ExtractStrategyName(rightProgramm);

			InitGameWorld();

			// Events
			GameWorld.EventLogger.NameUpdate(Player.Left, LeftName);
			GameWorld.EventLogger.NameUpdate(Player.Right, RightName);

			GameWorld.EventLogger.VsMessage(LeftName, RightName);
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

		private string PlayerName(Player player)
		{
			return player == Player.Left ? LeftName : RightName;
		}

		public void RunSimulation()
		{
			while (GameWorld.GlobalTime < Configuration.MaxSimulationTime)
			{
				while (GameWorld.GlobalTime < Configuration.StrategyRunInterval * TurnNum)
				{
					GameWorld.Update(Configuration.SimulationStep);

					LeftController.ManaController.Produce(Configuration.SimulationStep);
					RightController.ManaController.Produce(Configuration.SimulationStep);

					if (IsAnyoneWin())
					{
						GameWorld.EventLogger.Victory(PlayerName(GetWinner()));
						BriefInfoLogger(GetWinner().ToString() + " strategy won");
						return;
					}
				}

				RunStrategies();
				TurnNum++;
			}

			// Time limit exceeded
			GameWorld.EventLogger.Victory(PlayerName(GetWinner()));
			BriefInfoLogger(GetWinner().ToString() + " strategy won");
		}

		private void RunStrategies()
		{
			string briefLogStr = string.Format("Turn: {0} / {1}", TurnNum,
				(int)Math.Floor(Configuration.MaxSimulationTime / Configuration.StrategyRunInterval));
			
			ExecutionLogger(string.Format("---------- Turn: {0} World time: {1} ----------", TurnNum, GameWorld.GlobalTime));

			ExecutionLogger(string.Format("----- Left strategy: {0}", LeftName));
			RunStrategy(LeftExecuter, LeftController, ref briefLogStr);

			ExecutionLogger(string.Format("----- Right strategy: {0}", RightName));
			RunStrategy(RightExecuter, RightController, ref briefLogStr);

			BriefInfoLogger(briefLogStr);
		}

		private void RunStrategy(Executer executer, PlayerController controller, ref string briefLogStr)
		{
			string input = controller.GenerateInput();

			ExecutionLogger("----- Input:");
			ExecutionLogger(input);

			string output = string.Empty;
			ExecutionResult result;
			Exception executerException = null;

			try
			{
				result = executer.Execute(input, Configuration.MaxExecutionTime, out output);
			}
			catch(Exception ex)
			{
				result = ExecutionResult.ExecuterException;
				executerException = ex;
			}

			briefLogStr += string.Format(" {0}: {1}", controller.Player, result);
			ExecutionLogger(string.Format("----- Executer verdict: {0}", result));
			GameWorld.EventLogger.VerdictUpdate(controller.Player, result.ToString());

			if (executerException != null)
			{
				ExecutionLogger(executerException.Message);
			}

			if (result == ExecutionResult.Sucess)
			{
				ExecutionLogger("----- Output:");
				ExecutionLogger(output);

				ExecutionLogger("----- Output processor:");
				controller.ProcessOutput(output, ExecutionLogger);
			}
		}
	}
}
