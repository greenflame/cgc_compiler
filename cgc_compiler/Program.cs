using System;
using System.IO;

namespace cgc_compiler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (FileStream fs = File.Open("/Users/Alexander/Desktop/log1", FileMode.Create))
            using (StreamWriter tw = new StreamWriter(fs))
            {
				Judge judge = new Judge ("ai1.out", "ai2.out", tw.WriteLine, Console.WriteLine);
				judge.Simulate (0.01f, 180, 1);
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