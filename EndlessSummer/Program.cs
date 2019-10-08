using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSummer
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 counter = 0;
            while (true)
            {
                Console.WriteLine($"Do nothing for {counter} times ... ");
                System.Threading.Thread.Sleep(100);
                counter++;
            }

        }
    }
}
