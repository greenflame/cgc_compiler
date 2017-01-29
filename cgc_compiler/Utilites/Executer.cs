﻿using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace cgc_compiler
{
	public enum ExecuteResult
	{
		Ok,                // все хорошо
		InternalError,     // ошибка в процессе выполнения внешней программы
		TimeOut,           // слишком длительное время выполнения внешней программы
		WriteInputError,   // ошибка записи входных данных для внешней программы
		NoOutput,          // отсутствует файл выходных данных
		ReadOutputError,   // ошибка в процессе чтения выходных данных
		EmptyOutput,       // пустой файл выходных данных
		NotStarted,        // не удалось запустить внешнюю программы
		WrongInputData,    // неверные входные данные (обрабатывается в наследниках ExternalProgramExecuter)
		WrongOutputFormat, // неверный формат выходных данных (обрабатывается в наследниках ExternalProgramExecuter)
		WrongOutputData,   // неверные выходные данные (обрабатывается в наследниках ExternalProgramExecuter)
		OutputTooBig,      //слишком большой файл
		OtherError         // другая ошибка
	}


	public class Executer
	{
		/*
          Интервал, с которым опрашивается состояние запущенного внешнего процесса (в миллисекундах)
        */
		public const int ProcessCheckTimeInterval = 10;

		private string programExecutable;
		private string localDriteProgramDirectory;
		private string inputFileName,
		outputFileName;
		private string _javaPath;

		public Executer(string programExecutable,
			string inputFileName, string outputFileName, string javaPath)
		{
			_javaPath = javaPath;
			this.programExecutable = programExecutable;
			this.inputFileName = inputFileName;
			this.outputFileName = outputFileName;
			Random rnd = new Random();
			rnd = new Random(rnd.Next() + programExecutable.GetHashCode());
			string randomStr = "";
			for (int i = 0; i < 8; i++)
				randomStr += "0123456789ABCDEF"[rnd.Next(16)];
			#if NET40
			localDriteProgramDirectory = Path.Combine(Path.GetTempPath(), TempSubdir, randomStr);
			#else
			localDriteProgramDirectory = Path.Combine(Path.Combine(Path.GetTempPath(), TempSubdir), randomStr);
			#endif
			Init();
		}


		public void Init()
		{
			DeleteLocalDriveProgramDirectory();
			int attemptCount = 50;
			Exception lastException=null;
			while (attemptCount-- > 0)
			{
				try
				{
					Directory.CreateDirectory(LocalDriveProgramDirectory);
					if (Directory.Exists(LocalDriveProgramDirectory))
					{
						break;
					}
				}
				catch (Exception e) { lastException = e; }

			}

			if (attemptCount == 0)
			{
				throw new ExecuterException(string.Format("Error creating subdir ({0})", LocalDriveProgramDirectory), lastException);
			}

			try
			{
				File.Copy(ProgramExecutable, LocalDriveProgramExecutable);
			}
			catch (Exception e)
			{
				throw new ExecuterException(string.Format("Error coping file ({0}) into file ({1})", ProgramExecutable, LocalDriveProgramExecutable), e);
			}
		}


		public void DeleteLocalDriveProgramDirectory()
		{
			try
			{
				if (Directory.Exists(LocalDriveProgramDirectory))
					Directory.Delete(LocalDriveProgramDirectory, true);
			}
			catch (Exception e)
			{
				throw new ExecuterException(string.Format("Error deleting subdir ({0})", LocalDriveProgramDirectory), e);
			}
		}


		public static void DeleteTempSubdir()
		{
			try
			{
				Directory.Delete(Path.Combine(Path.GetTempPath(), TempSubdir), true);
			}
			catch (Exception e)
			{
				if(Debugger.IsAttached)
					throw new ExecuterException(string.Format("Error deleting temp subdir ({0})", TempSubdir), e);
			}
		}


		/*
          Исполняет программу, подсовывая в качестве входных данных inputFileContent;
          воpащает код выполнения и через outputFileContent содержимое выходного файла;
          maxTime - максимальное время выполнения в секундах, после чего процесс убивается
        */
		public virtual ExecuteResult Execute(string inputFileContent, double maxTime,
			out string outputFileContent, out string comment)
		{
			outputFileContent = null;
			comment = null;

			string inputFileName = Path.Combine(LocalDriveProgramDirectory, this.inputFileName),
			outputFileName = Path.Combine(LocalDriveProgramDirectory, this.outputFileName);
			Process process = null;
			try
			{
				try
				{
					File.WriteAllText(inputFileName, inputFileContent, Encoding.Default);
				}
				catch (Exception)
				{
					return ExecuteResult.WriteInputError;
				}
				process = new Process();
				process.StartInfo.WorkingDirectory = LocalDriveProgramDirectory;
				if (ProgramExecutableFilnameOnly.Substring(ProgramExecutableFilnameOnly.Length - 4) == ".jar")
				{
					process.StartInfo.FileName = _javaPath;
					process.StartInfo.Arguments = "-jar " + LocalDriveProgramExecutable;
				}
				else
				{
					process.StartInfo.FileName = LocalDriveProgramExecutable;
				}
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				if (process.Start())
				{
					DateTime startTime = DateTime.Now;
					while (!process.HasExited)
					{
						Thread.Sleep(ProcessCheckTimeInterval);
						if ((DateTime.Now - startTime).TotalSeconds > maxTime)
							break;
					}
					if (process.HasExited)
					{
						if (process.ExitCode == 0)
						{
							if (File.Exists(outputFileName))
							{
								bool readSuccessfully = false;
								int k = 50; //максимум полсекунды ждем
								while (!readSuccessfully && k-- > 0)
								{
									try
									{
										outputFileContent = File.ReadAllText(outputFileName, Encoding.Default);
										readSuccessfully = true;
									}
									catch
									{
										Thread.Sleep(10);
									}
								}

								if (readSuccessfully)
								{
									if (outputFileContent == null || outputFileContent.Trim() == "")
										return ExecuteResult.EmptyOutput;
									if (outputFileContent.Length > 10000)
									{
										outputFileContent = "";
										return ExecuteResult.OutputTooBig;
									}
									return ExecuteResult.Ok;
								}
								else
								{
									return ExecuteResult.ReadOutputError;
								}
							}
							else
								return ExecuteResult.NoOutput;
						}
						else
						{
							comment = string.Format("ExitCode = {0}", process.ExitCode);
							return ExecuteResult.InternalError;
						}
					}
					else
					{
						try
						{
							process.Kill();
							while (!process.HasExited)
								Thread.Sleep(ProcessCheckTimeInterval);
						}
						catch (Exception)
						{
						}
						return ExecuteResult.TimeOut;
					}
				}
				else
					return ExecuteResult.NotStarted;
			}
			catch
			{
				comment = string.Format("ExitCode = {0}", process.ExitCode);
				return ExecuteResult.InternalError;
			}
			finally
			{
				// еще одна попытка убить если вдруг работающий процесс
				try
				{
					if (process != null && !process.HasExited)
						process.Kill();
				}
				catch (Exception) { }

				//        throw;
			}
		}


		public static string TempSubdir { get { return "Temp1"; } }

		public string ProgramExecutable { get { return programExecutable; } }
		public string ProgramExecutableFilnameOnly { get { return Path.GetFileName(programExecutable); } }
		public string LocalDriveProgramDirectory { get { return localDriteProgramDirectory; } }
		public string LocalDriveProgramExecutable { get { return Path.Combine(LocalDriveProgramDirectory, ProgramExecutableFilnameOnly); } }
		public string InputFileName { get { return inputFileName; } }
		public string OutputFileName { get { return outputFileName; } }
	}


	public class ExecuterException : ApplicationException
	{
		public ExecuterException()
			: base()
		{
		}

		public ExecuterException(string message)
			: base(message)
		{
		}

		public ExecuterException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
