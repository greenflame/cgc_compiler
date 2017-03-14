using cgc_compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace show_builder
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Strategy Left { get; private set; }
        [DataMember]
        public Strategy Right { get; private set; }

        [DataMember]
        public string GameLog { get; private set; } = "";
        [DataMember]
        public string ExecutionLog { get; private set; } = "";
        [DataMember]
        public string BriefLog { get; private set; } = "";

        [DataMember]
        public GameState Status { get; set; } = GameState.Ready;

        public bool IsInterrupting { get; private set; } = false;
        private Thread WorkerThread;

        public Game(Strategy left, Strategy right)
        {
            Left = left;
            Right = right;

            GenerateName();
        }

        private void GenerateName()
        {
            string prefix = "New game";
            int index = 0;

            string name = prefix;

            while(Storage.Instance.Games.Where(g => g.Name == name).Count() != 0)
            {
                name = string.Format("{0} {1}", prefix, ++index);
            }

            Name = name;
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
                Status = GameState.Building;
                Storage.Instance.BindAll();

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
                        Storage.Instance.BindAll();
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

                Status = GameState.Finished;
                Storage.Instance.BindAll();
            }
            catch (Exception ex)
            {
                BriefLog += ex.Message + Environment.NewLine;
                Status = GameState.Error;
                Storage.Instance.BindAll();
            }
        }

        private void buttonInterrupt_Click(object sender, EventArgs e)
        {
            IsInterrupting = true;
        }

        public void StartBuild()
        {
            if (Status == GameState.Building)
            {
                throw new Exception("Build thread is already running.");
            }

            if (Status == GameState.Finished)
            {
                throw new Exception("Build was completed.");
            }

            WorkerThread = new Thread(Builder);
            WorkerThread.IsBackground = true;
            WorkerThread.Start();
        }

        public void StopBuild()
        {
            if (Status != GameState.Building)
            {
                throw new Exception("Builder is not working.");
            }

            if (IsInterrupting)
            {
                throw new Exception("Interruption is already in progress");
            }

            IsInterrupting = true;
        }

        public void JoinBuilder()
        {
            WorkerThread.Join();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} vs {2}) [{3}]", Name, Left.Name, Right.Name, Status);
        }
    }
}
