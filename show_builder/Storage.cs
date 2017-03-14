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

        [DataMember]
        public List<Strategy> Strategies { get; private set; } = new List<Strategy>();
        [DataMember]
        public List<Game> Games { get; private set; } = new List<Game>();

        [DataMember]
        public string PlayerExecutable { get; set; }

        public event Action OnStorageChanged;

        private Storage()
        {
        }

        public void BindAll()
        {
            OnStorageChanged?.Invoke();
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
    }
}
