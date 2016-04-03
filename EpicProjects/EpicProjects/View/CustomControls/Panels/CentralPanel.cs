using EpicProjects.Constants;
using EpicProjects.Controller;
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
                public HeaderPanel _headerPanel { get; set; }
                public ContentPanel _contentPanel { get; set; }

                public EventCoordinator _eventC { get; set; }

                public CentralPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.9;
                        this.Height = Dimensions.GetHeight();
                        this.Background = Palette2.GetColor(Palette2.LIGHT_GRAY);

                        _headerPanel = new HeaderPanel();
                        _contentPanel = new ContentPanel();

                        _eventC = new EventCoordinator(_headerPanel, _contentPanel);

                        this.Children.Add(_headerPanel);
                        this.Children.Add(_contentPanel);
                }
        }//class CentralPanel
}//ns
