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
                public TextBlock _name { get; set; }
                public TextBlock _details { get; set; }
                public TextBlock _priority{ get; set; }

                public DetailsPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _name = new TextBlock();
                        _details = new TextBlock();
                        _priority = new TextBlock();

                        this.Children.Add(_name);                        
                        this.Children.Add(_priority);
                        this.Children.Add(_details);
                }
        }//class DetailsPanel()
}
