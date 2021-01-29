using Logic.Foundation.Io.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Io
{
    public class NamedPipeReceiver : IReceiver
    {
        public void Start(string name, Func<string, string> onReceive)
        {
            while (true)
            {
                using (NamedPipeServerStream server = new NamedPipeServerStream(name))
                {
                    server.WaitForConnection();
                    using (StreamWriter writer = new StreamWriter(server))
                    {
                        StreamReader reader = new StreamReader(server);
                        var line = reader.ReadLine();
                        string send = onReceive?.Invoke(line);
                        writer.WriteLine(send);
                        writer.Flush();
                    }
                }
            }
        }
    }
}
