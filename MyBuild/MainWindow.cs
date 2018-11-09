using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBuild
{
    internal partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            ControlBox = true;
            MinimizeBox = false;
            MaximizeBox = false;
            ShowIcon = true;
            ShowInTaskbar = true;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;

        }
    }
}
