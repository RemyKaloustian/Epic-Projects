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

                public StackPanel _assignmentsPanel{ get; set; }
                public StackPanel _assignmentsGraph{ get; set; }

                public StackPanel _maintenacePanel { get; set; }
                public StackPanel _maintenaceGraph { get; set; }

                public StackPanel _projectPanel{ get; set; }
                public StackPanel _projectGraph { get; set; }


                public ProjectStatsPopUp(double width, double height, string content, string project)
                        : base(width, height, content)
                {
                        _separator = new Separator();
                        _separator.Width = this.Width * 0.6;
                        _separator.Background = Palette2.GetColor(Palette2.THIN_GRAY);


                        _brainstormingsPanel = new StatsPanel(new Selector(Constants.DatabaseValues.PROJECT_PATH).SelectBrainstormings(project).Count.ToString(), "  Brainstormings");

                        Ratio trainingsRatio = new StatsWarrior().GetTrainingsRatio(project);
                    
                        _trainingsPanel = new StatsPanel(
                                trainingsRatio.GetPercentage().ToString(),
                                " %  of trainings done (" + trainingsRatio.ToString() + ")");

                        _trainingsGraph = new GraphPanel(this.Width, trainingsRatio._done, trainingsRatio._todo);

                        Ratio assignmentsRatio = new StatsWarrior().GetAssignmentsRatio(project);

                        _assignmentsPanel = new StatsPanel(assignmentsRatio.GetPercentage().ToString("f0"),
                                " % of assignments done (" + assignmentsRatio.ToString() + ")");

                        _assignmentsGraph = new GraphPanel(this.Width, assignmentsRatio._done, assignmentsRatio._todo);

                        Ratio maintenanceRatio = new StatsWarrior().GetMaintenancesRatio(project);

                        _maintenacePanel = new StatsPanel(maintenanceRatio.GetPercentage().ToString("f0"),
                                                        " % of maintenance done (" + maintenanceRatio.ToString() + ")");

                        _maintenaceGraph = new GraphPanel(this.Width, maintenanceRatio._done, maintenanceRatio._todo);

                        Ratio projectRatio = new StatsWarrior().GetAdvancedTasksRatio(project);

                        _projectPanel = new StatsPanel(projectRatio.GetPercentage().ToString("f0"),
                                " % of " + project + " finished");

                        _projectGraph = new GraphPanel(this.Width, projectRatio._done, projectRatio._todo);

                        _container.Children.Add(_separator);
                        _container.Children.Add(_brainstormingsPanel);
                        _container.Children.Add(_trainingsPanel);
                        _container.Children.Add(_trainingsGraph);
                        _container.Children.Add(_assignmentsPanel);
                        _container.Children.Add(_assignmentsGraph);
                        _container.Children.Add(_maintenacePanel);
                        _container.Children.Add(_maintenaceGraph);
                        _container.Children.Add(_projectPanel);
                        _container.Children.Add(_projectGraph);

                }
        }//class ProjectsStatsPopUp
}//ns
