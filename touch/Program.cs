﻿/************************************************************************************************************/
/*                                                                                                          */
/*  Touch Clone Version 1.0                                                                                 */
/*  Entwickelt durch Roger Spiess, Hamburg,  2018                                                           */
/*  Alle Rechte vorbehalten                                                                                 */
/*                                                                                                          */
/*  Version Historie:                                                                                       */
/*  04-11-2018 Version 1.0                                                                                  */
/*  07-11-2018 Version 1.1 -R option (file reference) Überarbeitung Optionen + Bugfixes                     */
/*                                                                                                          */
/************************************************************************************************************/
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
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
        static bool fileRefOption = false;
        static bool touchDirOption = false;

        static string workingDirectory = default(string);
        static string filePattern = default(string);
        static string dateString = default(string);
        static string timeString = default(string);
        static string fileReference = default(string);
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
                string[] formats = { "dd-MM-yyyy HH:mm:ss" };
                string[] files = Directory.GetFiles(workingDirectory, filePattern, recursiveOption ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                if (touchDirOption)
                {
                    string[] dirs = Directory.GetDirectories(workingDirectory , "*", SearchOption.AllDirectories);
                    List<string> consolidated = new List<string>(dirs);
                    consolidated.AddRange(files);
                    files = consolidated.ToArray();
                }
                int i = 0;
                int e = 0;
                foreach (string filename in files)
                {
                    try
                    {
                        Log($"[{++i}] Processing '{filename}'...", false);
                        DateTime current = Directory.GetLastWriteTime(filename);
                        string currDate = datetime.ToString("dd-MM-yyyy");
                        string currTime = datetime.ToString("HH:mm:ss");
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
                ExitWithError("Accessing directory: unauthorized access.", 200);
            }
            catch (PathTooLongException)
            {
                ExitWithError("Accessing files: path too long", 201);
            }

        }

        static bool MemberOf<T>(T compare, params T[] members)
        {
            return members.Contains<T>(compare);
        }

        static void Parse(string[] args)
        {
            Log("mytouch.exe Version 1.1 (C) 2018 Roger Spiess");
            if (args.Count() == 0)
            {
                ExitWithHelp();
            }
            List<string> _args = new List<string>();
            foreach(string elem in args)
            {
                _args.AddRange(elem.Split('"', ' '));
            }
            _args = _args.Where((e) => e != "").ToList();
            string options = "-w,-r,-rD,-f,-a,-d,-date,-t,-time,-now,-F,-v,-?";
            var culture = new System.Globalization.CultureInfo("de-DE");
            for (int i = 0; i < _args.Count(); i++)
            {
                bool Inc() => ++i < _args.Count();
                string option = _args[i];
                if (option == "-w")
                {
                    if (directoryOption)
                    {
                        ExitWithError("-d option: Option already exists", 100);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-d option: Missing directory", 101);
                        }
                        directoryOption = true;
                        workingDirectory = nextItem.Trim('"');
                        if (!Directory.Exists(workingDirectory))
                        {
                            ExitWithError($"-d option: Directory '{workingDirectory}' doesn't exist.", 102);
                        }
                    }
                    else
                    {
                        ExitWithError("-d option: Missing directory", 103);
                    }
                }
                else if (option == "-r")
                {
                    if (recursiveOption | touchDirOption)
                    {
                        ExitWithError("-r option: Option already exists", 104);
                    }
                    recursiveOption = true;
                }
                else if (option == "-rD")
                {
                    if (touchDirOption | recursiveOption)
                    {
                        ExitWithError("-rD option: Option already exists", 105);
                    }
                    touchDirOption = true;
                    recursiveOption = true;
                }
                else if (option == "-F")
                {
                    if (fileRefOption)
                    {
                        ExitWithError("-R option: Option already exists", 106);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-R option: Missing filename", 107);
                        }
                        fileRefOption = true;
                        fileReference = nextItem;
                    }
                    else
                    {
                        ExitWithError("-R option: Missing filename", 108);
                    }
                }
                else if (option == "-f")
                {
                    if (filepatternOption)
                    {
                        ExitWithError("-f option: Option already exists", 109);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-f option: Missing filename or filename pattern", 110);
                        }
                        filepatternOption = true;
                        filePattern = nextItem;
                    }
                    else
                    {
                        ExitWithError("-f option: Missing filename or filename pattern", 111);
                    }
                }
                else if (option == "-a")
                {
                    if (allOption)
                    {
                        ExitWithError("-a option: Option already exists", 112);
                    }
                    allOption = true;
                }
                else if (option == "-date" || option == "-d")
                {
                    if (dateOption)
                    {
                        ExitWithError("-date option: Option already exists", 113);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-date option: Missing date", 114);
                        }
                        dateOption = true;
                        string rp = "[0-9]{2}[-][0-9]{2}[-][0-9]{4}";
                        if (!Regex.IsMatch(nextItem, rp))
                        {
                            ExitWithError($"-date option: '{nextItem}' doesn't match the required pattern 'dd-mm-yyyy'", 115);
                        }
                        dateString = nextItem;
                        if (!DateTime.TryParseExact(dateString, "dd-MM-yyyy", culture, System.Globalization.DateTimeStyles.None, out var test))
                        {
                            ExitWithError($"-date option: '{nextItem} is not a correct date", 116);
                        }
                    }
                    else
                    {
                        ExitWithError("-date option: Missing date", 117);
                    }
                }
                else if (option == "-time" || option == "-t")
                {
                    if (timeOption)
                    {
                        ExitWithError("-time option: Option already exists", 118);
                    }
                    if (Inc())
                    {
                        string nextItem = _args[i];
                        if (MemberOf(nextItem, options.Split(',')))
                        {
                            ExitWithError("-time option: Missing time", 119);
                        }
                        timeOption = true;
                        string rp = "[0-9]{2}[/:][0-9]{2}[/:][0-9]{2}";
                        if (!Regex.IsMatch(nextItem, rp))
                        {
                            ExitWithError($"-time: '{nextItem}' doesn't match the required pattern 'hh:mm:ss'", 120);
                        }
                        timeString = nextItem;
                        if (!DateTime.TryParseExact(timeString, "HH:mm:ss", culture, System.Globalization.DateTimeStyles.None, out var test))
                        {
                            ExitWithError($"-time option: '{nextItem} is not a correct time", 121);
                        }
                    }
                    else
                    {
                        ExitWithError("-time option: Missing time", 122);
                    }
                }
                else if (option == "-now")
                {
                    if (nowOption)
                    {
                        ExitWithError("-now option: Option already exists", 123);
                    }
                    nowOption = true;

                }
                else if (option == "-v")
                {
                    if (verboseOption)
                    {
                        ExitWithError("-v option: Option already exists", 124);
                    }
                    verboseOption = true;
                }
                else if (option == "-?")
                {
                    ExitWithHelp();
                }
                else 
                {
                    ExitWithError($"Unknown option: {option}", 10, true);
                    ExitWithHelp();
                }
            }
            if (!directoryOption)
            {
                workingDirectory = Directory.GetCurrentDirectory();
            }
            if (fileRefOption)
            {
                string file = fileReference;
                try
                {
                    if (!File.Exists(file))
                    {
                        ExitWithError($"-R option: Cannot find file '{file}'", 125);
                    }
                }
                catch (Exception)
                {
                    ExitWithError($"-R option: Incorrent File '{file}'", 126);
                }
                dateOption = true;
                timeOption = true;
                DateTime fileDT = File.GetLastWriteTime(file);
                dateString = fileDT.ToString("dd-MM-yyyy");
                timeString = fileDT.ToString("HH:mm:ss");

            }
            nowOption = !(dateOption | timeOption | fileRefOption);
            if (nowOption)
            {
                dateOption = true;
                timeOption = true;
                dateString = datetime.ToString("dd-MM-yyyy");
                timeString = datetime.ToString("HH:mm:ss");
            }
            allOption = !(filepatternOption);
            if (allOption)
            {
                filePattern = "*.*";
            }
            Log($"Start processing using options: {string.Join(" ", _args)}");
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
            WriteLine("Options:");
            WriteLine("   -w <directory>     => work with files in <directory>");
            WriteLine("   -r[D]              => include subdirectories recursively. Combined with D subdirectories will be touched too");
            WriteLine("   -f <filepattern>   => touch files with <filepattern>. Use '*' and '?' for pattern");
            WriteLine("   -F filename        => use file as date/time reference. overwrites -now -date -time");
            WriteLine("   -a                 => Standard option. touch all files in the directory. Gets ignored if -f option is used");
            WriteLine("   -d[ate] <date>     => use <date> for touch. format of <date> is 'dd-mm-yyyy'");
            WriteLine("   -t[ime] <time>     => use <time> for touch. format of <time> is 'hh:mm:ss");
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
