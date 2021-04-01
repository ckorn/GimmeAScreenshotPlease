using CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Business.ScreenshotClientWorkflow.Contract
{
    public interface IClientWorkflow
    {
        Task<Bitmap> GetScreenshotPrimaryScreenAsync(string target, int? ratio);
        Task<Bitmap> GetScreenshotForScreenAsync(string target, ScreenInformation screenInformation);
        Task<string> GetScreenshotPrimaryScreenAsBase64Async(string target, int? ratio);
        Task<string> GetScreenshotForScreenAsBase64Async(string target, ScreenInformation screenInformation);
        Task<IReadOnlyList<ScreenInformation>> GetScreenInformationListAsync(string target);
    }
}
