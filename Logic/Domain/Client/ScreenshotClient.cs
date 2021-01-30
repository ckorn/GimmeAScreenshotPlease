using Logic.Foundation.Client.Contract;
using Logic.Foundation.Encodings.Contract;
using Logic.Foundation.Io.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Client
{
    public class ScreenshotClient : IScreenshotClient
    {
        private readonly ISender sender;
        private readonly IBinaryDecoder binaryDecoder;
        public ScreenshotClient(ISender sender, IBinaryDecoder binaryDecoder)
        {
            this.sender = sender;
            this.binaryDecoder = binaryDecoder;
        }

        public Bitmap GetScreenshot(string target, string name)
        {
            string result = this.sender.Send(target, name, "GimmeAScreenshotPlease");
            byte[] arr = this.binaryDecoder.DecodePlainText(result);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bitmap = new Bitmap(ms);

            return bitmap;
        }
    }
}
