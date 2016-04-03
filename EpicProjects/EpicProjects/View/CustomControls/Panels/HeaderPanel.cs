using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class HeaderPanel : StackPanel
        {
                public StackPanel _titlesPanel { get; set; }
                public StackPanel _plusPanel { get; set; }

                public HeaderPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.9;
                        //this.Height = Dimensions.GetHeight() * 0.2;

                        _titlesPanel = new TitlesPanel();

                        this.Children.Add(_titlesPanel);
                }
        }//class HeaderPanel
}//ns
