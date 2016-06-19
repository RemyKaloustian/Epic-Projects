using EpicProjects.Constants;
using EpicProjects.Database;
using EpicProjects.Model;
using EpicProjects.Stats;
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
                public StackPanel _trainingsPanel{ get; set; }
                public StackPanel _trainingsGraph{ get; set; }

                public ProjectStatsPopUp(double width, double height, string content, string project)
                        : base(width, height, content)
                {
                        _separator = new Separator();
                        _separator.Width = this.Width * 0.6;
                        _separator.Background = Palette2.GetColor(Palette2.THIN_GRAY);


                        _brainstormingsPanel = new StatsPanel(new Selector("tamaire").SelectBrainstormings(project).Count.ToString(), "  Brainstormings");

                        Ratio trainingsRatio = new StatsWarrior().GetTrainingsRatio(project);

                        _trainingsPanel = new StatsPanel(
                                trainingsRatio.GetPercentage().ToString(),
                                " %  of trainings done (" + trainingsRatio.ToString() + ")");

                        _trainingsGraph = new GraphPanel(this.Width, trainingsRatio._done, trainingsRatio._todo);


                        _container.Children.Add(_separator);
                        _container.Children.Add(_brainstormingsPanel);
                        _container.Children.Add(_trainingsPanel);
                        _container.Children.Add(_trainingsGraph);
                }
        }//class ProjectsStatsPopUp
}//ns
