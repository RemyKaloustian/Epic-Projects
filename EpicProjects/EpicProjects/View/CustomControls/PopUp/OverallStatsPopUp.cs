using EpicProjects.Constants;
using EpicProjects.Database;
using EpicProjects.Model;
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
                public int _projectsNB{ get; set; }
                public int _projectsIPNB{ get; set; }
                public int _projectsDNB{ get; set; }

                public StackPanel _projectsPanel { get; set; }
                public TextBlock _projectsNumber { get; set; }
                public TextBlock _projects { get; set; }

                public StackPanel _projectsIPPanel { get; set; }
                public TextBlock _projectsIPNumber { get; set; }
                public TextBlock _projectsIP { get; set; }

                public StackPanel _projectsDPanel { get; set; }
                public TextBlock _projectsDNumber { get; set; }
                public TextBlock _projectsD { get; set; }

                public List<string> _projectsList { get; set; }


                public OverallStatsPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        _projectsNB = 0;
                        _projectsIPNB = 0;
                        _projectsDNB = 0;

                        SetUpProjectsPanel();
                        SetUpProjectsIPPanel();
                        SetUpDPanel();

                        _container.Children.Add(_projectsPanel);
                        _container.Children.Add(_projectsIPPanel);
                        _container.Children.Add(_projectsDPanel);

                }

                private void SetUpDPanel()
                {
                        _projectsDPanel = new StackPanel();
                        _projectsDPanel.Orientation = Orientation.Horizontal;

                        _projectsDNumber = new TextBlock();
                        _projectsDNumber.Text = _projectsDNB.ToString();

                        _projectsD = new TextBlock();
                        _projectsD.Text = " projects finished.";

                        _projectsDPanel.Children.Add(_projectsDNumber);
                        _projectsDPanel.Children.Add(_projectsD);
                }

                private void SetUpProjectsIPPanel()
                {
                        _projectsIPPanel = new StackPanel();
                        _projectsIPPanel.Orientation = Orientation.Horizontal;

                        _projectsIPNumber = new TextBlock();
                        _projectsIPNumber.Text = GetProjectsIP().ToString();
                        _projectsIP = new TextBlock();
                        _projectsIP.Text = " projects in progress.";

                        _projectsIPPanel.Children.Add(_projectsIPNumber);
                        _projectsIPPanel.Children.Add(_projectsIP);
                }

                private int GetProjectsIP()
                {
                        return _projectsNB - GetProjectsD();
                }

                private int GetProjectsD()
                {
                        foreach (string project in _projectsList)
                        {
                                bool isFinished = true;
                                List<AdvancedTask> workinList = new Selector(Paths.PROJECTS_SAVE).SelectTrainings(project);

                                foreach (AdvancedTask item in workinList)
                                {
                                        if(item._state == States.OPEN || item._state == States.PROGRESS)
                                        {
                                                isFinished = false;
                                                break;
                                        }
                                }

                                if(isFinished)
                                {
                                        workinList = new Selector(Paths.PROJECTS_SAVE).SelectAssignments(project);

                                        foreach (AdvancedTask item in workinList)
                                        {
                                                if (item._state == States.OPEN || item._state == States.PROGRESS)
                                                {
                                                        isFinished = false;
                                                        break;
                                                }
                                        }
                                }

                                if (isFinished)
                                {
                                        workinList = new Selector(Paths.PROJECTS_SAVE).SelectMaintenances(project);

                                        foreach (AdvancedTask item in workinList)
                                        {
                                                if (item._state == States.OPEN || item._state == States.PROGRESS)
                                                {
                                                        isFinished = false;
                                                        break;
                                                }
                                        }
                                }

                                if(isFinished)
                                {
                                        _projectsDNB++;
                                }
                        }

                        return _projectsDNB;
                }//ctor()

                private void SetUpProjectsPanel()
                {
                        _projectsPanel = new StackPanel();
                        _projectsPanel.Orientation = Orientation.Horizontal;

                        _projectsList = new Selector(Paths.PROJECTS_SAVE).SelectProjects();
                        _projects = new TextBlock();

                        _projectsNB = _projectsList.Count;
                        _projectsNumber = new TextBlock();
                        _projectsNumber.Text = _projectsNB.ToString();
                        _projects.Text = " projects.";

                        _projectsPanel.Children.Add(_projectsNumber);
                        _projectsPanel.Children.Add(_projects);
                }//SetUpProjectsPanel()
        }//class OverallStatsPopUp()
}//ns
