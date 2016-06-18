using EpicProjects.Constants;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Blocks
{
        public class NumberBlock : TextBlock
        {
                public NumberBlock()
                {
                        this.FontSize = Responsive.GetNumberSize();
                        this.FontFamily = FontProvider._lato;
                        this.Foreground = Palette2.GetColor(Palette2.THIN_GRAY);
                        this.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

        }//class NumberBlock
}//ns
