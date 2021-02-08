using Logic.Foundation.Encodings.Contract;
using Logic.Foundation.Graphics.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Graphics
{
    public class ScreenshotConverter : IScreenshotConverter
    {
        private readonly IBinaryDecoder binaryDecoder;
        private readonly IBinaryEncoder binaryEncoder;
        private readonly IResize resize;

        public ScreenshotConverter(IBinaryDecoder binaryDecoder, IBinaryEncoder binaryEncoder, IResize resize)
        {
            this.binaryDecoder = binaryDecoder;
            this.binaryEncoder = binaryEncoder;
            this.resize = resize;
        }

        public Bitmap GetBitmapFromBase64(string base64)
        {
            byte[] arr = this.binaryDecoder.DecodePlainText(base64);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bitmap = new Bitmap(ms);

            return bitmap;
        }

        public string GetScreenshotAsBase64(Bitmap screenshot, int maxWidth, int maxHeight)
        {
            using (Bitmap bitmap = screenshot)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap newImage = this.resize.ResizeImage(bitmap, maxWidth, maxHeight))
                    {
                        newImage.Save(ms, ImageFormat.Jpeg);
                        string base64 = this.binaryEncoder.GetAsPlainText(ms.GetBuffer());
                        return base64;
                    }
                }
            }
        }
    }
}
