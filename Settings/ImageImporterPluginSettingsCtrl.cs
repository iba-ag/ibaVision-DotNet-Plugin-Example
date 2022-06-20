using System;
using System.IO;
using System.Windows.Forms;

using iba.Capture.MachineVision.PluginLib;

namespace iba.Capture.MachineVision.Plugins.ImageImporter
{
    /// <summary>
    /// This WinForms user control will be displayed in the ibaVision plugin settings
    /// </summary>
    /// <seealso cref="iba.Capture.MachineVision.PluginLib.PluginSettingsCtrl" />
    public partial class ImageImporterPluginSettingsCtrl : PluginSettingsCtrl
    {
        private readonly ImageImporterPluginSettings importerPluginSettings;

        public ImageImporterPluginSettingsCtrl(ImageImporterPluginSettings settings)
        {
            InitializeComponent();

            importerPluginSettings = settings;

            tbExternalProcPath.Text = settings.ImageFolderPath;
        }

        void btOpenProcPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(importerPluginSettings.ImageFolderPath))
                {
                    folderBrowserDialog.SelectedPath = importerPluginSettings.ImageFolderPath;
                }

                folderBrowserDialog.Description = "Select image directory";
                folderBrowserDialog.ShowNewFolderButton = false;

                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbExternalProcPath.Text = folderBrowserDialog.SelectedPath;
                    importerPluginSettings.ImageFolderPath = Path.GetFullPath(folderBrowserDialog.SelectedPath);

                    // Load the program to retrieve procedures
                    LoadProgramFunc?.Invoke(true);
                }
            }
        }
    }
}
