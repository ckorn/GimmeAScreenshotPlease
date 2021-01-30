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
        private readonly IResize resize;

        public event EventHandler<Bitmap> ScreenshotSent;

        public ScreenshotServer(IScreenshot screenshot, IReceiver receiver, IResize resize)
        {
            this.screenshot = screenshot;
            this.receiver = receiver;
            this.resize = resize;
        }

        public void Start(string name, int maxWidth, int maxHeight)
        {
            string Send(string text) 
            {
                using (Bitmap bitmap = this.screenshot.GetFullScreen()) 
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (Bitmap newImage = this.resize.ResizeImage(bitmap, maxWidth, maxHeight))
                        {
                            ScreenshotSent?.Invoke(this, new Bitmap(newImage));
                            newImage.Save(ms, ImageFormat.Jpeg);
                            string base64 = Convert.ToBase64String(ms.GetBuffer());
                            return base64;
                        }
                    }
                }
            }
            this.receiver.Start(name, Send);
        }
    }
}
