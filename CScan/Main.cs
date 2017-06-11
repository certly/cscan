using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CScan
{
    public partial class Main : Form
    {
        public const string name = "CScan";

        public const string version = "1.0.0-dev";

        private Config config;
        private ElevationHelper elevator = new ElevationHelper();

        public Main()
        {
            InitializeComponent();

            config = new Config(false);

            Process.EnterDebugMode();
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            this.elevateToNTAUTHORITYToolStripMenuItem.Enabled = elevator.isMaster || elevator.isDeadlocked;

            if (Environment.GetCommandLineArgs().Length < 2)
            {
                MessageBox.Show(name + " is distributed by Certly Inc under the Apache 2.0 license (the \"License\")." +
                                Environment.NewLine + Environment.NewLine +
                                "Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an \"AS IS\" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.",
                    "CScan License");
            }
        }

        private void Scan_Click(object sender, EventArgs e)
        {
            DisableButtons();
            statusText.Text = "";

            config.EnableJson = enableJson.Checked;

            var scanner = new Scanner();
            scanner.StatusChanged += Scanner_StatusChanged; // Subscribe the Scanner StatusChanged event so we are notified

            // We have two options. Create a thread, or use the new(ish) Action and delegates.
            // This bascially spawns a thread, which frees up the UI thread.
            // Locking the UI causes the freezing (not responding).

            Action scanAction = new Action(() => { scanner.Scan(config); });
            scanAction.BeginInvoke(new AsyncCallback(result5 =>
            { (result5.AsyncState as Action).EndInvoke(result5); }), scanAction);
        }

        private void Scanner_StatusChanged(object sender, EventArgs e)
        {
            // Tell the UI thread to update the textbox
            this.Invoke(new MethodInvoker(delegate
            { this.statusText.Text += sender.ToString(); }));

            // Hand controls back to user when we're finished
            if (sender.ToString().ToLower().Contains("success"))
            {
                this.Invoke(new MethodInvoker(delegate
                { EnableButtons(); }));
            }
        }

        private void Fix_Click(object sender, EventArgs e)
        {
            DisableButtons();
            statusText.Text = "";

            var fixer = new Fixer();
            string path;

            try
            {
                path = fixer.Fix(ref statusText);
            }
            catch (InvalidDataException)
            {
                EnableButtons();

                return;
            }

            Process.Start("notepad", path);

            EnableButtons();
        }

        private void allowUnsafeOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!allowUnsafeOperationsToolStripMenuItem.Checked)
            {
                var result = MessageBox.Show(
                    "Allowing unsafe operations may cause serious damage. Do not enable this unless explicitly instructed to."
                    + Environment.NewLine + Environment.NewLine + "Are you sure you wish to enable unsafe operations?",
                    "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;
            }

            allowUnsafeOperationsToolStripMenuItem.Checked = !allowUnsafeOperationsToolStripMenuItem.Checked;
        }

        private void DisableButtons()
        {
            Fix.Enabled = false;
            Scan.Enabled = false;
        }

        private void EnableButtons()
        {
            Fix.Enabled = true;
            Scan.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void enableFileEnumerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableFileEnumerationToolStripMenuItem.Checked = !enableFileEnumerationToolStripMenuItem.Checked;
            config.EnableFiles = enableFileEnumerationToolStripMenuItem.Checked;
        }

        private void elevateToNTAUTHORITYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (elevator.isDeadlocked)
            {
                MessageBox.Show("CScan is unable to elevate itself. This is likely because another instance of CScan is open; please close all CScan instances, including this one, and try again.", "CScan Deadlock Error");
            }

            if (elevator.isMaster)
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                elevator.Elevate();
            }
        }
    }
}