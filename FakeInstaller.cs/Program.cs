using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FakeInstaller
{
    class Program
    {
        static int Main(string[] args)
        {
            WriteLine("FakeInstaller.exe -- I do nothing.");
            System.Threading.Thread.Sleep(1000);
            return 0;
        }
    }
}
