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

        public event Action<int> TurnFinished;

        public Strategy LeftStrategy { get; private set; }
        public Strategy RightStrategy { get; private set; }

		public int TurnNum { get; private set; } = 0;

		public Judge(string leftProgramm, string rightProgramm, Action<string> gameLogger, Action<string> executionLogger, Action<string> briefInfoLogger)
		{
			GameWorld = new GameWorld(Configuration.WorldLength, gameLogger);
			ExecutionLogger = executionLogger;
			BriefInfoLogger = briefInfoLogger;

            LeftStrategy = new Strategy(GameWorld.LeftPlayer, leftProgramm);
            RightStrategy = new Strategy(GameWorld.RightPlayer, rightProgramm);

			// Events
			GameWorld.EventLogger.NameUpdate(LeftStrategy);
			GameWorld.EventLogger.NameUpdate(RightStrategy);

			GameWorld.EventLogger.VsMessage(LeftStrategy.Name, RightStrategy.Name);
		}

		public void RunSimulation()
		{
			while (GameWorld.GlobalTime < Configuration.MaxSimulationTime)
			{
				while (GameWorld.GlobalTime < Configuration.StrategyRunInterval * TurnNum)
				{
					GameWorld.Update(Configuration.SimulationStep);

					if (GameWorld.IsAnyoneWin())
					{
						GameWorld.EventLogger.Victory(GameWorld.GetWinner().Name);
						BriefInfoLogger(GameWorld.GetWinner().Name + " strategy won");
						return;
					}
				}

				RunStrategies();
				TurnNum++;
                TurnFinished?.Invoke(TurnNum);
			}

			// Time limit exceeded
			GameWorld.EventLogger.Victory(GameWorld.GetWinner().Name);
			BriefInfoLogger(GameWorld.GetWinner().Name + " strategy won");
		}

		private void RunStrategies()
		{
			string briefLogStr = string.Format("Turn: {0} / {1}", TurnNum,
				(int)Math.Floor(Configuration.MaxSimulationTime / Configuration.StrategyRunInterval));
			
			ExecutionLogger(string.Format("---------- Turn: {0} World time: {1} ----------", TurnNum, GameWorld.GlobalTime));

			ExecutionLogger(string.Format("----- Left strategy: {0}", LeftStrategy.Name));
			RunStrategy(LeftStrategy, ref briefLogStr);

			ExecutionLogger(string.Format("----- Right strategy: {0}", RightStrategy.Name));
			RunStrategy(RightStrategy, ref briefLogStr);

			BriefInfoLogger(briefLogStr);
		}

		private void RunStrategy(Strategy strategy, ref string briefLogStr)
		{
			string input = strategy.GenerateInput();

			ExecutionLogger("----- Input:");
			ExecutionLogger(input);

			string output = string.Empty;
			ExecutionResult result;
			Exception executerException = null;

			try
			{
				result = strategy.Executer.Execute(input, Configuration.MaxExecutionTime, out output);
			}
			catch(Exception ex)
			{
				result = ExecutionResult.ExecuterException;
				executerException = ex;
			}

			briefLogStr += string.Format(" {0}: {1}", strategy.Player, result);
			ExecutionLogger(string.Format("----- Executer verdict: {0}", result));
			GameWorld.EventLogger.VerdictUpdate(strategy.Player, result.ToString());

			if (executerException != null)
			{
				ExecutionLogger(executerException.Message);
			}

			if (result == ExecutionResult.Sucess)
			{
				ExecutionLogger("----- Output:");
				ExecutionLogger(output);

				ExecutionLogger("----- Output processor:");
				strategy.ProcessOutput(output, ExecutionLogger);
			}
		}
	}
}
