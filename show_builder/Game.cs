using cgc_compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace show_builder
{
    public class Game
    {
        public string Name => string.Format("{0} vs {1}", Left.Name, Right.Name);

        public Strategy Left { get; private set; }
        public Strategy Right { get; private set; }

        public string GameLog { get; private set; }
        public string ExecutionLog { get; private set; }
        public string BriefLog { get; private set; }

        public bool IsInterrupting { get; private set; }
        public bool IsBuildFinished { get; private set; }

        private Thread WorkerThread;

        public Game(Strategy left, Strategy right)
        {
            Left = left;
            Right = right;
        }

        private void CheckForInterrupt()
        {
            if (IsInterrupting)
            {
                Thread.CurrentThread.Abort();
            }
        }

        private void Builder()
        {
            try
            {
                IsInterrupting = false;
                IsBuildFinished = false;

                GameLog = "";
                ExecutionLog = "";
                BriefLog = "";

                MainClass.FitCultureInfo();

                Judge judge = new Judge(
                    Left.CombineExecutionString(),
                    Right.CombineExecutionString(),
                    s =>
                    {
                        GameLog += s + Environment.NewLine;
                        CheckForInterrupt();
                    },
                    s =>
                    {
                        ExecutionLog += s + Environment.NewLine;
                        CheckForInterrupt();
                    },
                    s =>
                    {
                        BriefLog += s + Environment.NewLine;
                        CheckForInterrupt();
                    }
                );

                judge.RunSimulation();

                IsBuildFinished = true;
            }
            catch (Exception ex)
            {
                BriefLog += ex.Message + Environment.NewLine;
            }
        }

        private void buttonInterrupt_Click(object sender, EventArgs e)
        {
            IsInterrupting = true;
        }

        public void StartBuild()
        {
            if (IsBuilding)
            {
                throw new Exception("Build thread is already running.");
            }

            if (IsBuildFinished)
            {
                throw new Exception("Build was completed.");
            }

            WorkerThread = new Thread(Builder);
            WorkerThread.Start();
        }

        public bool IsBuilding => WorkerThread != null && WorkerThread.IsAlive;

        public void StopBuild()
        {
            if (!IsBuilding)
            {
                throw new Exception("Builder is not working.");
            }

            if (IsInterrupting)
            {
                throw new Exception("Interruption is already in progress");
            }

            IsInterrupting = true;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
