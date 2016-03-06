using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpicProjects.View.Theme
{
        public abstract class Theme
        {
                public SolidColorBrush GetBackground();

                public SolidColorBrush GetAccentColor();

                public FontFamily GetTitleFont();

                public FontFamily GetTextFont();
        }//class Theme
}//ns
