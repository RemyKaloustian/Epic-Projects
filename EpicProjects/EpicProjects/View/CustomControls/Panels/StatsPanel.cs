using EpicProjects.View.CustomControls.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class StatsPanel : StackPanel
        {
                public TextBlock _number{ get; set; }
                public TextBlock _text{ get; set; }

                public StatsPanel(string number, string text)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _number = new NumberBlock();
                        _number.Text = number;

                        _text = new StatsBlock();
                        _text.Text = text;
                        _text.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

                        this.Children.Add(_number);
                        this.Children.Add(_text);
                }//ctor

        }//class StatsPanel
}//ns
