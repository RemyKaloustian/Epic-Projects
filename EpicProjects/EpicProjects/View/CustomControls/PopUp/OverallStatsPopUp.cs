using EpicProjects.Constants;
using EpicProjects.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class OverallStatsPopUp : PopUp
        {
                public StackPanel _projectsPanel { get; set; }
                public TextBlock _projectsNumber { get; set; }
                public TextBlock _projects { get; set; }

                public StackPanel _projectsIPPanel { get; set; }
                public TextBlock _projectsIPNumber { get; set; }
                public TextBlock _projectsIP { get; set; }

                public StackPanel _projectsDPanel { get; set; }
                public TextBlock _projectsDNumber { get; set; }
                public TextBlock _projectsD { get; set; }




                public OverallStatsPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        _projectsPanel = new StackPanel();
                        _projectsPanel.Orientation = Orientation.Horizontal;

                        _projectsNumber = new TextBlock();
                        _projectsNumber.Text = new Selector(Paths.PROJECTS_SAVE).SelectProjects().Count.ToString();
                        _projects = new TextBlock();
                        _projects.Text = " projects.";






                        _projectsPanel.Children.Add(_projectsNumber);
                        _projectsPanel.Children.Add(_projects);

                        _container.Children.Add(_projectsPanel);


                }//ctor()
        }//class OverallStatsPopUp()
}//ns
