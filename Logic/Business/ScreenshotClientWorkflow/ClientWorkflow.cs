using Logic.Business.ScreenshotClientWorkflow.Contract;
using Logic.Foundation.Client.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Business.ScreenshotClientWorkflow
{
    public class ClientWorkflow : IClientWorkflow
    {
        private readonly IScreenshotClient client;

        public ClientWorkflow(IScreenshotClient client)
        {
            this.client = client;
        }

        public Bitmap GetScreenshot(string target)
        {
            return this.client.GetScreenshot(target, CrossCutting.DataClasses.ConnectionSettings.PipeName);
        }
    }
}
