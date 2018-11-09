using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuild
{
    public class Logic
    {
        public static int LastError { get; private set; } = 0;
        public static bool Preprocessor()
        {
            return true;
        }

        public static string PreprocessorHelp()
        {
            string crlf = Environment.NewLine;
            string result = "";
            result += "Commands:"+crlf;
            result += "  #IncrementVersion    - Increments Versioncounter by the predefined value" + crlf;
            result += "  #UpdateAssembly      - Increments Versioncounter by the predefined value" + crlf;
            result += "  #Build               - Builds the solution" + crlf;
            result += "  #Exe <Command>       - Executes the <Command> on the commandline" + crlf;
            result += "Variables:" + crlf;
            result += "  ~Version    - full version " + crlf;
            return result;
        }
    }
}
