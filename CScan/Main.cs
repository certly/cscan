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

        public Main()
        {
            InitializeComponent();

            config = new Config(false);

            Process.EnterDebugMode();
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            MessageBox.Show(name + " is distributed by Certly Inc under the Apache 2.0 license (the \"License\")." +
                            Environment.NewLine + Environment.NewLine +
                            "Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an \"AS IS\" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.",
                "CScan License");
        }

        private void Scan_Click(object sender, EventArgs e)
        {
            DisableButtons();
            statusText.Text = "";

            config.EnableJson = enableJson.Checked;

            var scanner = new Scanner();
            scanner.Scan(ref statusText, config);

            EnableButtons();
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
    }
}