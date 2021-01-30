using CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Client.Contract
{
    public interface IScreenshotClient
    {
        Bitmap GetScreenshot(string target);
        Bitmap GetScreenshot(string target, ScreenInformation screenInformation);
        IReadOnlyList<ScreenInformation> GetScreenInformationList(string target);
    }
}
