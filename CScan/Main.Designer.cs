namespace CScan
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Scan = new System.Windows.Forms.Button();
            this.Fix = new System.Windows.Forms.Button();
            this.statusText = new System.Windows.Forms.RichTextBox();
            this.enableJson = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableFileEnumerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowUnsafeOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scan
            // 
            this.Scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Scan.Location = new System.Drawing.Point(12, 24);
            this.Scan.Name = "Scan";
            this.Scan.Size = new System.Drawing.Size(150, 50);
            this.Scan.TabIndex = 0;
            this.Scan.Text = "Scan";
            this.Scan.UseVisualStyleBackColor = true;
            this.Scan.Click += new System.EventHandler(this.Scan_Click);
            // 
            // Fix
            // 
            this.Fix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Fix.Location = new System.Drawing.Point(12, 80);
            this.Fix.Name = "Fix";
            this.Fix.Size = new System.Drawing.Size(150, 50);
            this.Fix.TabIndex = 1;
            this.Fix.Text = "Fix";
            this.Fix.UseVisualStyleBackColor = true;
            this.Fix.Click += new System.EventHandler(this.Fix_Click);
            // 
            // statusText
            // 
            this.statusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusText.DetectUrls = false;
            this.statusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusText.HideSelection = false;
            this.statusText.Location = new System.Drawing.Point(1, 1);
            this.statusText.Name = "statusText";
            this.statusText.ReadOnly = true;
            this.statusText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.statusText.Size = new System.Drawing.Size(402, 223);
            this.statusText.TabIndex = 4;
            this.statusText.Text = "";
            // 
            // enableJson
            // 
            this.enableJson.AutoSize = true;
            this.enableJson.Location = new System.Drawing.Point(12, 135);
            this.enableJson.Margin = new System.Windows.Forms.Padding(2);
            this.enableJson.Name = "enableJson";
            this.enableJson.Size = new System.Drawing.Size(125, 17);
            this.enableJson.TabIndex = 5;
            this.enableJson.Text = "Enable JSON Output";
            this.enableJson.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scanToolStripMenuItem,
            this.advancedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableFileEnumerationToolStripMenuItem});
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.scanToolStripMenuItem.Text = "Scan";
            // 
            // enableFileEnumerationToolStripMenuItem
            // 
            this.enableFileEnumerationToolStripMenuItem.Name = "enableFileEnumerationToolStripMenuItem";
            this.enableFileEnumerationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.enableFileEnumerationToolStripMenuItem.Text = "Enable File Enumeration";
            this.enableFileEnumerationToolStripMenuItem.Click += new System.EventHandler(this.enableFileEnumerationToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowUnsafeOperationsToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // allowUnsafeOperationsToolStripMenuItem
            // 
            this.allowUnsafeOperationsToolStripMenuItem.Name = "allowUnsafeOperationsToolStripMenuItem";
            this.allowUnsafeOperationsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.allowUnsafeOperationsToolStripMenuItem.Text = "Allow Unsafe Operations";
            this.allowUnsafeOperationsToolStripMenuItem.Click += new System.EventHandler(this.allowUnsafeOperationsToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.statusText);
            this.panel1.Location = new System.Drawing.Point(168, 24);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(404, 225);
            this.panel1.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.enableJson);
            this.Controls.Add(this.Fix);
            this.Controls.Add(this.Scan);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CScan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scan;
        private System.Windows.Forms.Button Fix;
        private System.Windows.Forms.RichTextBox statusText;
        private System.Windows.Forms.CheckBox enableJson;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowUnsafeOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableFileEnumerationToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

