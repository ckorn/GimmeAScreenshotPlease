using CrossCutting.DataClasses;
using Logic.Foundation.Graphics.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic.Foundation.Graphics
{
    public class Screenshot : IScreenshot
    {
        public Bitmap GetPrimaryScreen()
        {
            foreach (ScreenInformation screenInformation in GetScreenList())
            {
                if (screenInformation.Name == Screen.PrimaryScreen.DeviceName)
                {
                    return GetScreen(screenInformation);
                }
            }
            throw new InvalidOperationException("Primary screen not found");
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
            IReadOnlyList<ScreenInformation> screenList = this.GetScreenList();
            if ((screenIndex < 0) || (screenIndex >= screenList.Count))
            {
                throw new ArgumentOutOfRangeException($"{nameof(screenIndex)} = {screenIndex}");
            }
            return GetScreen(screenList[screenIndex]);
        }

        public IReadOnlyList<ScreenInformation> GetScreenList()
        {
            return Screen.AllScreens.Select((x, i) => new ScreenInformation(i, x.DeviceName, x.Bounds.Width, x.Bounds.Height, x.Bounds.X, x.Bounds.Y)).ToList();
        }
    }
}
