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
			string RightAiExecutionString = args [0];

			using (FileStream glfs = File.Open("game_log.txt", FileMode.Create))
			using (StreamWriter gameLog = new StreamWriter(glfs))
			using (FileStream elfs = File.Open("execution_log.txt", FileMode.Create))
			using (StreamWriter executionLog = new StreamWriter(elfs))
            {
				Judge judge = new Judge (
					LeftAiExecutionString,
					RightAiExecutionString,
					gameLog.WriteLine,
					s => { Console.WriteLine(s); executionLog.WriteLine(s); }
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

/*
#include<fstream>
#include <string>

using namespace std;

int main()
{
    ifstream fin("input.txt");
    ofstream fout("output.txt");

    string s1, s2;
    fin >> s1 >> s2;
    fout << s2 << " 7" << endl;

    fin.close();
    fout.close();


    return 0;
}
*/