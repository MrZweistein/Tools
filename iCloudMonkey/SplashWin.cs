using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCloudMonkey
{
    public partial class SplashWin : Form
    {
        public SplashWin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            //pictureBox1.Image = Properties.Resources.MySplashIcon;
            //pictureBox1.Height = 256;
            //pictureBox1.Width= 256;
        }
    }
}
