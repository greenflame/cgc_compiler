using System;
using System.IO;

namespace cgc_compiler
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			FitCultureInfo();

			if (args.Length != 2)
			{
				Console.WriteLine ("Invalid arguments length");
				return;
			}

			string LeftAiExecutionString = args [0];
			string RightAiExecutionString = args [1];

			using (FileStream glfs = File.Open("game_log.txt", FileMode.Create))
			using (StreamWriter gameLog = new StreamWriter(glfs))
			using (FileStream elfs = File.Open("execution_log.txt", FileMode.Create))
			using (StreamWriter executionLog = new StreamWriter(elfs))
            {
				try {
					executionLog.WriteLine(string.Format("Left execution string: ", args[0]));
					executionLog.WriteLine(string.Format("Right execution string: ", args[1]));

					Judge judge = new Judge (
						LeftAiExecutionString,
						RightAiExecutionString,
						gameLog.WriteLine,
						executionLog.WriteLine,
						Console.WriteLine
					);
					judge.RunSimulation (
						Configuration.SimulationStep,
						Configuration.MaxSimulationTime,
						Configuration.StrategyRunInterval
					);
				} catch (Exception ex) {
					executionLog.WriteLine(ex.Message);
					Console.WriteLine(ex.Message);
				}
			}
        }

		public static void FitCultureInfo()
		{
			System.Globalization.CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)currentCulture.Clone();

			customCulture.NumberFormat.NumberDecimalSeparator = ".";

			System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
		}

        public static void BuildGame(string LeftAiExecutionString, string RightAiExecutionString,
            Action<string> GameLogger, Action<String> ExecutionLogger, Action<String> BriefLogger)
        {
            FitCultureInfo();

            Judge judge = new Judge(
                LeftAiExecutionString,
                RightAiExecutionString,
                GameLogger,
                ExecutionLogger,
                BriefLogger
            );
            judge.RunSimulation(
                Configuration.SimulationStep,
                Configuration.MaxSimulationTime,
                Configuration.StrategyRunInterval
            );
        }
    }
}
