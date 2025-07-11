using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Automation;

namespace iCloudMonitor
{
    class Program : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;

        private static string targetWindowTitle = "iCloud"; // CHANGE TO TARGET WINDOW TITLE
        private static string pauseText = "Pause";
        private static string resumeText = "Resume";
        private static string autostartText = "Auto Start";

        private static bool isMonitoring = true;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem toggleItem;
        private ToolStripMenuItem autoStartItem;
        private AutomationEventHandler windowOpenedHandler;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash screen
            using (var splash = new SplashWin())
            {
                splash.Show();
                Application.DoEvents(); // Ensure it renders
                System.Threading.Thread.Sleep(3000); // Wait 2 seconds
            }

            Application.Run(new Program());
        }

        public Program()
        {
            toggleItem = new ToolStripMenuItem(pauseText, null, ToggleMonitoring);
            autoStartItem = new ToolStripMenuItem(autostartText, null, ToggleAutostart);

            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add(toggleItem);
            trayMenu.Items.Add(autoStartItem);
            trayMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            trayIcon = new NotifyIcon
            {
                Icon = Properties.Resources.MyAppIcon,
                ContextMenuStrip = trayMenu,
                Visible = true,
                Text = "iCloudMonitor",
            };
            trayIcon.MouseUp += TrayIcon_MouseUp;

            // Hide main window
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Load += (s, e) => this.Hide();

            // Hook window opened events
            windowOpenedHandler = new AutomationEventHandler(OnWindowOpened);
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowOpenedEvent,
                AutomationElement.RootElement,
                TreeScope.Subtree,
                windowOpenedHandler
            );

            SetAutostartMenuItem();
            InitialCheck();
        }

        private void ToggleAutostart(object? sender, EventArgs e)
        {
            bool isOn = StartupManager.IsAutoStartEnabled();
            if (isOn)
            {
                StartupManager.DisableAutoStart();
            }
            else
            {
                StartupManager.EnableAutoStart();
            }
            SetAutostartMenuItem();

        }

        private void SetAutostartMenuItem()
        {
            autoStartItem.Checked = StartupManager.IsAutoStartEnabled();
        }

        private void OnWindowOpened(object sender, AutomationEventArgs e)
        {
            if (!isMonitoring) return;

            var element = sender as AutomationElement;
            if (element == null) return;

            string name = element.Current.Name;
            if (name == targetWindowTitle)
            {
                IntPtr hWnd = new IntPtr(element.Current.NativeWindowHandle);
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, SW_HIDE); // 💨 Hide the window
                }
            }
        }

        private void InitialCheck()
        {
            if (!isMonitoring) return;

            IntPtr hWnd = FindWindow(null, targetWindowTitle);
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_HIDE); // Hide window
            }
        }

        private void TrayIcon_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                MethodInfo? mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi?.Invoke(trayIcon, null);
            }
        }

        private void ToggleMonitoring(object? sender, EventArgs e)
        {
            isMonitoring = !isMonitoring;
            toggleItem.Text = isMonitoring ? pauseText : resumeText;
            InitialCheck();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            base.OnFormClosing(e);
        }
    }

}