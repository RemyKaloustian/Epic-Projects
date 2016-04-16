using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class OpenProjectPopUp : PopUp
        {
                public Separator _separator { get; set; }
                public ScrollViewer _scroller { get; set; }
                public StackPanel _projectsPanel { get; set; }

                public ValidateButton _openButton{ get; set; }
                public CancelButton _cancelButton { get; set; }

                public List<ProjectItem> _projectItemList { get; set; }
                public string  _selectedProject { get; set; }

                public OpenProjectPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        this.Background = Palette2.GetColor(Palette2.SILVER);

                        _separator = new Separator();
                        _separator.Width = this.Width * 0.5;
                        _separator.Background = new Theme.CustomTheme().GetBackground();

                        _scroller = new ScrollViewer();
                        _scroller.Height = this.Height*0.6;


                        _projectsPanel = new StackPanel();
                        _projectsPanel.Orientation = Orientation.Vertical;
                        _projectsPanel.Margin = new System.Windows.Thickness(0, 30, 0, 0);

                        _projectItemList = new List<ProjectItem>();

                        List<string> projects = new ProjectMasterChief().GetProjects();

                        foreach (var item in projects)
                        {
                                Constants.Debug.CW("project = " + item);
                                ProjectItem proj = new ProjectItem(this.Height * 0.05, item);
                                _projectItemList.Add(proj);
                                _projectsPanel.Children.Add(proj);
                                proj.MouseDown += proj_MouseDown;
                        }

                        _scroller.Content = _projectsPanel;



                        _openButton = new ValidateButton(ControlsValues.OPEN, this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 20, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _openButton.MouseDown += _openButton_MouseDown;
                        _openButton.IsEnabled = false;

                        _cancelButton = new CancelButton(ControlsValues.CLOSE, this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 14, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _cancelButton.MouseDown += _cancelButton_MouseDown;

                        _container.Children.Add(_separator);
                        _container.Children.Add(_scroller);

                        _container.Children.Add(_openButton);
                        _container.Children.Add(_cancelButton);

                }

                private void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }

                private void _openButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        new Captain().ToProject(_selectedProject);
                }

                void proj_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        foreach (ProjectItem item in _projectItemList)
                        {
                                if(item.IsMouseOver)
                                {
                                        item.Hover();
                                        _selectedProject = item._nameBlock.Text;
                                        _openButton.IsEnabled = true;
                                }

                                else
                                {
                                        item.Unhover();
                                }
                        }
                }
        }//class OpenProjectPopUp
}//ns
