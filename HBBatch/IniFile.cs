using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IniParser.Model;
using IniParser.Parser;

namespace HBBatch
{
    /// <summary>
    /// Class to handle Ini File Access and manipulation
    /// </summary>
    internal class IniFile
    {
        public string IniFileName { get; set; }

        private IniDataParser Parser { get; } = null;
        private IniData Data { get; set; } = null;

        public IniFile()
        {
            Parser = new IniDataParser();
            IniFileName = Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".ini");
            if (!File.Exists(IniFileName))
            {
                ResetIni();
                SaveToDisk();
            }
            else
            {
                try
                {
                    using (FileStream fs = File.Open(IniFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.ASCII))
                        {
                            Data = Parser.Parse(sr.ReadToEnd());
                        }
                    }
                }
                catch (IniParser.Exceptions.ParsingException)
                {
                    ResetIni();
                    SaveToDisk();
                }
            }
        }

        private void ResetIni()
        {
            SectionData section;
            Data = Parser.Parse("");
            Data.Sections.AddSection("Application");
            section = Data.Sections.GetSectionData("Application");
            section.Keys.AddKey("position", "");
            Data.Sections.AddSection("Handbrake");
            section = Data.Sections.GetSectionData("Handbrake");
            section.Keys.AddKey("location", @"c:\Program Files\Handbrake\HandbrakeCLI.exe");
            Data.Sections.AddSection("Input");
            section = Data.Sections.GetSectionData("Input");
            section.Keys.AddKey("inputfolder", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            section.Keys.AddKey("subfolders", bool.FalseString);
            section.Keys.AddKey("sort", bool.FalseString);
            section.Keys.AddKey("order", "0");
            section.Keys.AddKey("descending", bool.FalseString);
            Data.Sections.AddSection("Output");
            section = Data.Sections.GetSectionData("Output");
            section.Keys.AddKey("outputfolder", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            section.Keys.AddKey("rename", bool.FalseString);
            section.Keys.AddKey("prefix", "video");
            section.Keys.AddKey("startat", "1");
            section.Keys.AddKey("digits", "2");
        }

        private bool GetBool(string asection, string akey)
        {
            string value = Data[asection][akey];
            return value == "True";
        }

        private int GetNumber(string asection, string akey)
        {
            string value = Data[asection][akey];
            return int.TryParse(value, out int result) ? result : 0;
        }

        private void SetBool(string asection, string akey, bool value)
        {
            Data[asection][akey] = value.ToString();
        }

        private void SetNumber(string asection, string akey, int value)
        {
            Data[asection][akey] = value.ToString();
        }

        public void SaveToDisk()
        {
            if (File.Exists(IniFileName)) File.Delete(IniFileName);
            using (FileStream fs = File.Open(IniFileName, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.ASCII))
                {
                    writer.Write(Data.ToString());
                }
            }
        }

        public string GetWinPos() => Data["Application"]["position"];
        public string GetHandbrakeLocation() => Data["Handbrake"]["location"];
        public string GetInputFolder() => Data["Input"]["inputfolder"];
        public bool GetSubfoldersFlag() => GetBool("Input", "subfolders");
        public bool GetSortFlag() => GetBool("Input", "sort");
        public int GetSortOrder() => GetNumber("Input", "order");
        public bool GetDescendingFlag() => GetBool("Input", "descending");
        public string GetOutputFolder() => Data["Output"]["outputfolder"];
        public bool GetRenameFlag() => GetBool("Output", "rename");
        public string GetPrefix() => Data["Output"]["prefix"];
        public int GetStartAt() => GetNumber("Output", "startat");
        public int GetDigits() => GetNumber("Output", "digits");
        public void SetWinPos(string position) => Data["Application"]["position"] = position;
        public void SetHandbrakeLocation(string location) => Data["Handbrake"]["location"] = location;
        public void SetInputFolder(string folder) => Data["Input"]["inputfolder"] = folder;
        public void SetSubfoldersFlag(bool flag) => SetBool("Input", "subfolders", flag);
        public void SetSortFlag(bool flag) => SetBool("Input", "sort", flag);
        public void SetDescendingFlag(bool flag) => SetBool("Input", "descending", flag);
        public void SetSortOrder(int order) => SetNumber("Input", "order", order);
        public void SetOutputFolder(string folder) => Data["Output"]["outputfolder"] = folder;
        public void SetRenameFlag(bool flag) => SetBool("Output", "rename", flag);
        public void SetPrefix(string prefix) => Data["Output"]["prefix"] = prefix;
        public void SetStartAt(int startat) => SetNumber("Output", "startat", startat);
        public void SetDigits(int digits) => SetNumber("Output", "digits", digits);
    }
}
