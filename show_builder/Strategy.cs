using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace show_builder
{
    public class Strategy
    {
        public string Name { get; set; }
        public string Executable { get; set; }
        public string Interpreter { get; set; }
        public string ExecutionPattern { get; set; }

        public Strategy(string name, string executable, string interpreter, string executionPattern)
        {
            Name = name;
            Executable = executable;
            Interpreter = interpreter;
            ExecutionPattern = executionPattern;
        }

        public Strategy()
        {
            Name = "New strategy name";
            Executable = "Full path to executable";
            Interpreter = "Full path to interpreter";
            ExecutionPattern = show_builder.ExecutionPattern.DefaultPattern.Pattern;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public string CombineExecutionString()
        {
            string template = ExecutionPattern
                .Replace("{i}", Interpreter)
                .Replace("{e}", "{0}");

            return string.Format("{0}|{1}", Executable, template);
        }
    }
}
