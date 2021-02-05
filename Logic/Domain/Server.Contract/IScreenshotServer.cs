using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Server.Contract
{
    public interface IScreenshotServer
    {
        event EventHandler<Bitmap> ScreenshotSent;
        void StartSendPrimaryScreen(int maxWidth, int maxHeight);
        void StartSendScreen(int maxWidth, int maxHeight);
        void StartSendScreenList();
    }
}
