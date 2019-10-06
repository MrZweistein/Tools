/************************************************************************************************************/
/*                                                                                                          */
/*  Handbrake Automation 1.0                                                                                */
/*  Entwickelt durch Roger Spiess, Hamburg,  2019                                                           */
/*  Alle Rechte vorbehalten                                                                                 */
/*                                                                                                          */
/*  Version Historie:                                                                                       */
/*  06-10-2019 Version 1.0                                                                                  */
/*                                                                                                          */
/************************************************************************************************************/
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;


namespace HandbrakeAutomation
{
    class Program
    {
        static bool inputDirectoryOption = false;
        static bool outputDirectoryOption = false;
        static bool recursiveOption = false;
        static bool createDirectoryOption = false;
        static bool filepatternOption = false;
        static bool sortByNameOption = false;
        static bool sortByDateOption = false;
        static bool sortDescending = false;
        static bool allOption = false;
        static bool verboseOption = false;

        static string inputDirectory = default(string);
        static string outputDirectory = default(string);
        static string filePattern = default(string);
        static string options = "-a,-f,-i,-m,-o,-r,-sD,-sD+,-sD-,-sN,-sN+,sN-,-v,-?";


        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Log("Handbrake Automation Version 1.0 (C) 2019 Roger Spiess");
            if (args.Count() == 0)
            {
                ExitWithHelp();
            }
            Parse(args);
            Processing();
            Log("Done.");
        }

        static void ProcessDataReceived(object sender, DataReceivedEventArgs e)
        {
            string re = @"Encoding:.*(\d\d[[:punct:]]\d\d\x20\x25).*ETA\x20(\d{2}h\d{2}m\d{2}s)";
            if (!string.IsNullOrEmpty(e.Data))
            {
                Regex regExp = new Regex(re);
                Match match = regExp.Match(e.Data);
                if (match.Success)
                {
                    if (regExp.IsMatch(e.Data))
                    {
                        string percentage = match.Groups[1].Value;
                        string eta = match.Groups[2].Value;
                    }
                }
            }
        }

