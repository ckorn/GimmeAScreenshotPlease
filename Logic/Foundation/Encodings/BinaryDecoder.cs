using Logic.Foundation.Encodings.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Encodings
{
    public class BinaryDecoder : IBinaryDecoder
    {
        public byte[] DecodePlainText(string text)
        {
            byte[] arr = Convert.FromBase64String(text);
            return arr;
        }
    }
}
