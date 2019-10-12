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
        static MyProgressEventArgs args = new MyProgressEventArgs();

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
                                Exe.WaitForExit(2000);
                            }
                            DateTime ended = DateTime.Now;
                            TimeSpan span = ended.Subtract(started);
                            string duration = $"{span.Hours}h{span.Minutes}m{span.Seconds}s";

                            if (Exe.ExitCode != 0)
                            {
                                //FailedMessage();
                            }
                            else
                            {
                                //Log($"{processingPrefix} Done in {duration}");
                            }
                        }
                        Exe = null;
                    }
                    catch (ThreadAbortException ex)
                    {
                        args.Status = Status.Aborted;
                        if (Exe != null)
                        {
                            //Exe.CancelOutputRead();
                            Exe.Kill();
                            Exe.Close();
                            Exe = null;
                        }
                        OnProgress(args);
                        throw ex;
                    }
                    catch (IOException)
                    {
                        //FailedMessage();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        //FailedMessage();
                    }
                    catch (Exception)
                    {
                        //FailedMessage();
                    }
                    c++;
                    args.Current++;
                }
                TimeSpan ospan = DateTime.Now.Subtract(startedEncoding);
                string oduration = $"{ospan.Hours}h{ospan.Minutes}m{ospan.Seconds}s";
                //Log($"Processed {files.Count()} file(s) with {e} error(s). Processing time: {oduration}");
                args.Status = Status.Finalized;
                OnProgress(args);
            }
            catch (ThreadAbortException)
            {
                
            }
            catch (UnauthorizedAccessException)
            {
                SendErrorMsg("Accessing directory: unauthorized access.");
                //ExitWithError("Accessing directory: unauthorized access.", 200);
            }
            catch (PathTooLongException)
            {
                SendErrorMsg("Accessing files: Path too long");
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
