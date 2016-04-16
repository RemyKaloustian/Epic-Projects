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

                public List<ProjectItem> _projectItemList { get; set; }

                public OpenProjectPopUp(double width, double height, string content)
                        : base(width, height, content)
                {
                        _separator = new Separator();
                        _separator.Width = this.Width * 0.5;
                        _separator.Background = new Theme.CustomTheme().GetBackground();

                        _scroller = new ScrollViewer();


                        _projectsPanel = new StackPanel();
                        _projectsPanel.Orientation = Orientation.Vertical;
                        _projectsPanel.MinHeight = 400;

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

                        _container.Children.Add(_separator);
                        _container.Children.Add(_scroller);

                }

                void proj_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        foreach (ProjectItem item in _projectItemList)
                        {
                                if(item.IsMouseOver)
                                {
                                        item.Hover();
                                }

                                else
                                {
                                        item.Unhover();
                                }
                        }
                }
        }//class OpenProjectPopUp
}//ns
