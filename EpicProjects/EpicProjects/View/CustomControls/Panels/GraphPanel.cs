using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class GraphPanel : StackPanel
        {
                public StackPanel _donePanel{ get; set; }
                public StackPanel _undonePanel { get; set; }

                public GraphPanel(double totalWidth, double done, double todo)
                {

                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.Width = totalWidth;
                        this.Height = 50;
                        this.Margin = new System.Windows.Thickness(10, 0, 10, 0);

                        _donePanel = new StackPanel();
                        _donePanel.Width = done / todo * this.Width;
                        _donePanel.Height = 50;
                        _donePanel.Background = Palette2.GetColor(Palette2.EMERALD);

                        _undonePanel = new StackPanel();
                        _undonePanel.Width = (todo - done) / todo * this.Width;
                        _undonePanel.Height = 100;
                        _undonePanel.Background = Palette2.GetColor(Palette2.ALIZARIN);

                        this.Children.Add(_donePanel);
                        this.Children.Add(_undonePanel);
                }//ctor

        }//class GraphPanel
}//ns
