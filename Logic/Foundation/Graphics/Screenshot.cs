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
            return GetScreen(Screen.PrimaryScreen);
        }

        public Bitmap GetScreen(Screen screen)
        {
            //Create a new bitmap.
            Bitmap bmpScreenshot = new Bitmap(screen.Bounds.Width,
                                           screen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            System.Drawing.Graphics gfxScreenshot = System.Drawing.Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(screen.Bounds.X,
                                        screen.Bounds.Y,
                                        0,
                                        0,
                                        screen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
        }

        public Bitmap GetScreen(int screenIndex)
        {
            IReadOnlyList<Screen> screenList = this.GetScreenList();
            if ((screenIndex < 0) || (screenIndex >= screenList.Count))
            {
                throw new ArgumentOutOfRangeException($"{nameof(screenIndex)} = {screenIndex}");
            }
            return GetScreen(screenList[screenIndex]);
        }

        public IReadOnlyList<Screen> GetScreenList()
        {
            return Screen.AllScreens;
        }
    }
}
