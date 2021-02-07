using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.IoHttp
{
    public class AddressBuilder
    {
        public const int StartPort = 2413;
        private int currentPort = 0;

        public string GetUrl() 
        {
            if (currentPort == 0)
            {
                currentPort = StartPort;
            }
            else
            {
                currentPort++;
            }
            throw new NotImplementedException();
        }
    }
}
