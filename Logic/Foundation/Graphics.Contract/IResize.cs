using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Foundation.Graphics.Contract
{
    public interface IResize
    {
        Bitmap ResizeImage(Image image, int maxWidth, int maxHeight);
    }
}
