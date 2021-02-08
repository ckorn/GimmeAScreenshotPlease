using CrossCutting.DataClasses;
using Logic.Domain.Client.Contract;
using Logic.Foundation.Graphics.Contract;
using Logic.Foundation.Screen.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Logic.Domain.ClientSettings
{
    public class ClientSettings : IScreenshotClient
    {
        private readonly IScreenInformation screenInformation;
        private readonly IScreenshot screenshot;
        private readonly IScreenshotConverter screenshotConverter;

        public ClientSettings(IScreenInformation screenInformation, IScreenshot screenshot,
            IScreenshotConverter screenshotConverter)
        {
            this.screenInformation = screenInformation;
            this.screenshot = screenshot;
            this.screenshotConverter = screenshotConverter;
        }

        public Task<IReadOnlyList<ScreenInformation>> GetScreenInformationListAsync(string target)
        {
            return Task.Factory.StartNew(() => this.screenInformation.GetScreenInformationList());
        }

        public Task<string> GetScreenshotAsBase64Async(string target)
        {
            return Task.Factory.StartNew(() => 
            {
                Bitmap bitmap = this.screenshot.GetPrimaryScreen();
                return this.screenshotConverter.GetScreenshotAsBase64(bitmap, ScreenshotOptions.MaxWidth,
                    ScreenshotOptions.MaxHeight);
            });
        }

        public Task<string> GetScreenshotAsBase64Async(string target, ScreenInformation screenInformation)
        {
            return Task.Factory.StartNew(() =>
            {
                Bitmap bitmap = this.screenshot.GetScreen(screenInformation);
                return this.screenshotConverter.GetScreenshotAsBase64(bitmap, ScreenshotOptions.MaxWidth,
                    ScreenshotOptions.MaxHeight);
            });
        }

        public Task<Bitmap> GetScreenshotAsync(string target)
        {
            return Task.Factory.StartNew(() =>
            {
                Bitmap bitmap = this.screenshot.GetPrimaryScreen();
                return bitmap;
            });
        }

        public Task<Bitmap> GetScreenshotAsync(string target, ScreenInformation screenInformation)
        {
            return Task.Factory.StartNew(() =>
            {
                Bitmap bitmap = this.screenshot.GetScreen(screenInformation);
                return bitmap;
            });
        }
    }
}
