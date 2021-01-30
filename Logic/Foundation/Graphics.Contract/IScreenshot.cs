using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic.Foundation.Graphics.Contract
{
    public interface IScreenshot
    {
        IReadOnlyList<Screen> GetScreenList();
        Bitmap GetPrimaryScreen();
        Bitmap GetScreen(Screen screen);
        Bitmap GetScreen(int screenIndex);
    }
}
