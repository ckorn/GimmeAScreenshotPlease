using CrossCutting.DataClasses;
using Logic.Foundation.Encodings.Contract;
using Logic.Foundation.Graphics.Contract;
using Logic.Foundation.Screen.Contract;
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
    public class Screenshot : IScreenshot
    {
        private readonly IScreenInformation screenInformation;

        public Screenshot(IScreenInformation screenInformation)
        {
            this.screenInformation = screenInformation;
        }

        public Bitmap GetPrimaryScreen()
        {
            return GetScreen(this.screenInformation.GetScreenInformationList()[0]);
        }

        public Bitmap GetScreen(ScreenInformation screen)
        {
            //Create a new bitmap.
            Bitmap bmpScreenshot = new Bitmap(screen.Width,
                                           screen.Height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            System.Drawing.Graphics gfxScreenshot = System.Drawing.Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            Size size = new Size(screen.Width, screen.Height);
            gfxScreenshot.CopyFromScreen(screen.X,
                                        screen.Y,
                                        0,
                                        0,
                                        size,
                                        CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
        }

        public Bitmap GetScreen(int screenIndex)
        {
            IReadOnlyList<ScreenInformation> screenList = this.screenInformation.GetScreenInformationList();
            if ((screenIndex < 0) || (screenIndex >= screenList.Count))
            {
                throw new ArgumentOutOfRangeException($"{nameof(screenIndex)} = {screenIndex}");
            }
            return GetScreen(screenList[screenIndex]);
        }
    }
}
