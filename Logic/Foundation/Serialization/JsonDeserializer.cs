using Logic.Foundation.Serialization.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Serialization
{
    public class JsonDeserializer : IDeserializer
    {
        public T Deserialize<T>(string text) where T : new()
        {
            T obj = new T();
            Newtonsoft.Json.JsonConvert.PopulateObject(text, obj);
            return obj;
        }
    }
}
