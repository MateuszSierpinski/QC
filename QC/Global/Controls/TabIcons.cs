using QC.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    public static class TabIcons
    {
        static TabIcons()
        {
            ImageList = new ImageList();
            LoadImages(ImageList);
        }

        private static void LoadImages(ImageList imageList)
        {
            imageList.Images.Add(Resources.toppng_com_red_x_red_x_2000x2000);
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(10,10);
        }

        public static ImageList ImageList { get; private set; }

    }
}

