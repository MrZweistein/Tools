/************************************************************************************************************/
/*                                                                                                          */
/*  Touch Clone Version 1.0                                                                                 */
/*  Entwickelt durch Roger Spiess, Hamburg,  2018                                                           */
/*  Alle Rechte vorbehalten                                                                                 */
/*                                                                                                          */
/************************************************************************************************************/
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using static System.Console;

namespace touch
{
    class Program
    {
        static bool directoryOption = false;
        static bool recursiveOption = false;
        static bool filepatternOption = false;
        static bool allOption = false;
        static bool dateOption = false;
        static bool timeOption = false;
        static bool nowOption = false;
        static bool verboseOption = false;

        static string workingDirectory = default(string);
        static string filePattern = default(string);
        static string dateString = default(string);
        static string timeString = default(string);
        static DateTime datetime = DateTime.Now;

        static void Main(string[] args)
        {
            Parse(args);
            Process();
            Log("Done.");
        }

        static void Process()
        {
            try
            {
                var culture = new System.Globalization.CultureInfo("de-DE");
                string[] formats = { "dd.MM.yyyy hh:mm:ss" };
                string[] files = Directory.GetFiles(workingDirectory, filePattern, recursiveOption ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                int i = 0;
                int e = 0;
                foreach (string filename in files)
                {
                    try
                    {
                        Log($"[{++i}] Processing '{filename}'...", false);
                        DateTime current = Directory.GetLastWriteTime(filename);
                        string currDate = datetime.ToString("dd.MM.yyyy");
                        string currTime = datetime.ToString("hh:mm:ss");
                        if (dateOption & !timeOption)
                        {
                            DateTime timestamp = DateTime.ParseExact(dateString + " " + currTime, formats, culture, System.Globalization.DateTimeStyles.None);
                            Directory.SetLastWriteTime(filename, timestamp);
                        }
                        else if (timeOption & !dateOption)
                        {
                            DateTime timestamp = DateTime.ParseExact(currDate + " " + timeString, formats, culture, System.Globalization.DateTimeStyles.None);
                            Directory.SetLastWriteTime(filename, timestamp);
                        }
                        else
                        {
                            DateTime timestamp = DateTime.ParseExact(dateString + " " + timeString, formats, culture, System.Globalization.DateTimeStyles.None);
                            Directory.SetLastWriteTime(filename, timestamp);
                        }
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
                }
                Log($"Processed {files.Count()} file(s). {e} error(s).");
            }
            catch (UnauthorizedAccessException)
            {
                ExitWithError("Accessing directory: unauthorized access.", 500);
            }
            catch (PathTooLongException)
            {
                ExitWithError("Accessing files: path too long", 501);
            }

        }

        static bool MemberOf<T>(T compare, params T[] members)
        {
            return members.Contains<T>(compare);
        }

        static void Parse(string[] args)
        {
            Log("touch.exe [Version 1.0]");
            if (args.Count() == 0)
            {
                ExitWithError("No arguments", 1, true);
                ExitWithHelp();
            }
            Log($"Parsing arguments...", false);
            string options = "-d,-r,-f,-a,-date,-time,-now,-v,-?";
            var culture = new System.Globalization.CultureInfo("de-DE");
            for (int i = 0; i < args.Count(); i++)
            {
                bool Inc() => ++i < args.Count();
                string option = args[i];
                if (option == "-d")
                {
                    if (Inc())
                    {
                        string nextItem = args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-d option: Missing directory", 100);
                        }
                        directoryOption = true;
                        workingDirectory = nextItem;
                        if (!Directory.Exists(workingDirectory))
                        {
                            ExitWithError($"-d option: Directory '{workingDirectory}' doesn't exist.", 110);
                        }
                    }
                    else
                    {
                        ExitWithError("-d option: Missing directory", 100);
                    }
                }
                else if (option == "-r")
                {
                    recursiveOption = true;
                }
                else if (option == "-f")
                {
                    if (Inc())
                    {
                        string nextItem = args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-f option: Missing filename or filename pattern", 120);
                        }
                        filepatternOption = true;
                        filePattern = nextItem;
                    }
                    else
                    {
                        ExitWithError("-f option: Missing filename or filename pattern", 120);
                    }
                }
                else if (option == "-a")
                {
                    allOption = true;
                }
                else if (option == "-date")
                {
                    if (Inc())
                    {
                        string nextItem = args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-date option: Missing date", 130);
                        }
                        dateOption = true;
                        string rp = "[0-9]{2}[.][0-9]{2}[.][0-9]{4}";
                        if (!Regex.IsMatch(nextItem, rp))
                        {
                            ExitWithError($"-date option: '{nextItem}' doesn't match the required pattern 'dd.mm.yyyy'", 131);
                        }
                        dateString = nextItem;
                        if (!DateTime.TryParseExact(dateString, "dd.MM.yyyy", culture, System.Globalization.DateTimeStyles.None, out var test))
                        {
                            ExitWithError($"-date option: '{nextItem} is not a correct date", 132);
                        }
                    }
                    else
                    {
                        ExitWithError("-date option: Missing date", 130);
                    }
                }
                else if (option == "-time")
                {
                    if (Inc())
                    {
                        string nextItem = args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-time option: Missing time", 140);
                        }
                        timeOption = true;
                        string rp = "[0-9]{2}[/:][0-9]{2}[/:][0-9]{2}";
                        if (!Regex.IsMatch(nextItem, rp))
                        {
                            ExitWithError($"-time: '{nextItem}' doesn't match the required pattern 'hh:mm:ss'", 141);
                        }
                        timeString = nextItem;
                        if (!DateTime.TryParseExact(timeString, "hh:mm:ss", culture, System.Globalization.DateTimeStyles.None, out var test))
                        {
                            ExitWithError($"-time option: '{nextItem} is not a correct time", 132);
                        }
                    }
                    else
                    {
                        ExitWithError("-time option: Missing time", 140);
                    }
                }
                else if (option == "-now")
                {
                    nowOption = true;

                }
                else if (option == "-v")
                {
                    verboseOption = true;
                }
                else if (option == "-?")
                {
                    ExitWithHelp();
                }
                else
                {
                    ExitWithError("Unknown option", 10, true);
                    ExitWithHelp();
                }
            }
            nowOption = !(dateOption | timeOption);
            if (nowOption)
            {
                dateOption = true;
                timeOption = true;
                dateString = datetime.Date.ToString("dd.MM.yyyy");
                timeString = datetime.TimeOfDay.ToString("hh:mm:ss");
            }
            allOption = !(filepatternOption);
            if (!directoryOption)
            {
                workingDirectory = Directory.GetCurrentDirectory();
            }
            if (allOption)
            {
                filePattern = "*.*";
            }
            Log("Done.");
            Log($"Start processing using options: {string.Join(" ", args)}");
        }

        static void ExitWithError(string error, int errorcode, bool dontquit = false)
        {
            WriteLine($"Error ({errorcode}): {error}");
            if (!dontquit) Environment.Exit(errorcode);
        }

        static void Log(string msg, bool line = true)
        {
            if (!verboseOption)
            {
                Write(msg);
                if (line) WriteLine();
            }
        }

        static void ExitWithHelp()
        {
            WriteLine("touch.exe [Version 1.0]");
            WriteLine("Options:");
            WriteLine("   -d <directory>     => work with files in <directory>");
            WriteLine("   -r                 => include subdirectories recursively");
            WriteLine("   -f <filepattern>   => touch files with <filepattern>. Use '*' and '?' for pattern");
            WriteLine("   -a                 => Standard option. touch all files in the directory. Gets ignored if -f option is used");
            WriteLine("   -date <date>       => use <date> for touch. format of <date> is 'dd.mm.yyyy'");
            WriteLine("   -time <time>       => use <time> for touch. format of <time> is 'hh:mm:ss");
            WriteLine("   -now               => Standard option. touch with current timestamp. Gets ignored if -date or -time is used");
            WriteLine("   -v                 => verbose mode");
            WriteLine("   -?                 => shows this text and surpresses all other options");
            WriteLine();
            WriteLine("Usage:");
            WriteLine("   touch -d .\\directory -a -date 01.01.2018 -time 10:00:00");
            WriteLine("   => Changes timestamp of all files in .\\directory with 01.01.2018 10:00:00");
            WriteLine();
            WriteLine("   touch -f name*.* -now");
            WriteLine("   => Changes timestamp of all files start with 'name' in the current directory with current time");
            WriteLine();
            Environment.Exit(0);

        }
    }
}
