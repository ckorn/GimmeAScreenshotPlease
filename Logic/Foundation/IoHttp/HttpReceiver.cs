using Logic.Foundation.Io.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.IoHttp
{
    public class HttpReceiver : IReceiver
    {
        private readonly HttpServer httpServer;

        public HttpReceiver(HttpServer httpServer)
        {
            this.httpServer = httpServer;
        }

        public void Start(string name, Func<string, string> onReceive)
        {
            this.httpServer.AddEndpoint(name, onReceive);
        }
    }
}
