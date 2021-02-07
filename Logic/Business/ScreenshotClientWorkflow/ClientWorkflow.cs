using CrossCutting.DataClasses;
using Logic.Business.ScreenshotClientWorkflow.Contract;
using Logic.Domain.Client.Contract;
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

        public async Task<Bitmap> GetScreenshotPrimaryScreenAsync(string target)
        {
            return await this.client.GetScreenshotAsync(target);
        }

        public async Task<Bitmap> GetScreenshotForScreenAsync(string target, ScreenInformation screenInformation)
        {
            return await this.client.GetScreenshotAsync(target, screenInformation);
        }

        public async Task<IReadOnlyList<ScreenInformation>> GetScreenInformationListAsync(string target)
        {
            return await this.client.GetScreenInformationListAsync(target);
        }

        public Task<string> GetScreenshotPrimaryScreenAsBase64Async(string target)
        {
            return this.client.GetScreenshotAsBase64Async(target);
        }

        public Task<string> GetScreenshotForScreenAsBase64Async(string target, ScreenInformation screenInformation)
        {
            return this.client.GetScreenshotAsBase64Async(target, screenInformation);
        }
    }
}
