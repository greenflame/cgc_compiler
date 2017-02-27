using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace show_builder
{
    class Game
    {
        public string Name { get; private set; }
        public string GameLog { get; private set; }
        public string ExecutionLog { get; private set; }
        public string BriefLog { get; private set; }

        public Game(string name, string gl, string el, string bl)
        {
            Name = name;
            GameLog = gl;
            ExecutionLog = el;
            BriefLog = bl;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
