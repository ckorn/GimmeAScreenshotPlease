using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Serialization.Contract
{
    public interface IDeserializer
    {
        T Deserialize<T>(string text) where T : new();
    }
}
