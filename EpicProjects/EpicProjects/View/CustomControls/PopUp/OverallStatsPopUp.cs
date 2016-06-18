using EpicProjects.Constants;
using EpicProjects.Database;
using EpicProjects.Model;
using EpicProjects.View.CustomControls.Blocks;
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
                public double _projectsNB{ get; set; }
                public double _projectsIPNB{ get; set; }
                public double _projectsDNB{ get; set; }

                public Separator _separator { get; set; }

                public StackPanel _projectsPanel { get; set; }
                public TextBlock _projectsNumber { get; set; }
                public TextBlock _projects { get; set; }

                public StackPanel _projectsIPPanel { get; set; }
                public TextBlock _projectsIPNumber { get; set; }
                public TextBlock _projectsIP { get; set; }

                public StackPanel _projectsDPanel { get; set; }
                public TextBlock _projectsDNumber { get; set; }
                public TextBlock _projectsD { get; set; }

                public StackPanel _percentagePanel{ get; set; }
                public TextBlock _percentageNB{ get; set; }
                public TextBlock  _percentageText{ get; set; }

                public StackPanel _graphPanel{ get; set; }
                public StackPanel _donePanel{ get; set; }
                public StackPanel _IPPanel{ get; set; }

                public List<string> _projectsList { get; set; }


                public OverallStatsPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        _projectsNB = 0;
                        _projectsIPNB = 0;
                        _projectsDNB = 0;

                        _separator = new Separator();
                        _separator.Width = this.Width * 0.6;
                        _separator.Background = Palette2.GetColor(Palette2.THIN_GRAY);

                        SetUpProjectsPanel();
                        SetUpProjectsIPPanel();
                        SetUpDPanel();

                        SetUpPercentagePanel();
                        SetUpGraphPanel();

                        _container.Children.Add(_separator);
                        _container.Children.Add(_projectsPanel);
                        _container.Children.Add(_projectsIPPanel);
                        _container.Children.Add(_projectsDPanel);
                        _container.Children.Add(_percentagePanel);
                        _container.Children.Add(_graphPanel);


                }

                private void SetUpGraphPanel()
                {
                        _graphPanel = new StackPanel();
                        _graphPanel.Orientation = Orientation.Horizontal;
                        _graphPanel.Height = 50;
                        _graphPanel.Margin = new System.Windows.Thickness(5, 0, 5, 0);

                        _donePanel = new StackPanel();
                        _donePanel.Width = this.Width * (_projectsDNB / _projectsNB);



                        //_donePanel.Width = 100;
                        _donePanel.Height = 50;
                        _donePanel.Background = Palette2.GetColor(Palette2.EMERALD);

                        _IPPanel = new StackPanel();
                        _IPPanel.Width = this.Width * (_projectsIPNB / _projectsNB);


                        //_IPPanel.Width = 100;
                        _IPPanel.Height = 50;
                        _IPPanel.Background = Palette2.GetColor(Palette2.ALIZARIN);

                        _graphPanel.Children.Add(_donePanel);
                        _graphPanel.Children.Add(_IPPanel);
                }

                private void SetUpPercentagePanel()
                {
                        _percentagePanel = new StackPanel();
                        _percentagePanel.Orientation = Orientation.Horizontal;
                        _percentagePanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _percentageNB = new NumberBlock();
                        _percentageNB.Text = Convert.ToInt64(_projectsDNB / _projectsNB * 100).ToString();


                        _percentageText = new StatsBlock();
                        _percentageText.Text = "% of finished projects (YAY ! ).";
                        _percentageText.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

                        _percentagePanel.Children.Add(_percentageNB);
                        _percentagePanel.Children.Add(_percentageText);
                }

                private void SetUpDPanel()
                {
                        _projectsDPanel = new StackPanel();
                        _projectsDPanel.Orientation = Orientation.Horizontal;
                        _projectsDPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _projectsDNumber = new NumberBlock();
                        _projectsDNumber.Text = _projectsDNB.ToString();

                        _projectsD = new StatsBlock();
                        _projectsD.Text = " projects finished.";
                        _projectsD.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

                        _projectsDPanel.Children.Add(_projectsDNumber);
                        _projectsDPanel.Children.Add(_projectsD);
                }

                private void SetUpProjectsIPPanel()
                {
                        _projectsIPPanel = new StackPanel();
                        _projectsIPPanel.Orientation = Orientation.Horizontal;
                        _projectsIPPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _projectsIPNumber = new NumberBlock();
                        _projectsIPNB = GetProjectsIP();
                        _projectsIPNumber.Text = _projectsIPNB.ToString();
                        _projectsIP = new StatsBlock();
                        _projectsIP.Text = " projects in progress.";
                        _projectsIP.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

                        _projectsIPPanel.Children.Add(_projectsIPNumber);
                        _projectsIPPanel.Children.Add(_projectsIP);
                }

                private double GetProjectsIP()
                {
                        return _projectsNB - GetProjectsD();
                }

                private double GetProjectsD()
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
                        _projectsPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _projectsList = new Selector(Paths.PROJECTS_SAVE).SelectProjects();
                        _projects = new StatsBlock();

                        _projectsNB = _projectsList.Count;
                        _projectsNumber = new NumberBlock();
                        _projectsNumber.Text = _projectsNB.ToString();
                        _projects.Text = " projects.";
                        _projects.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

                        _projectsPanel.Children.Add(_projectsNumber);
                        _projectsPanel.Children.Add(_projects);
                }//SetUpProjectsPanel()

        }//class OverallStatsPopUp()
}//ns
