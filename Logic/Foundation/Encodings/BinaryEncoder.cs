using Logic.Foundation.Encodings.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Encodings
{
    public class BinaryEncoder : IBinaryEncoder
    {
        public string GetAsPlainText(byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
    }
}
