using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HBBatch
{
    internal class EncodeWorker
    {
        static readonly MyProgressEventArgs args = new MyProgressEventArgs();

        static public event EventHandler<MyProgressEventArgs> Progress;

        static protected void OnProgress(MyProgressEventArgs e)
        {
            Progress?.Invoke(null, e);
        }

        static public void EncodeThread(object data)
        {
            if (data == null) return;

            Process Exe = null;
            EncodeParam d = (EncodeParam)data;

            try
            {
                DateTime startedEncoding = DateTime.Now;

                string[] files = Directory.GetFiles(d.InputFolder, d.FilePattern, d.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                int c = d.StartAt;
                args.FilesCount = files.Length;
                args.Current = 1;
                args.Status = Status.Setup;
                OnProgress(args);

                // Sort files if asked for (uses full file path)
                if (d.Sort)
                {
                    if (d.OrderByDate)
                    {
                        if (!d.OrderDescending)
                        {
                            files = files.OrderBy(q => File.GetCreationTime(q).ToString()).ToArray();
                        }
                        else
                        {
                            files = files.OrderByDescending(q => File.GetCreationTime(q).ToString()).ToArray();
                        }
                    }
                    else
                    {
                        if (!d.OrderDescending)
                        {
                            files = files.OrderBy(q => q).ToArray();
                        }
                        else
                        {
                            files = files.OrderByDescending(q => q).ToArray();
                        }
                    }
                }

                foreach (string filepath in files)
                {
                    string outputfile;
                    string inputfile = Path.GetFileName(filepath);
                    if (d.RenameFiles)
                    {
                        string fmt = new string('0', d.Digits);
                        outputfile = Path.Combine(d.OutputFolder, d.FilePrefix + c.ToString(fmt) + ".m4v");
                    }
                    else
                    {
                        outputfile = Path.Combine(d.OutputFolder, Path.ChangeExtension(inputfile, ".m4v"));
                    }
                    try
                    {
                        string executable = d.HandbrakeCLIExe;
                        string arguments = "";
                        arguments += $@"--preset ""Fast 1080p30"" ";
                        arguments += $@"-i ""{filepath}"" ";
                        arguments += $@"-o ""{outputfile}"" ";
                        arguments += $@"--markers ";
                        arguments += $@"--align-av ";

                        args.InputFile = filepath;
                        args.OutputFile = outputfile;
                        args.Status = Status.Update;
                        OnProgress(args);

                        DateTime started = DateTime.Now;

                        // Setup the process environment and call process
                        using (Exe = new Process())
                        {
                            Exe.StartInfo.FileName = executable;
                            Exe.StartInfo.Arguments = arguments;
                            Exe.StartInfo.CreateNoWindow = true;
                            Exe.StartInfo.UseShellExecute = false;
                            Exe.StartInfo.RedirectStandardOutput = true;
                            Exe.StartInfo.RedirectStandardInput = false;
                            Exe.EnableRaisingEvents = true;
                            Exe.OutputDataReceived += ProcessDataReceived;
                            Exe.Start();
                            Exe.BeginOutputReadLine();
                            while (!Exe.HasExited)
                            {
                                try
                                {
                                    Exe.WaitForExit(2000);
                                }
                                catch (ThreadAbortException)
                                {
                                    args.Status = Status.Aborted;
                                    OnProgress(args);
                                    if (Exe != null)
                                    {
                                        Exe.CancelOutputRead();
                                        Exe.Kill();
                                        Exe.Close();
                                        Exe = null;
                                    }
                                    return;
                                }
                            }
                            DateTime ended = DateTime.Now;
                            TimeSpan span = ended.Subtract(started);
                            string duration = $"{span.Hours}h{span.Minutes}m{span.Seconds}s";

                            if (Exe.ExitCode != 0)
                            {
                                //FailedMessage();
                            }
                        }
                        Exe = null;
                    }
                    catch (ThreadAbortException)
                    {
                       throw;
                    }
                    catch
                    {
                        //FailedMessage();
                    }
                    c++;
                    args.Current++;
                }
                args.Status = Status.Finalized;
                TimeSpan ospan = DateTime.Now.Subtract(startedEncoding);
                args.Misc = $"{ospan.Hours:00}h{ospan.Minutes:00}m{ospan.Seconds:00}s";
                OnProgress(args);
            }
            catch (ThreadAbortException)
            {
                args.Status = Status.Aborted;
                OnProgress(args);
            }
            catch
            {
                SendErrorMsg("Accessing directory: unauthorized access.");
                //ExitWithError("Accessing directory: unauthorized access.", 200);
            }
        }

        static private void SendErrorMsg(string error)
        {
            args.Status = Status.Failed;
            args.Misc = error;
            OnProgress(args);
        }

        static private void ProcessDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                args.Status = Status.Progress;
                args.ExeOutput = e.Data;
                OnProgress(args);
            }
        }

    }
}
