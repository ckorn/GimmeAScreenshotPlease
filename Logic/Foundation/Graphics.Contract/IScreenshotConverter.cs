using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Graphics.Contract
{
    public interface IScreenshotConverter
    {
        Bitmap GetBitmapFromBase64(string base64);
        string GetScreenshotAsBase64(Bitmap screenshot, int maxWidth, int maxHeight);
    }
}
