using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class CentralPanel : StackPanel
        {
                public StackPanel _headerPanel { get; set; }

                public CentralPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.9;
                        this.Height = Dimensions.GetHeight();

                        _headerPanel = new HeaderPanel();

                        this.Children.Add(_headerPanel);
                }
        }//class CentralPanel
}//ns
