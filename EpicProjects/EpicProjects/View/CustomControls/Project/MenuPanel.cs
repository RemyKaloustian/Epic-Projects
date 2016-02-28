using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpicProjects.View.CustomControls.Project
{
        class MenuPanel : StackPanel
        {

                public MenuItem _brainStorming { get; set; }
                public MenuItem _formations { get; set; }
                public MenuItem _tasks { get; set; }
                public MenuItem _maintenance { get; set; }

                public MenuPanel(double widthAv)
                {
                        this.Orientation = Orientation.Horizontal;
                        this.Background = new SolidColorBrush(Colors.Cyan);
                        this.Height = 50;

                        _brainStorming = new MenuItem("Brainstorming");
                        _brainStorming.Width = widthAv / 4;
                        _formations = new MenuItem("Formations");
                        _formations.Width = widthAv / 4;
                        _tasks = new MenuItem("Tasks");
                        _tasks.Width = widthAv / 4;
                        _maintenance = new MenuItem("Maintenance");
                        _maintenance.Width = widthAv / 4;


                        this.Children.Add(_brainStorming);
                        this.Children.Add(_formations);
                        this.Children.Add(_tasks);
                        this.Children.Add(_maintenance);

                }
        }
}
