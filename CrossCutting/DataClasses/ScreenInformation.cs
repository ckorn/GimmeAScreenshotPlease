using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DataClasses
{
    public class ScreenInformation
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public ScreenInformation()
        {

        }

        public ScreenInformation(int index, string name)
        {
            Index = index;
            Name = name;
        }
    }
}
