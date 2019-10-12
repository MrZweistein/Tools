using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBatch
{
    internal struct EncodeParam
    {
        public string HandbrakeCLIExe;
        public string InputFolder;
        public bool   Recursive;
        public string FilePattern;
        public bool   Sort;
        public bool   OrderByDate;
        public bool   OrderDescending;
        public string OutputFolder;
        public bool   RenameFiles;
        public string FilePrefix;
        public int    StartAt;
        public int    Digits;
    }

}
