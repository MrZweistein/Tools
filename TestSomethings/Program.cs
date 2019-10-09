﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSomethings
{
    class Program
    {

        static string processingPrefix = "";
        static string filler = new string(' ', 120);
        static Process pr = null;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;
            Investigating();
            //Processing();

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
                    pr.StartInfo.FileName = @"d:\data\Dokumente\Visual Studio 2017\Projects\Tools\EndlessSummer\bin\Release\EndlessSummer.exe";
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