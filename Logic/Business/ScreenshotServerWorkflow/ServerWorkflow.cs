using CrossCutting.DataClasses;
using Logic.Business.ScreenshotServerWorkflow.Contract;
using Logic.Domain.Server.Contract;
using Logic.Foundation.Screen.Contract;
using Logic.Foundation.Serialization.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Business.ScreenshotServerWorkflow
{
    public class ServerWorkflow : IServerWorkflow
    {
        private readonly IScreenshotServer screenshotServer;
        private readonly IScreenInformation screenInformation;
        private readonly ISerializer serializer;

        public event EventHandler<Bitmap> ScreenshotSent;

        public ServerWorkflow(IScreenshotServer screenshotServer, IScreenInformation screenInformation,
            ISerializer serializer)
        {
            this.screenshotServer = screenshotServer;
            this.screenshotServer.ScreenshotSent += ScreenshotServer_ScreenshotSent;
            this.screenInformation = screenInformation;
            this.serializer = serializer;
        }

        private void ScreenshotServer_ScreenshotSent(object sender, Bitmap e)
        {
            this.ScreenshotSent?.Invoke(sender, e);
        }

        public void StartSendPrimaryScreen()
        {
            this.screenshotServer.StartSendPrimaryScreen(CrossCutting.DataClasses.ScreenshotOptions.MaxWidth,
                CrossCutting.DataClasses.ScreenshotOptions.MaxHeight);
        }

        public void StartSendScreen()
        {
            this.screenshotServer.StartSendScreen(CrossCutting.DataClasses.ScreenshotOptions.MaxWidth,
                CrossCutting.DataClasses.ScreenshotOptions.MaxHeight);
        }

        public void StartSendScreenList()
        {
            this.screenshotServer.StartSendScreenList();
        }

        public string WriteScreenSettings()
        {
            ScreenSettings screenSettings = new ScreenSettings()
            {
                ScreenInformationList = this.screenInformation.GetScreenInformationList().ToList()
            };
            string json = this.serializer.Serialize(screenSettings);
            string fileName = "screenList.json";
            File.WriteAllText(fileName, json);
            return fileName;
        }
    }
}
