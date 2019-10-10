using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBatch
{
    /// <summary>
    /// Class to handle Ini File Access and manipulation
    /// </summary>
    internal class IniFile
    {
        string Path { get; set; }

        public IniFile()
        {
            Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
