using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EpicProjects.View.CustomControls.Home
{
        public class OpenProjectPanel : StackPanel
        { 
                public ScrollViewer _navigationPanel { get; set; }
                public StackPanel _projectsListPanel { get; set; }
                public StackPanel _projectsPanel { get; set; }
               

                public StackPanel _actionsPanel { get; set; }

                public StackPanel _openButton { get; set; }
                public StackPanel _deleteButton{ get; set; }
                public StackPanel _renameButton{ get; set; }

                public CustomButton _leaveButton{ get; set; }

                public OpenProjectPanel(List<object> projectsName, Theme.Theme theme, double width)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _projectsListPanel = new StackPanel();
                        _projectsListPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                        _navigationPanel = new ScrollViewer();

                        _projectsPanel = new StackPanel();
                        _projectsPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                        foreach (var item in projectsName)
                        {
                                TextBlock block = new TextBlock();
                                block.Text = item.ToString();
                                _projectsPanel.Children.Add(block);
                        }

                        _navigationPanel = new ScrollViewer();
                        _navigationPanel.Content = _projectsPanel;

                        SetUpLeaveButton(theme, width);


                       

                        _actionsPanel = new StackPanel();
                        _actionsPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                        _openButton = new ValidateButton(ControlsValues.OPEN,width/5,width/30, new System.Windows.Thickness(0,width/50 ,0,0), new System.Windows.Thickness(0,width/200,0,0),System.Windows.HorizontalAlignment.Center,theme);
                       

                        _deleteButton = new   CancelButton(ControlsValues.DELETE,width/5,width/30, new System.Windows.Thickness(0,width/70 ,0,0), new System.Windows.Thickness(0,width/200,0,0),System.Windows.HorizontalAlignment.Center,theme);


                        _renameButton = new AlternativeButton(ControlsValues.RENAME, width / 5, width / 30, new System.Windows.Thickness(0, width / 70, 0, 0), new System.Windows.Thickness(0, width / 200, 0, 0), System.Windows.HorizontalAlignment.Center, theme);
                     

                        _actionsPanel.Children.Add(_openButton);
                        _actionsPanel.Children.Add(_deleteButton);
                        _actionsPanel.Children.Add(_renameButton);
                        _actionsPanel.Margin = new System.Windows.Thickness(width / 20, 0, 0, 0);

                        _projectsListPanel.Children.Add(_navigationPanel);
                        _projectsListPanel.Children.Add(_leaveButton);

                        this.Children.Add(_projectsListPanel);
                        this.Children.Add(_actionsPanel);

                       
                }

                private void SetUpLeaveButton(Theme.Theme theme, double width)
                {
                        _leaveButton = new CancelButton(ControlsValues.LEAVE,width/2, width/30, new System.Windows.Thickness(0,width/50,0,0), new System.Windows.Thickness(0,width/200,0,0), System.Windows.HorizontalAlignment.Center, theme);
                        

                       




                        _leaveButton.MouseEnter += _leaveButton_MouseEnter;
                        _leaveButton.MouseLeave += _leaveButton_MouseLeave;
                }

                void _leaveButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        
                }

                void _leaveButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                                        }

        }///class OpenProjectPanel
}//ns
