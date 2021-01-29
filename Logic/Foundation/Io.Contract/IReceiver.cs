using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Io.Contract
{
    public interface IReceiver
    {
        void Start(string name, Func<string, string> onReceive);
    }
}
