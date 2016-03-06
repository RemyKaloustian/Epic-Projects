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
                public abstract SolidColorBrush GetBackground();

                public abstract SolidColorBrush GetAccentColor();

                public abstract FontFamily GetTitleFont();

                public abstract  FontFamily GetTextFont();
        }//class Theme
}//ns
