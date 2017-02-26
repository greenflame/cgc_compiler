using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Linq;


namespace cgc_compiler
{
	public enum ExecutionResult
	{
		Sucess,
		RuntimeError,
		Timeout,
		NotStarted,

		EmptyOutput,
		NoOutput,
		BigOutput,

		ExecuterException
	}


	public class Executer
	{
		public string PrimaryExecutable { get; private set; }
		public string ExecutionTemplate { get; private set; }

		public string TempDir { get; private set; }
		public string TempExecutable { get; private set; }

		public string InputName { get; private set; }
		public string OutputName { get; private set; }

		public string InputPath  { get; private set; }
		public string OutputPath  { get; private set; }

		public const string TempSubdir = "TowerDefence";
		public const int SleepInterval = 20;
		public const int DirectoryCreateAttempts = 50;
		public const string EmptyComment = "No comment";
		public const int MaxKillTimeMs = 1000;
		public const int MaxOutputReadTimeMs = 1000;

		public Executer(string executionString, string inputName, string outputName)
		{
			if (!executionString.Contains("|"))
			{
				executionString += "|{0}#";
			}
				
			PrimaryExecutable = executionString.Split('|')[0];
			ExecutionTemplate = executionString.Split('|')[1];

			InputName = inputName;
			OutputName = outputName;

			TempDir = Path.Combine(Path.GetTempPath(), TempSubdir, RandomString(10));
			RecreateTempDir();

			TempExecutable = Path.Combine(TempDir, Path.GetFileName(PrimaryExecutable));

			InputPath = Path.Combine(TempDir, InputName);
			OutputPath = Path.Combine(TempDir, OutputName);

			File.Copy(PrimaryExecutable, TempExecutable);
		}

		private string RandomString(int length)
		{
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		private void RecreateTempDir()
		{
			if (Directory.Exists(TempDir))
			{
				Directory.Delete(TempDir, true);
			}

            if (Directory.Exists(TempDir))
            {
                Directory.Delete(TempDir, true);
            }

            for (int i = 0; i < DirectoryCreateAttempts; i++)
			{
				try
				{
					Directory.CreateDirectory(TempDir);

					if (Directory.Exists(TempDir))
					{
						break;
					}
				}
				catch (Exception ex)
				{
					Debugger.Log(0, "execution", ex.Message);
				}

			}

			if (!Directory.Exists(TempDir))
			{
				throw new Exception(string.Format("Cann't create temp dir: ({0})", TempDir));
			}
		}

		public delegate bool CheckDelegate();

		public void WaitFor(CheckDelegate checkDelegate, int maxTimeMs)
		{
			for (DateTime startTime = DateTime.Now;
				(DateTime.Now - startTime).TotalMilliseconds < maxTimeMs && !checkDelegate(); )
			{
				Thread.Sleep(SleepInterval);
			}
		}

		public bool TryReadAllText(string path, out string text)
		{
			text = string.Empty;

			try
			{
				text = File.ReadAllText(path, Encoding.Default);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public ExecutionResult Execute(string input, int MaxTimeMs, out string output)
		{
            RecreateTempDir();
            File.Copy(PrimaryExecutable, TempExecutable);

            // Default output
            output = "";

			// Write input
			File.WriteAllText(InputPath, input, Encoding.Default);
            //Thread.Sleep(50);

			// Run process
			Process process  = new Process();

			string tmp = string.Format(ExecutionTemplate, TempExecutable);
			process.StartInfo.FileName = tmp.Split('#')[0];
			process.StartInfo.Arguments = tmp.Split('#')[1];

			process.StartInfo.WorkingDirectory = TempDir;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			if (!process.Start())
			{
				return ExecutionResult.NotStarted;
			}
				
			// Wait for process
			WaitFor(() => process.HasExited, MaxTimeMs);

			// TL -> kill
			if (!process.HasExited)
			{
				process.Kill();

				WaitFor(() => process.HasExited, MaxKillTimeMs);

				if (!process.HasExited)
				{
					throw new Exception("Cann't kill process");
				}

				return ExecutionResult.Timeout;
			}

            Thread.Sleep(30);

            // Runtime error
            if (process.ExitCode != 0)
			{
				return ExecutionResult.RuntimeError;
			}
				
			// No output
			if (!File.Exists(OutputPath))
			{
				return ExecutionResult.NoOutput;
			}

			// Read output
			string tmpOut;

			WaitFor(() => TryReadAllText(OutputPath, out tmpOut), MaxOutputReadTimeMs);

			if (!TryReadAllText(OutputPath, out tmpOut))
			{
				throw new Exception("Cann't read output");
			}

			output = tmpOut;

			// Empty output
			if (string.IsNullOrEmpty(output.Trim()))
			{
				return ExecutionResult.EmptyOutput;
			}

			// Long output
			if (output.Length > 10000)
			{
				return ExecutionResult.BigOutput;
			}

			return ExecutionResult.Sucess;
		}
	}
}
