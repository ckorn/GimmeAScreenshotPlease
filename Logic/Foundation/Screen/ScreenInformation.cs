using Logic.Foundation.Screen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Foundation.Screen
{
    public class ScreenInformation : IScreenInformation
    {
        public IReadOnlyList<CrossCutting.DataClasses.ScreenInformation> GetScreenInformationList()
        {
            return System.Windows.Forms.Screen.AllScreens
                .Select((x, i) => new CrossCutting.DataClasses.ScreenInformation(i, x.DeviceName, x.Bounds.Width, x.Bounds.Height, x.Bounds.X, x.Bounds.Y)).ToList();
        }
    }
}
