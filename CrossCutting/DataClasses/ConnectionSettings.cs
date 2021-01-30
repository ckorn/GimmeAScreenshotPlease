using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DataClasses
{
    public static class ConnectionSettings
    {
        public const string PrimaryScreenPipeName = "GimmeAScreenshotPlease.SendScreenshotPrimaryScreen";
        public const string ScreenPipeName = "GimmeAScreenshotPlease.SendScreenshotForScreen";
        public const string ScreenListPipeName = "GimmeAScreenshotPlease.SendScreenList";
    }
}
