
using iba.Capture.MachineVision.PluginLib;

namespace iba.Capture.MachineVision.Plugins.ImageImporter
{
    partial class ImageImporterPluginSettingsCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbExternalProcPath = new System.Windows.Forms.TextBox();
            this.lbDirectoryPath = new System.Windows.Forms.Label();
            this.btOpenProcPath = new System.Windows.Forms.Button();
            this.grpDebugging = new System.Windows.Forms.Panel();
            this.grpDebugging.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbExternalProcPath
            // 
            this.tbExternalProcPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExternalProcPath.Location = new System.Drawing.Point(125, 7);
            this.tbExternalProcPath.Name = "tbExternalProcPath";
            this.tbExternalProcPath.ReadOnly = true;
            this.tbExternalProcPath.Size = new System.Drawing.Size(435, 20);
            this.tbExternalProcPath.TabIndex = 17;
            // 
            // lbDirectoryPath
            // 
            this.lbDirectoryPath.AutoSize = true;
            this.lbDirectoryPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDirectoryPath.Location = new System.Drawing.Point(17, 10);
            this.lbDirectoryPath.Name = "lbDirectoryPath";
            this.lbDirectoryPath.Size = new System.Drawing.Size(87, 13);
            this.lbDirectoryPath.TabIndex = 16;
            this.lbDirectoryPath.Text = "Images directory:";
            // 
            // btOpenProcPath
            // 
            this.btOpenProcPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenProcPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btOpenProcPath.Location = new System.Drawing.Point(566, 4);
            this.btOpenProcPath.Name = "btOpenProcPath";
            this.btOpenProcPath.Size = new System.Drawing.Size(24, 24);
            this.btOpenProcPath.TabIndex = 18;
            this.btOpenProcPath.Text = "...";
            this.btOpenProcPath.UseVisualStyleBackColor = true;
            this.btOpenProcPath.Click += new System.EventHandler(this.btOpenProcPath_Click);
            // 
            // grpDebugging
            // 
            this.grpDebugging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDebugging.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpDebugging.Controls.Add(this.btOpenProcPath);
            this.grpDebugging.Controls.Add(this.lbDirectoryPath);
            this.grpDebugging.Controls.Add(this.tbExternalProcPath);
            this.grpDebugging.Location = new System.Drawing.Point(0, 0);
            this.grpDebugging.Name = "grpDebugging";
            this.grpDebugging.Size = new System.Drawing.Size(607, 39);
            this.grpDebugging.TabIndex = 17;
            // 
            // ImageImporterPluginSettingsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDebugging);
            this.Name = "ImageImporterPluginSettingsCtrl";
            this.Size = new System.Drawing.Size(607, 39);
            this.grpDebugging.ResumeLayout(false);
            this.grpDebugging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbExternalProcPath;
        private System.Windows.Forms.Label lbDirectoryPath;
        private System.Windows.Forms.Button btOpenProcPath;
        private System.Windows.Forms.Panel grpDebugging;
    }
}
