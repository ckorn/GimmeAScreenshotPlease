using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.IoHttp
{
    public class HttpServer
    {
        public const int Port = 2413;

        private readonly HttpListener httpListener;
        private Dictionary<string, Func<string, string>> prefixCallbackDictionary = new Dictionary<string, Func<string, string>>();

        public HttpServer()
        {
            this.httpListener = new HttpListener();
        }

        private void StartListen() 
        {
            if (!this.httpListener.IsListening)
            {
                this.httpListener.Start();
            }
        }

        public void AddEndpoint(string name, Func<string, string> onReceive) 
        {
            //if (this.httpListener.IsListening)
            //{
            //    this.httpListener.Stop();
            //}
            lock (prefixCallbackDictionary)
            {
                this.httpListener.Prefixes.Add($"http://*:{Port}/{name}/");
                prefixCallbackDictionary[name] = onReceive;
                StartListen(); 
            }
            while (true)
            {
                HttpListenerContext context = this.httpListener.GetContext();
                string prefix = context.Request.Url.Segments.Last();
                Stream body = context.Request.InputStream;
                Encoding encoding = context.Request.ContentEncoding;
                StreamReader reader = new StreamReader(body, encoding);
                string input = reader.ReadToEnd();
                body.Close();

                string response = this.prefixCallbackDictionary[prefix](input);
                byte[] buffer = Encoding.UTF8.GetBytes(response);
                context.Response.ContentLength64 = buffer.Length;
                Stream output = context.Response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}
