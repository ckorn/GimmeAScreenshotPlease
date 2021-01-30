using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Serialization.Contract
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
    }
}
