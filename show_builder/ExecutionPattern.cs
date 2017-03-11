using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace show_builder
{
    public class ExecutionPattern
    {
        public string Name { get; set; }
        public string Pattern { get; set; }

        public ExecutionPattern(string name, string pattern)
        {
            Name = name;
            Pattern = pattern;
        }

        public override string ToString()
        {
            return Name;
        }

        public static ExecutionPattern DefaultPattern { get; private set; }
        public static ExecutionPattern CustomPattern { get; private set; }

        public static List<ExecutionPattern> AllPatterns { get; private set; } = new List<ExecutionPattern>();

        static ExecutionPattern()
        {
            DefaultPattern = new ExecutionPattern("No interpreter", "{e}#");
            CustomPattern = new ExecutionPattern("Custom", "{i}#-magic_param {e}");

            AllPatterns.Add(DefaultPattern);
            AllPatterns.Add(new ExecutionPattern("Java", "{i}#-jar {e}"));
            AllPatterns.Add(new ExecutionPattern("Python / Node", "{i}#{e}"));
            AllPatterns.Add(CustomPattern);
        }

        public static ExecutionPattern Suggest(string pattern)
        {
            ExecutionPattern recognized = AllPatterns.Where(p => p.Pattern == pattern).FirstOrDefault();

            if (recognized != null)
            {
                return recognized;
            }
            else
            {
                return CustomPattern;
            }
        }
    }
}
