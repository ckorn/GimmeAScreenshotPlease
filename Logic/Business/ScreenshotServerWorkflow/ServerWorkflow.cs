using Logic.Business.ScreenshotServerWorkflow.Contract;
using Logic.Foundation.Server.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Business.ScreenshotServerWorkflow
{
    public class ServerWorkflow : IServerWorkflow
    {
        private readonly IScreenshotServer screenshotServer;

        public event EventHandler<Bitmap> ScreenshotSent;

        public ServerWorkflow(IScreenshotServer screenshotServer)
        {
            this.screenshotServer = screenshotServer;
            this.screenshotServer.ScreenshotSent += ScreenshotServer_ScreenshotSent;
        }

        private void ScreenshotServer_ScreenshotSent(object sender, Bitmap e)
        {
            this.ScreenshotSent?.Invoke(sender, e);
        }

        public void Start()
        {
            this.screenshotServer.Start(CrossCutting.DataClasses.ConnectionSettings.PipeName,
                CrossCutting.DataClasses.ScreenshotOptions.MaxWidth,
                CrossCutting.DataClasses.ScreenshotOptions.MaxHeight);
        }
    }
}
