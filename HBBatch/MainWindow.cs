using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HBBatch
{
    public partial class MainWindow : Form
    {
        private IniFile iniFile;
        private bool[] canEncode = { true, true, true };
        private Thread encodeThread = null;
        private EncodeParam encodeParam;

        public MainWindow()
        {
            InitializeComponent();

            iniFile = new IniFile();

            this.Text = "HBBatch 1.0";
            this.StartPosition = FormStartPosition.CenterScreen;
            btnOpenFileHandbrakeCLI.Click += (s, e) => LocateHandbrakeCLIExecutable();
            btnOpenInputFolder.Click += (s, e) => SelectInputFolder();
            btnOpenOutputFolder.Click += (s, e) => SelectOutputFolder();
            btnExit.Click += (s, e) => { SaveSettings(); iniFile.SaveToDisk(); Application.Exit(); };
            btnCancel.Enabled = false;
            btnSimulate.Enabled = true;

            startAt.Minimum = 0;
            digits.Minimum = 1;
            digits.Maximum = 5;

            pathHandbrakeCLI.Text = iniFile.GetHandbrakeLocation();
            pathInputFolder.Text = iniFile.GetInputFolder();
            searchSubfolders.Checked = iniFile.GetSubfoldersFlag();
            sortInput.Checked = iniFile.GetSortFlag();
            SortInputEnable(sortInput.Checked);
            (iniFile.GetSortOrder() == 0 ? sortByDate : sortByName).Checked = true;
            sortDescending.Checked = iniFile.GetDescendingFlag();
            pathOutputFolder.Text = iniFile.GetOutputFolder();
            renameOutputFiles.Checked = iniFile.GetRenameFlag();
            RenameFilesEnable(renameOutputFiles.Checked);
            prefix.Text = iniFile.GetPrefix();
            startAt.Value = iniFile.GetStartAt();
            digits.Value = iniFile.GetDigits();

            sortInput.CheckedChanged += (s, e) => SortInputEnable(sortInput.Checked);
            renameOutputFiles.CheckedChanged += (s, e) => RenameFilesEnable(renameOutputFiles.Checked);

            pathHandbrakeCLI.TextChanged += (s, e) => ValidateSetting(s);
            pathInputFolder.TextChanged += (s, e) => ValidateSetting(s);
            pathOutputFolder.TextChanged += (s, e) => ValidateSetting(s);

            ValidateSetting(pathHandbrakeCLI);
            ValidateSetting(pathInputFolder);
            ValidateSetting(pathOutputFolder);

            btnEncode.Click += (s, e) => StartEncode();
            btnCancel.Click += (s, e) => encodeThread?.Abort();
            progressBar.Visible = false;
            Log.Visible = false;
            EncodeWorker.Progress += EncodeWorker_Progress;

        }

        private bool ValidateSetting(object sender)
        {
            bool result = false;
            if (sender == pathHandbrakeCLI)
            {
                result = File.Exists(pathHandbrakeCLI.Text);
                label1.ForeColor = result ? Color.Black : Color.Red;
                canEncode[0] = result;
            }
            else if (sender == pathInputFolder)
            {
                result = Directory.Exists(pathInputFolder.Text);
                label2.ForeColor = result ? Color.Black : Color.Red;
                canEncode[1] = result;
            }
            else if (sender == pathOutputFolder)
            {
                result = Directory.Exists(pathOutputFolder.Text);
                label3.ForeColor = result ? Color.Black : Color.Red;
                canEncode[2] = result;
            }
            btnEncode.Enabled = !canEncode.Contains(false);
            return result;
        }

        private void SaveSettings()
        {
            iniFile.SetHandbrakeLocation(pathHandbrakeCLI.Text);
            iniFile.SetInputFolder(pathInputFolder.Text);
            iniFile.SetSubfoldersFlag(searchSubfolders.Checked);
            iniFile.SetSortFlag(sortInput.Checked);
            iniFile.SetSortOrder(sortByDate.Checked ? 0 : 1);
            iniFile.SetDescendingFlag(sortDescending.Checked);
            iniFile.SetOutputFolder(pathOutputFolder.Text);
            iniFile.SetRenameFlag(renameOutputFiles.Checked);
            iniFile.SetPrefix(prefix.Text);
            iniFile.SetStartAt((int)startAt.Value);
            iniFile.SetDigits((int)digits.Value);
        }

        private void SortInputEnable(bool enable)
        {
            groupSort.Enabled = enable;
        }

        private void RenameFilesEnable(bool enable)
        {
            groupFilename.Enabled = enable;
        }

        private string SelectFolder(string desc, bool folderButton, string path)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = desc;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.ShowNewFolderButton = folderButton;
                if (!string.IsNullOrWhiteSpace(path))
                {
                    if (Directory.Exists(path)) dialog.SelectedPath = path;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
            }
            return path;
        }

        private void SelectOutputFolder()
        {
            pathOutputFolder.Text = SelectFolder("Select Output Folder", true, pathOutputFolder.Text);
            ValidateSetting(pathOutputFolder);
        }

        private void SelectInputFolder()
        {
            pathInputFolder.Text = SelectFolder("Select Input Folder", false, pathInputFolder.Text);
            ValidateSetting(pathInputFolder);
        }

        private void LocateHandbrakeCLIExecutable()
        {
            pathHandbrakeCLI.Text = Path.Combine(SelectFolder("Select HandbrakeCLI Folder", false, Path.GetDirectoryName(pathHandbrakeCLI.Text)), "HandBrakeCLI.exe");
            ValidateSetting(pathHandbrakeCLI);
        }

        //private void CancelEncode()
        //{
        //    if (handbrakeProcess != null)
        //    {
        //        if (!handbrakeProcess.HasExited)
        //        {
        //            handbrakeProcess.CancelOutputRead();
        //            handbrakeProcess.Kill();
        //            handbrakeProcess.Close();
        //            handbrakeProcess = null;
        //        }
        //    }
        //}


        private void StartEncode()
        {
            encodeThread = new Thread(EncodeWorker.EncodeThread);
            encodeParam = new EncodeParam()
            {
                HandbrakeCLIExe = pathHandbrakeCLI.Text,
                InputFolder = pathInputFolder.Text,
                Recursive = searchSubfolders.Checked,
                Sort = sortInput.Checked,
                OrderByDate = sortByDate.Checked,
                OrderDescending = sortDescending.Checked,
                FilePattern = "*.mkv",
                OutputFolder = pathOutputFolder.Text,
                RenameFiles = renameOutputFiles.Checked,
                FilePrefix = prefix.Text,
                StartAt = (int)startAt.Value,
                Digits = (int)digits.Value
            };
            encodeThread.Start(encodeParam);
        }

        private void EncodeWorker_Progress(object sender, MyProgressEventArgs e)
        {
            switch (e.Status)
            {
                case Status.Setup:
                    Action Setup = () =>
                    {
                        btnEncode.Enabled = false;
                        btnCancel.Enabled = true;
                        btnExit.Enabled = false;
                        progressBar.Maximum = e.FilesCount;
                        progressBar.Value = 0;
                        progressBar.Visible = true;
                        Log.Visible = true;
                    };
                    Invoke(new MethodInvoker(Setup));
                    break;
                case Status.Update:
                    Action Update = () =>
                    {
                        progressBar.Value = e.Current;
                        Log.Text = "Preparing ...";
                    };
                    Invoke(new MethodInvoker(Update));
                    break;
                case Status.Progress:

                    string filter = @".*(\b\d?\d[.]\d\d\x20\x25)";
                    Regex regExp = new Regex(filter);
                    Match match = regExp.Match(e.ExeOutput);
                    if (match.Success)
                    {
                        string input = Path.GetFileName(e.InputFile);
                        string output = Path.GetFileName(e.OutputFile);
                        Action Progress = () =>
                        {
                            Log.Text = $"[{e.Current}/{e.FilesCount}] Encoding '{input}' -> '{output}' {match.Groups[1].Value}";
                        };
                        Invoke(new MethodInvoker(Progress));
                    }
                    break;
                case Status.Finalized:
                    Action Finalized = () =>
                    {
                        btnEncode.Enabled = true;
                        btnCancel.Enabled = false;
                        btnExit.Enabled = true;
                        progressBar.Visible = false;
                        Log.Visible = false;
                    };
                    Invoke(new MethodInvoker(Finalized));
                    break;
                case Status.Failed:
                    break;
                case Status.Aborted:
                    Action Aborted = () =>
                    {
                        btnEncode.Enabled = true;
                        btnCancel.Enabled = false;
                        btnExit.Enabled = true;
                        progressBar.Visible = false;
                        Log.Visible = false;
                    };
                    Invoke(new MethodInvoker(Aborted));
                    break;
                default:
                    break;
            }

        }
    }
}
