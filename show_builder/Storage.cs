using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace show_builder
{
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

        public List<Strategy> Strategies { get; private set; } = new List<Strategy>();
        public List<Game> Games { get; private set; } = new List<Game>();

        public string PlayerExecutable { get; set; }

        public event Action OnStorageChanged;

        private Storage()
        {
        }

        public void BindAll()
        {
            OnStorageChanged?.Invoke();
        }
    }
}
