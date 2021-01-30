using CrossCutting.DataClasses;
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

        public Bitmap GetScreenshotPrimaryScreen(string target)
        {
            return this.client.GetScreenshot(target);
        }

        public Bitmap GetScreenshotForScreen(string target, ScreenInformation screenInformation)
        {
            return this.client.GetScreenshot(target, screenInformation);
        }

        public IReadOnlyList<ScreenInformation> GetScreenInformationList(string target)
        {
            return this.client.GetScreenInformationList(target);
        }
    }
}
