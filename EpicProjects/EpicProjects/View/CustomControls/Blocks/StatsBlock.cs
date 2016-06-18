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
        public class StatsBlock : TextBlock
        {
                public StatsBlock()
                {
                        this.FontFamily = FontProvider._lato;
                        this.FontSize = Responsive.GetPopUpTextSize();
                        this.Foreground = Palette2.GetColor(Palette2.THIN_GRAY);
                        

                }
        }//class StatsBlock
}//ns
