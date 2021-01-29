using Logic.Foundation.Graphics.Contract;
using Logic.Foundation.Io.Contract;
using Logic.Foundation.Server.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Server
{
    public class ScreenshotServer : IScreenshotServer
    {
        private readonly IScreenshot screenshot;
        private readonly IReceiver receiver;

        public event EventHandler<Bitmap> ScreenshotSent;

        public ScreenshotServer(IScreenshot screenshot, IReceiver receiver)
        {
            this.screenshot = screenshot;
            this.receiver = receiver;
        }

        public void Start(string name)
        {
            string Send(string text) 
            {
                Bitmap bitmap = this.screenshot.GetFullScreen();
                ScreenshotSent?.Invoke(this, bitmap);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap newImage = new Bitmap(bitmap))
                    {
                        newImage.Save(ms, ImageFormat.Jpeg);
                        string base64 = Convert.ToBase64String(ms.GetBuffer());
                        return base64;
                    }
                }
            }
            this.receiver.Start(name, Send);
        }
    }
}
