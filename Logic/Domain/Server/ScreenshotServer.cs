using CrossCutting.DataClasses;
using Logic.Foundation.Encodings.Contract;
using Logic.Foundation.Graphics.Contract;
using Logic.Foundation.Io.Contract;
using Logic.Foundation.Serialization.Contract;
using Logic.Domain.Server.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Foundation.Screen.Contract;

namespace Logic.Domain.Server
{
    public class ScreenshotServer : IScreenshotServer
    {
        private readonly IScreenshot screenshot;
        private readonly IScreenshotConverter screenshotConverter;
        private readonly IReceiver receiver;
        private readonly ISerializer serializer;
        private readonly IDeserializer deserializer;
        private readonly IScreenInformation screenInformation;

        public ScreenshotServer(IScreenshot screenshot, IScreenshotConverter screenshotConverter,
            IReceiver receiver, ISerializer serializer, IDeserializer deserializer, IScreenInformation screenInformation)
        {
            this.screenshot = screenshot;
            this.receiver = receiver;
            this.serializer = serializer;
            this.deserializer = deserializer;
            this.screenInformation = screenInformation;
            this.screenshotConverter = screenshotConverter;
        }

        public event EventHandler<Bitmap> ScreenshotSent;



        public void StartSendPrimaryScreen(int maxWidth, int maxHeight)
        {
            string Send(string text)
            {
                Bitmap bitmap = this.screenshot.GetPrimaryScreen();
                string base64 = this.screenshotConverter.GetScreenshotAsBase64(bitmap, maxWidth, maxHeight);
                ScreenshotSent?.Invoke(this, this.screenshotConverter.GetBitmapFromBase64(base64));
                return base64;
            }
            this.receiver.Start(ConnectionSettings.PrimaryScreenPipeName, Send);
        }

        public void StartSendScreen(int maxWidth, int maxHeight)
        {
            string Send(string text)
            {
                ScreenInformation screenInformation = this.deserializer.Deserialize<ScreenInformation>(text);
                Bitmap bitmap = this.screenshot.GetScreen(screenInformation.Index);
                string base64 = this.screenshotConverter.GetScreenshotAsBase64(bitmap, maxWidth, maxHeight);
                ScreenshotSent?.Invoke(this, this.screenshotConverter.GetBitmapFromBase64(base64));
                return base64;
            }
            this.receiver.Start(ConnectionSettings.ScreenPipeName, Send);
        }

        public void StartSendScreenList()
        {
            string Send(string text)
            {
                List<ScreenInformation> screenInformationList = this.screenInformation.GetScreenInformationList().ToList();
                string returnValue = this.serializer.Serialize(screenInformationList);
                return returnValue;
            }
            this.receiver.Start(ConnectionSettings.ScreenListPipeName, Send);
        }
    }
}
