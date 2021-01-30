using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Business.ScreenshotServerWorkflow.Contract
{
    public interface IServerWorkflow
    {
        event EventHandler<Bitmap> ScreenshotSent;
        void StartSendPrimaryScreen();
        void StartSendScreen();
        void StartSendScreenList();
    }
}
