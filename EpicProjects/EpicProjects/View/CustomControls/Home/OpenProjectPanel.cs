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

                public StackPanel _leaveButton{ get; set; }

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

                        _openButton = new StackPanel();
                        TextBlock openBlock = new TextBlock();
                        openBlock.Text = "Open";
                        _openButton.Children.Add(openBlock);

                        _deleteButton = new StackPanel();
                        TextBlock deleteBlock = new TextBlock();
                        deleteBlock.Text = "Delete";
                        _deleteButton.Children.Add(deleteBlock);


                        _renameButton = new StackPanel();
                        TextBlock renameBlock = new TextBlock();
                        renameBlock.Text = "Rename";
                        _renameButton.Children.Add(renameBlock);

                        _actionsPanel.Children.Add(_openButton);
                        _actionsPanel.Children.Add(_deleteButton);
                        _actionsPanel.Children.Add(_renameButton);

                        _projectsListPanel.Children.Add(_navigationPanel);
                        _projectsListPanel.Children.Add(_leaveButton);

                        this.Children.Add(_projectsListPanel);
                        this.Children.Add(_actionsPanel);

                       
                }

                private void SetUpLeaveButton(Theme.Theme theme, double width)
                {
                        _leaveButton = new StackPanel();
                        TextBlock leaveBlock = new TextBlock();
                        leaveBlock.Text = "Just leave";
                        _leaveButton.Children.Add(leaveBlock);

                        leaveBlock.FontSize = 25;
                        leaveBlock.FontFamily = new FontFamily("Lato Light");
                        leaveBlock.Foreground = theme.GetAccentColor();
                        leaveBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        leaveBlock.Margin = new System.Windows.Thickness(0, width / 200, 0, 0);



                        _leaveButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _leaveButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL));
                        _leaveButton.Margin = new System.Windows.Thickness(0, width / 50, 0, 0);
                        _leaveButton.Width = width / 2;
                        _leaveButton.Height = width / 30;

                        _leaveButton.MouseEnter += _leaveButton_MouseEnter;
                        _leaveButton.MouseLeave += _leaveButton_MouseLeave;
                }

                void _leaveButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _leaveButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL));
                }

                void _leaveButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        _leaveButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL_HOVER  ));
                }

        }///class OpenProjectPanel
}//ns
