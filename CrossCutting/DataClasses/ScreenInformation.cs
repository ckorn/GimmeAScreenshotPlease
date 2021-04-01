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
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Ratio { get; set; }

        public ScreenInformation()
        {

        }

        public ScreenInformation(int index, string name, int width, int height, int x, int y)
        {
            Index = index;
            Name = name;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }
    }
}
