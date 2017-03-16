using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace show_builder
{
    [DataContract]
    class Storage
    {
        [DataMember]
        public List<Strategy> Strategies { get; private set; } = new List<Strategy>();
        [DataMember]
        public List<Game> Games { get; private set; } = new List<Game>();

        [DataMember]
        public string PlayerExecutable { get; set; }

        private static Storage instance;

        public static Storage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Storage();
                }

                return instance;
            }
        }

        public event Action OnChange;

        private Storage()
        {
            OnChange += ProcessQueue;
        }

        public void Bind()
        {
            OnChange?.Invoke();
        }

        // State
        public static void Save(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);

            DataContractSerializer serializer = new DataContractSerializer(
                typeof(Storage),
                new DataContractSerializerSettings() { PreserveObjectReferences = true }
                );

            serializer.WriteObject(fs, instance);
            fs.Close();
        }

        public static void Load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            DataContractSerializer serializer = new DataContractSerializer(
                typeof(Storage),
                new DataContractSerializerSettings() { PreserveObjectReferences = true }
                );

            Storage loadedStorage = serializer.ReadObject(fs) as Storage;
            fs.Close();

            instance = loadedStorage;

            instance.OnChange += instance.ProcessQueue;
        }

        // Building
        public static async Task StopBuilders(List<Game> games)
        {
            if (Instance.Games.Count == 0)
            {
                return;
            }

            games
               .Where(g => g.State == GameState.Inqueued)
               .ToList()
               .ForEach(g => g.State = GameState.Ready);

            await Task.Factory.ContinueWhenAll(Instance.Games
                .Select(g => g.StopBuild())
                .ToArray(), q => { });
        }

        public static async Task StopAllBuilders()
        {
            await StopBuilders(Instance.Games);
        }

        public bool IsBuilding => Games
                .Where(g => g.State == GameState.Building)
                .Count() != 0;

        public void ProcessQueue()
        {
            if (IsBuilding)
            {
                return;
            }

            Game game = Storage.instance.Games
                .Where(g => g.State == GameState.Inqueued)
                .FirstOrDefault();

            if (game == null)
            {
                return;
            }

            game.StartBuild();
        }
    }
}
