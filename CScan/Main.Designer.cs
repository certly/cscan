﻿namespace CScan
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
            this.Scan = new System.Windows.Forms.Button();
            this.Fix = new System.Windows.Forms.Button();
            this.encryptionKey = new System.Windows.Forms.TextBox();
            this.statusText = new System.Windows.Forms.RichTextBox();
            this.enableJson = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Scan
            // 
            this.Scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Scan.Location = new System.Drawing.Point(24, 23);
            this.Scan.Margin = new System.Windows.Forms.Padding(6);
            this.Scan.Name = "Scan";
            this.Scan.Size = new System.Drawing.Size(300, 96);
            this.Scan.TabIndex = 0;
            this.Scan.Text = "Scan";
            this.Scan.UseVisualStyleBackColor = true;
            this.Scan.Click += new System.EventHandler(this.Scan_Click);
            // 
            // Fix
            // 
            this.Fix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Fix.Location = new System.Drawing.Point(24, 131);
            this.Fix.Margin = new System.Windows.Forms.Padding(6);
            this.Fix.Name = "Fix";
            this.Fix.Size = new System.Drawing.Size(300, 96);
            this.Fix.TabIndex = 1;
            this.Fix.Text = "Fix";
            this.Fix.UseVisualStyleBackColor = true;
            this.Fix.Click += new System.EventHandler(this.Fix_Click);
            // 
            // encryptionKey
            // 
            this.encryptionKey.Location = new System.Drawing.Point(24, 238);
            this.encryptionKey.Margin = new System.Windows.Forms.Padding(6);
            this.encryptionKey.Name = "encryptionKey";
            this.encryptionKey.Size = new System.Drawing.Size(296, 31);
            this.encryptionKey.TabIndex = 3;
            this.encryptionKey.Text = "Optional Encryption Key";
            this.encryptionKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusText
            // 
            this.statusText.DetectUrls = false;
            this.statusText.HideSelection = false;
            this.statusText.Location = new System.Drawing.Point(336, 23);
            this.statusText.Margin = new System.Windows.Forms.Padding(6);
            this.statusText.Name = "statusText";
            this.statusText.ReadOnly = true;
            this.statusText.Size = new System.Drawing.Size(804, 452);
            this.statusText.TabIndex = 4;
            this.statusText.Text = "";
            // 
            // enableJson
            // 
            this.enableJson.AutoSize = true;
            this.enableJson.Location = new System.Drawing.Point(24, 278);
            this.enableJson.Name = "enableJson";
            this.enableJson.Size = new System.Drawing.Size(243, 29);
            this.enableJson.TabIndex = 5;
            this.enableJson.Text = "Enable JSON Output";
            this.enableJson.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 502);
            this.Controls.Add(this.enableJson);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.encryptionKey);
            this.Controls.Add(this.Fix);
            this.Controls.Add(this.Scan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CScan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scan;
        private System.Windows.Forms.Button Fix;
        private System.Windows.Forms.TextBox encryptionKey;
        private System.Windows.Forms.RichTextBox statusText;
        private System.Windows.Forms.CheckBox enableJson;
    }
}

