using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Io.Contract
{
    public interface ISender
    {
        string Send(string target, string name, string text);
        Task<string> SendAsync(string target, string name, string text);
    }
}
