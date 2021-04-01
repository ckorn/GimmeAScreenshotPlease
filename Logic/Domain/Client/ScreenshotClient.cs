using CrossCutting.DataClasses;
using Logic.Domain.Client.Contract;
using Logic.Foundation.Encodings.Contract;
using Logic.Foundation.Io.Contract;
using Logic.Foundation.Serialization.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Client
{
    public class ScreenshotClient : IScreenshotClient
    {
        private readonly ISender sender;
        private readonly IBinaryDecoder binaryDecoder;
        private readonly ISerializer serializer;
        private readonly IDeserializer deserializer;

        public ScreenshotClient(ISender sender, IBinaryDecoder binaryDecoder,
            ISerializer serializer, IDeserializer deserializer)
        {
            this.sender = sender;
            this.binaryDecoder = binaryDecoder;
            this.serializer = serializer;
            this.deserializer = deserializer;
        }

        public async Task<IReadOnlyList<ScreenInformation>> GetScreenInformationListAsync(string target)
        {
            string result = await this.sender.SendAsync(target,
                ConnectionSettings.ScreenListPipeName,
                "GimmeAScreenshotPlease");
            List<ScreenInformation> screenInformationList
                = this.deserializer.Deserialize<List<ScreenInformation>>(result);
            return screenInformationList;
        }

        public async Task<string> GetScreenshotAsBase64Async(string target, int? ratio)
        {
            return await this.sender.SendAsync(target, ConnectionSettings.PrimaryScreenPipeName,
                $"ratio={ratio}");
        }

        public async Task<string> GetScreenshotAsBase64Async(string target, ScreenInformation screenInformation)
        {
            string text = this.serializer.Serialize(screenInformation);
            string result = await this.sender.SendAsync(target,
                ConnectionSettings.ScreenPipeName, text);
            return result;
        }

        public async Task<Bitmap> GetScreenshotAsync(string target, int? ratio)
        {
            string result = await GetScreenshotAsBase64Async(target, ratio);
            Bitmap bitmap = GetBitmapFromResponse(result);
            return bitmap;
        }

        public async Task<Bitmap> GetScreenshotAsync(string target, ScreenInformation screenInformation)
        {
            string result = await GetScreenshotAsBase64Async(target, screenInformation);
            Bitmap bitmap = GetBitmapFromResponse(result);
            return bitmap;
        }

        private Bitmap GetBitmapFromResponse(string response) 
        {
            byte[] arr = this.binaryDecoder.DecodePlainText(response);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bitmap = new Bitmap(ms);

            return bitmap;
        }
    }
}
