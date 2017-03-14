using System;
using System.Runtime.Serialization;

namespace show_builder
{
    [DataContract]
    public class Strategy
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Executable { get; set; }
        [DataMember]
        public string Interpreter { get; set; }
        [DataMember]
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
            ExecutionPattern = show_builder.ExecutionPattern.Default.Pattern;
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
