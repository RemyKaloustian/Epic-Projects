using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class OptionsPanel : StackPanel
        {

                public TextBlock _sort { get; set; }
                public TextBlock  _show{ get; set; }
                public OptionsPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _sort = new TextBlock();
                        _sort.Text = "SORT MAH TASKS";

                        _show = new TextBlock();
                        _show.Text = "SHOW MAH DONE STUFF";

                        this.Children.Add(_sort);
                        this.Children.Add(_show);
                }

        }//class OptionsPanel
}//ns
