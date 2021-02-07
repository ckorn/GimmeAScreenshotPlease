using CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Graphics.Contract
{
    public interface IScreenshot
    {
        IReadOnlyList<ScreenInformation> GetScreenList();
        Bitmap GetPrimaryScreen();
        Bitmap GetScreen(ScreenInformation screen);
        Bitmap GetScreen(int screenIndex);
    }
}
