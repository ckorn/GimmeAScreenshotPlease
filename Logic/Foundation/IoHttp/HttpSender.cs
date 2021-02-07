﻿using Logic.Foundation.Io.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.IoHttp
{
    public class HttpSender : ISender
    {
        public string Send(string target, string name, string text)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                MemoryStream memoryStream = new MemoryStream();
                StreamWriter request = new StreamWriter(memoryStream);
                request.Write(text);
                request.Flush();
                memoryStream.Position = 0;
                StreamContent content = new StreamContent(memoryStream);

                HttpResponseMessage resp = null;
                Task.Run(async () => resp = await httpClient.PostAsync($"http://{target}:{HttpServer.Port}/{name}/", content)).Wait();

                if (resp.IsSuccessStatusCode)
                {
                    string respons = "";
                    Task.Run(async () => respons = await resp.Content.ReadAsStringAsync()).Wait();
                    return respons;
                }
                return null;
            }
        }
    }
}
