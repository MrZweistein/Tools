using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBatch
{
    internal class MyProgressEventArgs : EventArgs
    {
        public Status     Status  { get; set; }
        public int        FilesCount { get; set; }
        public int        Current    { get; set; }
        public string     InputFile  { get; set; }
        public string     OutputFile { get; set; }
        public string     ExeOutput  { get; set; }
        public int        Error      { get; set; }
        public string     Misc       { get; set; }
    }

    internal enum Status
    {
        Setup,
        Update,
        Progress,
        Finalized,
        Failed,
        Aborted,
        CriticalError
    }
}
