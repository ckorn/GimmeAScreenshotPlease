﻿using Logic.Foundation.Io.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Io
{
    public class NamedPipeSender : ISender
    {
        public string Send(string target, string name, string text)
        {
            NamedPipeClientStream pipeClient = new NamedPipeClientStream(target, name);
            pipeClient.Connect();
            StreamReader reader = new StreamReader(pipeClient);
            StreamWriter writer = new StreamWriter(pipeClient);

            writer.WriteLine(text);
            writer.Flush();

            return reader.ReadLine();
        }

        public Task<string> SendAsync(string target, string name, string text)
        {
            throw new NotImplementedException();
        }
    }
}
