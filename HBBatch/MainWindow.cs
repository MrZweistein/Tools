using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HBBatch
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Text = "HBBatch 1.0";
            this.StartPosition = FormStartPosition.CenterScreen;
            btnOpenFileHandbrakeCLI.Click += LocateHandbrakeCLUExecutable;
            btnOpenInputFolder.Click += SelectInputFolder;
            btnOpenOutputFolder.Click += SelectOutputFolder;
            btnExit.Click += (s, e) => Application.Exit();
            btnCancel.Enabled = false;
            btnSimulate.Enabled = false;
        }

        private void SelectOutputFolder(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Output Folder";
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.ShowNewFolderButton = true;
                if (!string.IsNullOrWhiteSpace(pathOutputFolder.Text))
                {
                    dialog.SelectedPath = pathOutputFolder.Text;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathOutputFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void SelectInputFolder(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Input Folder";
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (!string.IsNullOrWhiteSpace(pathInputFolder.Text))
                {
                    dialog.SelectedPath = pathInputFolder.Text;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathInputFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void LocateHandbrakeCLUExecutable(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.DefaultExt = ".exe";
                dialog.Title = "Locate HandbrakeCLI.exe";
                dialog.FileName = "HandbrakeCLI.exe";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathHandbrakeCLI.Text = dialog.FileName;
                }
            }
        }
    }
}
