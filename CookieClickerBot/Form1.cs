using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CookieClickerBot
{
    public partial class Form1 : Form
    {
        private GlobalHotkey ghk;
        private IntPtr windowHandle;
        private bool startClick;

        Thread clicker;

        public Form1()
        {
            InitializeComponent();
            ghk = new GlobalHotkey(0, Keys.F6, this);
            windowHandle = default;
            startClick = false;
        }

        private void HandleHotkey()
        {
            startClick = !startClick;

            if (startClick)
            {
                if (clicker.ThreadState == 
                    (System.Threading.ThreadState.Background | System.Threading.ThreadState.Unstarted))
                {
                    clicker.Start();
                }
                else
                {
                    clicker.Resume();
                }

                SetText(Constants.LB_RUNNING, Color.Green);
                _Start.Text = Constants.BTN_STOP;
            }
            else
            {
                clicker.Suspend();
                SetText(Constants.LB_STOPPED, Color.Red);
                _Start.Text = Constants.BTN_START;
            }
        }

        private void Click()
        {
            var w = (250 << 16) | 150;

            while (true)
            {
                SendMessage(windowHandle.ToInt32(), 0x201, 0x00000001, w);
                Thread.Sleep(1);
                SendMessage(windowHandle.ToInt32(), 0x202, 0x00000001, w);
                Thread.Sleep(1);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcessesByName("Cookie Clicker"))
            {
                windowHandle = p.MainWindowHandle;
            }

            if (windowHandle == default)
            {
                MessageBox.Show(
                    "This tool requires Cookie Clicker to be opened. " +
                    "\nPlease open the game before running the tool",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            ghk.Register();

            clicker = new Thread(Click);
            clicker.IsBackground = true;

            SetText(Constants.LB_STOPPED, Color.Red);

            // Fix locking when bot is running :)
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghk.Unregiser();
        }

        public void SetText(string text, Color color)
        {
            _StatusText.Text = Constants.LB_STATUS;
            _StatusText.SelectionStart = _StatusText.TextLength;
            _StatusText.SelectionLength = 0;

            _StatusText.SelectionColor = color;
            _StatusText.AppendText(text);
            _StatusText.SelectionColor = _StatusText.ForeColor;
        }

        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);            // second message parameter

        private void _Start_Click(object sender, EventArgs e)
        {
            HandleHotkey();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
