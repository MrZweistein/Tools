using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuild
{
    public class Solution
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string AssemblyLocation { get; set; }
        public string Version { get; set; }
        public string Script { get; set; }
        public int Increment { get; set; }

        public Solution()
        {
            string crlf = Environment.NewLine;
            Name = "Neue Solution";
            Path = "";
            AssemblyLocation = @"Properties\";
            Version = "1.0.0.0";
            Script = "#Increment"+crlf+"#BuildRelease";
            Increment = 1;
        }

        public override string ToString()
        {
            return $"{Name} ({Version})";
        }
    }
}
