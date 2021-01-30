using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Encodings.Contract
{
    public interface IBinaryDecoder
    {
        byte[] DecodePlainText(string text);
    }
}
