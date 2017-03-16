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
        public Strategy Left { get; set; }
        [DataMember]
        public Strategy Right { get; set; }

        [DataMember]
        public string GameLog { get; private set; } = "";
        [DataMember]
        public string ExecutionLog { get; private set; } = "";
        [DataMember]
        public string BriefLog { get; private set; } = "";

        [DataMember]
        public GameState State { get; set; } = GameState.Ready;

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
                State = GameState.Building;
                Storage.Instance.Bind();

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

                judge.TurnFinished += (i) =>
                {
                    if (i < 3 || i % 5 == 0)
                    {
                        Storage.Instance.Bind();
                    }
                };

                judge.RunSimulation();

                State = GameState.Finished;
                Storage.Instance.Bind();
            }
            catch (ThreadAbortException tae)
            {
                BriefLog += tae.Message + Environment.NewLine;
                State = GameState.Ready;
                Storage.Instance.Bind();
            }
            catch (Exception ex)
            {
                BriefLog += ex.Message + Environment.NewLine;
                State = GameState.Error;
                Storage.Instance.Bind();
            }
        }

        private void buttonInterrupt_Click(object sender, EventArgs e)
        {
            IsInterrupting = true;
        }

        public void StartBuild()
        {
            if (State == GameState.Building)
            {
                throw new Exception("Build thread is already running.");
            }

            if (State == GameState.Finished)
            {
                throw new Exception("Build was completed.");
            }

            WorkerThread = new Thread(Builder);
            WorkerThread.IsBackground = true;
            WorkerThread.Start();
        }

        public async Task StopBuild()
        {
            if (State != GameState.Building)
            {
                throw new Exception("Builder is not running.");
            }

            if (IsInterrupting)
            {
                throw new Exception("Interruption is already in progress");
            }

            IsInterrupting = true;

            await Task.Run(() => WorkerThread.Join());
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} vs {2}) [{3}]", Name, Left.Name, Right.Name, State);
        }
    }
}
