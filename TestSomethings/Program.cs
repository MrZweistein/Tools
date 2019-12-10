using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IniParser.Model;
using IniParser.Parser;

namespace TestSomethings
{
    struct Data
    {
        public string a;
        public int b;
    }

    class Program
    {

        static string processingPrefix = "";
        static string filler = new string(' ', 120);
        static Process pr = null;

        static void Main(string[] args)
        {
            //Console.CancelKeyPress += Console_CancelKeyPress;
            //Investigating();
            //Processing();
            //Data data = new Data() { a = "haha", b = 2 };
            //Thread thread = new Thread(Doing);
            //thread.Start(data);
            //Thread.Sleep(2000);
            //thread.Abort();
            TestIni();
            Console.ReadKey();
        }

        static private void TestIni()
        {
            string arguments = "";
            arguments += $@"--preset ""Fast 1080p30"" ";
            arguments += $@"--markers ";
            arguments += $@"--align-av ";
            arguments += $@"--decomb ";
            arguments += $@"--all-subtitles ";
            
            Console.WriteLine(arguments);
            IniDataParser Parser = new IniDataParser();
            IniData Data = Parser.Parse("");
            Data["Arguments"]["Line1"] = arguments;
            Data["Arguments"]["Line2"] = "xxx";
            Console.WriteLine(new string('+', 30));
            Console.WriteLine(Data.ToString());
            Console.WriteLine(Data["Arguments"]["Line1"]);
        }

        private static void Doing(object d)
        {
            int c = 0;
            Data e = (Data)d;
            try
            {
                while (true)
                {
                    Console.Write($"\r{e.a} -> {e.b} -> {c++}");
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine();
                Console.WriteLine("Thread aborted");
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (pr != null)
            {
                if (!pr.HasExited)
                {
                    pr.CancelOutputRead();
                    pr.Kill();
                    pr.Close();
                    pr = null;
                }
                Log("Canceled by user ...");
                Environment.Exit(-1);
            }
        }

        static void Log(string msg, bool line = true)
        {
            Console.Write(msg);
            if (line) Console.WriteLine();
        }


        static void ProcessDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.Write($"\r{processingPrefix}{e.Data}");
            }
        }

        static void Investigating()
        {
            string path = @"e:\ripping\";
            string pattern = @"*.mkv";
            string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            Console.WriteLine($"{files.Length} files ...");
            foreach (var filepath in files)
            {
                Console.WriteLine($"{filepath}  {File.GetCreationTime(filepath).ToString()}");
            }

            Console.WriteLine("Sorted date descending");
            files = files.OrderByDescending(e => File.GetCreationTime(e).ToString()).ToArray();
            foreach (var filepath in files)
            {
                Console.WriteLine($"{filepath}  {File.GetCreationTime(filepath).ToString()}");
            }

            Console.WriteLine("Sorted name descending");
            files = files.OrderByDescending(e => e).ToArray();
            foreach (var filepath in files)
            {
                Console.WriteLine($"{filepath}  {File.GetCreationTime(filepath).ToString()}");
            }
        }

        static void Processing()
        {
            try
            {
                processingPrefix = $"\rProcessing something ...";

                using (pr = new Process())
                {
                    pr.StartInfo.FileName = @"d:\data\Entwicklung\Tools\EndlessSummer\bin\Release\EndlessSummer.exe";
                    pr.StartInfo.Arguments = @"";
                    pr.StartInfo.CreateNoWindow = true;
                    pr.StartInfo.UseShellExecute = false;
                    pr.StartInfo.RedirectStandardOutput = true;
                    pr.StartInfo.RedirectStandardInput = false;
                    pr.EnableRaisingEvents = true;
                    pr.OutputDataReceived += ProcessDataReceived;
                    pr.Start();
                    pr.BeginOutputReadLine();
                    pr.WaitForExit();
                }
                pr = null;
                Log("\r" + filler, false);
                Log(processingPrefix + "Done");
            }
            catch (Exception)
            {
                Log("Error");
            }
        }
    }

}
