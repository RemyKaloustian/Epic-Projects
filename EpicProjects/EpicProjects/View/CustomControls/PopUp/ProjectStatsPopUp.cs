using EpicProjects.Constants;
using EpicProjects.Database;
using EpicProjects.View.CustomControls.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        class ProjectStatsPopUp:PopUp
        {
                public Separator _separator { get; set; }

                public StackPanel _brainstormingsPanel { get; set; }

                public ProjectStatsPopUp(double width, double height, string content, string project)
                        : base(width, height, content)
                {
                        _separator = new Separator();
                        _separator.Width = this.Width * 0.6;
                        _separator.Background = Palette2.GetColor(Palette2.THIN_GRAY);


                        _brainstormingsPanel = new StatsPanel(new Selector("tamaire").SelectBrainstormings(project).Count.ToString(), "  Brainstormings");


                        _container.Children.Add(_separator);
                        _container.Children.Add(_brainstormingsPanel);
                }
        }//class ProjectsStatsPopUp
}//ns
