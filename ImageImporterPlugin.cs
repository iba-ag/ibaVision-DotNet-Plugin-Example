using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;

using iba.Capture.MachineVision.PluginLib;


namespace iba.Capture.MachineVision.Plugins.ImageImporter
{
    public class ImageImporterPlugin : UserPluginV100
    {
        public override string DisplayName => "Image importer";
        public override string Description => "Imports BMP images into ibaVision and combines them into an output video stream.";

        private ImageImporterPluginSettings settings;

        public ImageImporterPlugin()
        {
            // ###### Procedure 1

            ProcedureDescription procedureDescription = new ProcedureDescription
            {
                Name = "Load images",
                InfoText = "Loads *.bmp images from the selected directory and provides them as an iconic output.",

                MethodToExecute = ImportNextImage,

                // ###### Configure outputs here

                OutputsIconicDescription =
                {
                    new ProcedureDescription.Parameter
                    {
                        Index = 0,
                        Name = "Image file",
                        InfoText = "Loaded *.bmp file"
                    },

                    //new ProcedureDescription.Parameter
                    //{
                    //    Index = 1,
                    //    Name = "Dummy parameter name",
                    //    InfoText = "Dummy parameter info text"
                    //}
                },
                //OutputsControlDescription =
                //{
                //    new ProcedureDescription.Parameter
                //    {
                //        Index = 0,
                //        Name = "Dummy parameter name",
                //        InfoText = "Dummy parameter info text"
                //    }
                //},

                // ###### Configure inputs here

                //InputsIconicDescription =
                //{
                //    new ProcedureDescription.Parameter
                //    {
                //        Index = 0,
                //        Name = "Dummy parameter name",
                //        InfoText = "Dummy parameter info"
                //    },
                //    new ProcedureDescription.Parameter
                //    {
                //        Index = 1,
                //        Name = "Dummy parameter name",
                //        InfoText = "Dummy parameter info"
                //    }
                //},
                //InputsControlDescription =
                //{
                //    new ProcedureDescription.Parameter
                //    {
                //        Index = 0,
                //        Name = "Dummy parameter name",
                //        InfoText = "Dummy parameter info"
                //    }
                //}
            };

            Procedures.Add(procedureDescription.Name, procedureDescription);

            // ###### Add further procedures here

            //procedureDescription = new ProcedureDescription
            //{
            //    Name = "Dummy procedure name",
            //    InfoText = "Dummy procedure info text",
            //    MethodToExecute = ImportNextImage,
            //    OutputsIconicDescription =
            //    {
            //        new ProcedureDescription.Parameter
            //        {
            //            Index = 0,
            //            Name = "Dummy parameter name",
            //            InfoText = "Dummy parameter info"
            //        }
            //    }

            //};

            //Procedures.Add(procedureDescription.Name, procedureDescription);
        }

        /// <summary>
        /// Performs a one time initialization of the program with the user provided settings.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public override IEnumerable<PluginMessage> Initialize(PluginSettings settings)
        {
            this.settings = (ImageImporterPluginSettings)settings;

            imageCounter = 0;

            IsInitialized = true;

            yield break;
        }

        int imageCounter;
        private long tickCounter;
        /// <summary>
        /// Runs the procedure on the inputs.
        /// The procedure needs to set the output parameters before returning.
        /// </summary>
        private void ImportNextImage()
        {
            // Find all BMP files in directory.
            List<string> filePaths = Directory.GetFiles(settings.ImageFolderPath)
                .Where(x => Path.GetExtension(x).ToUpper() == ".BMP").ToList();

            if (!filePaths.Any())
                return;

            // Create IbaImage from BMP file.
            using (Bitmap bmp = new Bitmap(filePaths[imageCounter]))
            {
                IbaVisionImage ibaVisionImage = ImageHelper.ConvertToIbaBitmap(bmp);

                ibaVisionImage.TimeStamp =  new DateTime(DateTime.Now.Ticks - TimeSpan.FromHours(12).Ticks + tickCounter);
                tickCounter++;

                Procedures["Load images"].OutputsIconic[0] = ibaVisionImage;
            }

            imageCounter++;

            if (imageCounter >= filePaths.Count)
            {
                imageCounter = 0;
            }

            Thread.Sleep(40);
        }

        #region Validation

        /// <summary>
        /// Checks whether the minimum requirements for this plugin are fulfilled
        /// and returns a collection of messages to display.
        /// Check will fail if any error messages are returned.
        /// </summary>
        public override IEnumerable<PluginMessage> CheckMinRequirements()
        {
            List<PluginMessage> messages = new List<PluginMessage>();

            // ######
            // Add custom requirements for the plugin here (like installed third party software, required devices, etc.)
            //if (!CONDITION)
            //{
            //    messages.Add(
            //        new PluginMessage
            //        {
            //            MessageType = IbaMessageType.Error,
            //            Text = "DUMMY TEXT"
            //        });
            //}
            // ######

            // Perform build-in base checks.
            messages.AddRange(base.CheckMinRequirements());

            return messages;
        }

        /// <summary>
        /// Checks whether the passed plugin settings are valid
        /// and returns a collection of messages to display.
        /// Check will fail if any error messages are returned.
        /// </summary>
        /// <param name="settings"></param>
        public override IEnumerable<PluginMessage> ValidatePluginSettings(PluginSettings settings)
        {
            List<PluginMessage> messages = new List<PluginMessage>();

            ImageImporterPluginSettings imageImporterSettings = settings as ImageImporterPluginSettings;

            if (!Directory.Exists(imageImporterSettings.ImageFolderPath))
            {
                messages.Add(
                    new PluginMessage
                    {
                        MessageType = IbaMessageType.Error,
                        Text = $"Directory '{imageImporterSettings.ImageFolderPath}' does not exist."
                    });
            }

            return messages;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // ######
                // Add disposal code here.
                // ######
            }
        }

        #endregion
    }
}
