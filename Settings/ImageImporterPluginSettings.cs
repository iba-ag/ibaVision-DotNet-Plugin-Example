using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using iba.Capture.MachineVision.PluginLib;

namespace iba.Capture.MachineVision.Plugins.ImageImporter
{
    public sealed class ImageImporterPluginSettings : PluginSettings
    {
        public string ImageFolderPath { get; set; }

        public override void LoadFromXml(XmlNode node)
        {
            ImageFolderPath = LoadElementString(node, "ImageFolderPath", string.Empty);
        }

        public override void SaveToXml(XmlWriter xmlOut)
        {
            xmlOut.WriteElementString("ImageFolderPath", ImageFolderPath);
        }

        public override IEnumerable<PluginMessage> ValidateSettings()
        {
            if (string.IsNullOrEmpty(ImageFolderPath) || !Directory.Exists(ImageFolderPath))
            {
                yield return new PluginMessage()
                {
                    MessageType = IbaMessageType.Error,
                    Text = string.Format("The provided image directory is not valid: '{0}'", ImageFolderPath)
                };
            }
        }

        public override int GetChecksum()
        {
            return ImageFolderPath.GetHashCode();
        }
    }
}