        /// <summary>
        /// Main process loop
        /// touch selected files
        /// </summary>
        static void Processing()
        {
            try
            {
                string[] files = Directory.GetFiles(inputDirectory, filePattern, recursiveOption ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                int i = 0;
                int e = 0;

                foreach (string filename in files)
                {
                    string inputfile = Path.GetFileName(filename);
                    try
                    {
                        Log($"[{++i}] Processing '{inputfile}'...", false);
                        ProcessStartInfo processStartInfo = new ProcessStartInfo(@"d:\apps\handbrake\handbrakecli.exe")
                        {
                            Arguments = @"-i " + inputfile + " -o test",
                            CreateNoWindow = false,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = false,
                        };

                        using (Process exeProcess = Process.Start(processStartInfo))
                        {
                            exeProcess.WaitForExit();
                            Log("...");
                        };

                        Log("Done");
                    }
                    catch (IOException)
                    {
                        Log("Error");
                        e++;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Log("Error");
                        e++;
                    }
                    catch
                    {
                        Log("Error");
                        e++;
                    }
                }
                Log($"Processed {files.Count()} file(s). {e} error(s).");
            }
            catch (UnauthorizedAccessException)
            {
                ExitWithError("Accessing directory: unauthorized access.", 200);
            }
            catch (PathTooLongException)
            {
                ExitWithError("Accessing files: path too long", 201);
            }

        }

        /// <summary>
        /// Identify if an item is member of a set of T
        /// </summary>
        /// <typeparam name="T">type of the set</typeparam>
        /// <param name="compare">member to lookup</param>
        /// <param name="members">set</param>
        /// <returns>true if found</returns>
        static bool MemberOf<T>(T compare, params T[] members)
        {
            return members.Contains<T>(compare);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compare"></param>
        /// <param name="memberstring"></param>
        /// <returns></returns>
        static bool MemberOf(string compare, string memberstring)
        {
            return MemberOf(compare, memberstring.Split(','));
        }

        /// <summary>
        /// Parsing the command line
        /// </summary>
        /// <param name="args">command line parameters</param>
        static void Parse(string[] args)
        {
            bool outputDirectoryNotExisting = false;
            List<string> _args = new List<string>();
            foreach (string elem in args)
            {
                _args.AddRange(elem.Split('"', ' '));
            }
            _args = _args.Where((e) => e != "").ToList();
            for (int i = 0; i < _args.Count(); i++)
            {
                bool Inc() => ++i < _args.Count();
                string option = _args[i];
                if (option == "-i")
                {
                    if (inputDirectoryOption)
                    {
                        ExitWithError(100, option);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError(101, option);
                        }
                        inputDirectoryOption = true;
                        inputDirectory = nextItem.Trim('"');
                        if (!Directory.Exists(inputDirectory))
                        {
                            ExitWithError(102, $"{option} '{inputDirectory}'");
                        }
                    }
                    else
                    {
                        ExitWithError(101, option);
                    }
                }
                if (option == "-o")
                {
                    if (outputDirectoryOption)
                    {
                        ExitWithError(100, option);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError(101, option);
                        }
                        outputDirectoryOption = true;
                        outputDirectory = nextItem.Trim('"');
                        outputDirectoryNotExisting = !Directory.Exists(outputDirectory);
                    }
                    else
                    {
                        ExitWithError(101, option);
                    }
                }
                else if (MemberOf(option, "-sD,-sD+,-sD-"))
                {
                    if (sortByDateOption | sortByNameOption)
                    {
                        ExitWithError(104, option);
                    }
                    sortByDateOption = true;
                    if (option == "sD-")
                    {
                        sortDescending = true;
                    }
                }
                else if (MemberOf(option, "-sN,-sN+,-sN-"))
                {
                    if (sortByDateOption | sortByNameOption)
                    {
                        ExitWithError(104, option);
                    }
                    sortByNameOption = true;
                    if (option == "sN-")
                    {
                        sortDescending = true;
                    }
                }
                else if (option == "-r")
                {
                    if (recursiveOption)
                    {
                        ExitWithError(100, option);
                    }
                    recursiveOption = true;
                }
                else if (option == "-m")
                {
                    if (createDirectoryOption)
                    {
                        ExitWithError(100, option);
                    }
                    createDirectoryOption = true;
                }
                else if (option == "-f")
                {
                    if (filepatternOption)
                    {
                        ExitWithError(100, option);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError(103, option);
                        }
                        filepatternOption = true;
                        filePattern = nextItem;
                    }
                    else
                    {
                        ExitWithError(103, option);
                    }
                }
                else if (option == "-a")
                {
                    if (allOption)
                    {
                        ExitWithError(100, option);
                    }
                    allOption = true;
                }
                else if (option == "-v")
                {
                    if (verboseOption)
                    {
                        ExitWithError(100, option);
                    }
                    verboseOption = true;
                }
                else if (option == "-?")
                {
                    ExitWithHelp();
                }
                else
                {
                    ExitWithError(999, option, true);
                    ExitWithHelp();
                }
            }
            if (!inputDirectoryOption)
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }
            if (!createDirectoryOption & outputDirectoryNotExisting)
            {
                ExitWithError(102, $"-o '{outputDirectory}'");
            }
            allOption = !(filepatternOption | inputDirectoryOption);
            if (allOption)
            {
                filePattern = "*.*";
            }
            Log($"Start processing using options: {string.Join(" ", _args)}");
        }

        /// <summary>
        /// Error output with standardized text blocks
        /// </summary>
        /// <param name="errorcode">error code to identify text</param>
        /// <param name="erroroption">option with the error</param>
        /// <param name="dontquit">dont quit after error</param>
        static void ExitWithError(int errorcode, string erroroption = "", bool dontquit = false)
        {
            string error;
            switch (errorcode)
            {
                case 100:
                    error = "Option was already used";
                    break;
                case 101:
                    error = "Missing directory";
                    break;
                case 102:
                    error = "Directory doesn't exist";
                    break;
                case 103:
                    error = "Missing filename or filename pattern";
                    break;
                case 104:
                    error = "Sort option was already defined";
                    break;
                case 999:
                    error = "unknown option";
                    break;
                default:
                    error = "Unknown error";
                    break;
            }
            if (!string.IsNullOrWhiteSpace(erroroption))
            {
                error = erroroption + ": " + error;
            }
            ExitWithError(error, errorcode, dontquit);
        }

        /// <summary>
        /// Error output method
        /// </summary>
        /// <param name="error">Error string</param>
        /// <param name="errorcode">Error code</param>
        /// <param name="dontquit">if true, don't quit the application after the call</param>
        static void ExitWithError(string error, int errorcode, bool dontquit = false)
        {
            WriteLine($"Error ({errorcode}): {error}");
            if (!dontquit) Environment.Exit(errorcode);
        }

        /// <summary>
        /// Output method to the standard console
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="line">Add CRLF at the end if true</param>
        static void Log(string msg, bool line = true)
        {
            if (!verboseOption)
            {
                Write(msg);
                if (line) WriteLine();
            }
        }

        /// <summary>
        /// Giving help on the CLI
        /// </summary>
        static void ExitWithHelp()
        {
            WriteLine("Available options:");
            WriteLine("   -a                 => Standard option. convert all files in the directory. Ignored if -f or -i option is used");
            WriteLine("   -i <directory>     => work with files in <directory>");
            WriteLine("   -r                 => include subdirectories recursively. ");
            WriteLine("   -sD[+|-]           => sort input files by date, +=ascending, -=descending; Default: ascending");
            WriteLine("   -sN[+|-]           => sort input files by name, +=ascending, -=descending; Default: ascending");
            WriteLine("   -f <filepattern>   => touch files with <filepattern>. Use '*' and '?' for pattern");
            WriteLine("   -o <directory>     => output directory");
            WriteLine("   -m                 => create non-existing directories");
            WriteLine("   -v                 => non verbose mode");
            WriteLine("   -?                 => shows this text and surpresses all other options");
            WriteLine();
            Environment.Exit(0);

        }
    }

}