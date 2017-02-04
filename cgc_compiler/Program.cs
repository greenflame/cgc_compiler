using System;
using System.IO;

namespace cgc_compiler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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
				Judge judge = new Judge (
					LeftAiExecutionString,
					RightAiExecutionString,
					gameLog.WriteLine,
					executionLog.WriteLine,
					Console.WriteLine
				);
				judge.RunSimulation (
					Configuration.simulationStep,
					Configuration.maxSimulationTime,
					Configuration.strategyRunInterval
				);
			}
        }
    }
}
