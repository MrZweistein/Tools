using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace iCloudMonitor
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Timers;
    using System.Windows.Forms;
    using Timer = System.Timers.Timer;

    class Program : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string? lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const uint WM_CLOSE = 0x0010;
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        private static string targetWindowTitle = "iCloud"; // CHANGE TO TARGET WINDOW TITLE

        private static Timer? checkTimer;
        private static bool isMonitoring = true;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem toggleItem;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Program());
        }

        public Program()
        {
            // Timer to check for window every 5 seconds
            checkTimer = new Timer(60000);
            checkTimer.Elapsed += CheckForWindow;
            checkTimer.Start();

            toggleItem = new ToolStripMenuItem("Pause", null, ToggleMonitoring);

            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add(toggleItem);
            trayMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                ContextMenuStrip = trayMenu,
                Visible = true,
                Text = "iCloudMonitor",
            };
            trayIcon.MouseUp += TrayIcon_MouseUp;

            // Hide main window
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Load += (s, e) => this.Hide();

            CheckForWindow(null, null);
        }

        private void TrayIcon_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                MethodInfo? mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi?.Invoke(trayIcon, null);
            }
        }


        private void CheckForWindow(object? sender, ElapsedEventArgs? e)
        {
            if (!isMonitoring) return;

            IntPtr hWnd = FindWindow(null, targetWindowTitle);
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_HIDE); // Hide window
            }

        }

        private void ToggleMonitoring(object? sender, EventArgs e)
        {
            isMonitoring = !isMonitoring;
            toggleItem.Text = isMonitoring ? "Pause" : "Resume";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            base.OnFormClosing(e);
        }
    }

}