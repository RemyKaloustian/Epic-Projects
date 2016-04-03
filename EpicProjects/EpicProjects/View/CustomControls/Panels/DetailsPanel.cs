using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class DetailsPanel : StackPanel
        {
                public DetailsPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.3;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = Palette2.GetColor(Palette2.NEPHRITIS);
                }
        }//class DetailsPanel()
}
