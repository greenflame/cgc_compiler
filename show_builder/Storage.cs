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
        }

        public void Bind()
        {
            OnChange?.Invoke();
        }

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
        }

        public static async Task StopAllBuilders()
        {
            if (Instance.Games.Count == 0)
            {
                return;
            }

            await Task.Factory.ContinueWhenAll(Instance.Games
                .Select(g => g.StopBuild())
                .ToArray(), q => { });
        }
    }
}
