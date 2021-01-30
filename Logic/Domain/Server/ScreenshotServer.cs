using CrossCutting.DataClasses;
using Logic.Foundation.Encodings.Contract;
using Logic.Foundation.Graphics.Contract;
using Logic.Foundation.Io.Contract;
using Logic.Foundation.Serialization.Contract;
using Logic.Foundation.Server.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic.Foundation.Server
{
    public class ScreenshotServer : IScreenshotServer
    {
        private readonly IScreenshot screenshot;
        private readonly IReceiver receiver;
        private readonly IResize resize;
        private readonly IBinaryEncoder binaryEncoder;
        private readonly ISerializer serializer;
        private readonly IDeserializer deserializer;

        public event EventHandler<Bitmap> ScreenshotSent;

        public ScreenshotServer(IScreenshot screenshot, IReceiver receiver, IResize resize,
            IBinaryEncoder binaryEncoder, ISerializer serializer, IDeserializer deserializer)
        {
            this.screenshot = screenshot;
            this.receiver = receiver;
            this.resize = resize;
            this.binaryEncoder = binaryEncoder;
            this.serializer = serializer;
            this.deserializer = deserializer;
        }

        public void StartSendPrimaryScreen(int maxWidth, int maxHeight)
        {
            string Send(string text) 
            {
                string base64 = GetScreenshotAsText(this.screenshot.GetPrimaryScreen(), maxWidth, maxHeight);
                return base64;
            }
            this.receiver.Start(ConnectionSettings.PrimaryScreenPipeName, Send);
        }

        public void StartSendScreen(int maxWidth, int maxHeight)
        {
            string Send(string text)
            {
                ScreenInformation screenInformation = this.deserializer.Deserialize<ScreenInformation>(text);
                string base64 = GetScreenshotAsText(this.screenshot.GetScreen(screenInformation.Index), maxWidth, maxHeight);
                return base64;
            }
            this.receiver.Start(ConnectionSettings.ScreenPipeName, Send);
        }

        public void StartSendScreenList()
        {
            string Send(string text)
            {
                IReadOnlyList<Screen> screenList = this.screenshot.GetScreenList();
                List<ScreenInformation> screenInformationList = screenList.Select((x, i) => new ScreenInformation(i, x.DeviceName)).ToList();
                string returnValue = this.serializer.Serialize(screenInformationList);
                return returnValue;
            }
            this.receiver.Start(ConnectionSettings.ScreenListPipeName, Send);
        }

        private string GetScreenshotAsText(Bitmap screenshot, int maxWidth, int maxHeight) 
        {
            using (Bitmap bitmap = screenshot)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap newImage = this.resize.ResizeImage(bitmap, maxWidth, maxHeight))
                    {
                        ScreenshotSent?.Invoke(this, new Bitmap(newImage));
                        newImage.Save(ms, ImageFormat.Jpeg);
                        string base64 = this.binaryEncoder.GetAsPlainText(ms.GetBuffer());
                        return base64;
                    }
                }
            }
        }
    }
}
