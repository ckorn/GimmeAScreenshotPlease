using CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Client.Contract
{
    public interface IScreenshotClient
    {
        Task<Bitmap> GetScreenshotAsync(string target);
        Task<Bitmap> GetScreenshotAsync(string target, ScreenInformation screenInformation);
        Task<string> GetScreenshotAsBase64Async(string target);
        Task<string> GetScreenshotAsBase64Async(string target, ScreenInformation screenInformation);
        Task<IReadOnlyList<ScreenInformation>> GetScreenInformationListAsync(string target);
    }
}
