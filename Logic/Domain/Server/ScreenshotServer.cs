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
using System.Text.RegularExpressions;

namespace Logic.Domain.Server
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
                Regex ratioRegex = new Regex(@"ratio=(?<ratio>\d+)");
                Match match = ratioRegex.Match(text);
                int? ratio = null;
                if (match.Success)
                {
                    string ratioValue = match.Groups["ratio"].Value;
                    if (!string.IsNullOrEmpty(ratioValue))
                    {
                        ratio = Int32.Parse(ratioValue);
                    }
                }
                string base64;
                if (ratio != null)
                {
                    base64 = GetScreenshotAsText(this.screenshot.GetPrimaryScreen(), ratio.Value);
                }
                else
                {
                    base64 = GetScreenshotAsText(this.screenshot.GetPrimaryScreen(), maxWidth, maxHeight);
                }
                return base64;
            }
            this.receiver.Start(ConnectionSettings.PrimaryScreenPipeName, Send);
        }

        public void StartSendScreen(int maxWidth, int maxHeight)
        {
            string Send(string text)
            {
                ScreenInformation screenInformation = this.deserializer.Deserialize<ScreenInformation>(text);
                string base64;
                if (screenInformation.Ratio != null)
                {
                    base64 = GetScreenshotAsText(this.screenshot.GetScreen(screenInformation.Index), screenInformation.Ratio.Value);
                }
                else
                {
                    base64 = GetScreenshotAsText(this.screenshot.GetScreen(screenInformation.Index), maxWidth, maxHeight);
                }
                return base64;
            }
            this.receiver.Start(ConnectionSettings.ScreenPipeName, Send);
        }

        public void StartSendScreenList()
        {
            string Send(string text)
            {
                List<ScreenInformation> screenInformationList = this.screenshot.GetScreenList().ToList();
                string returnValue = this.serializer.Serialize(screenInformationList);
                return returnValue;
            }
            this.receiver.Start(ConnectionSettings.ScreenListPipeName, Send);
        }

        private string GetScreenshotAsText(Bitmap screenshot, int ratio) 
        {
            int maxWidth = screenshot.Width * ratio / 100;
            int maxHeight = screenshot.Height * ratio / 100;
            return GetScreenshotAsText(screenshot, maxWidth, maxHeight);
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
