using EpicProjects.Constants;
using EpicProjects.Controller;
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
                #region fields
                public Masterchief _chief { get; set; }


                public ScrollViewer _navigationPanel { get; set; }
                public StackPanel _projectsListPanel { get; set; }
                public StackPanel _projectsPanel { get; set; }

                public TextBlock _openBlock { get; set; }               

                public StackPanel _actionsPanel { get; set; }

                public StackPanel _openButton { get; set; }
                public StackPanel _deleteButton{ get; set; }
                public StackPanel _renameButton{ get; set; }

                public CustomButton _leaveButton{ get; set; }

                public ProjectBlock _selectedBlock { get; set; }

                public List<ProjectBlock> _blockList { get; set; }
                #endregion

                public OpenProjectPanel(List<object> projectsName, Theme.Theme theme, double width)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _chief = new Masterchief();

                        SetUpProjectsListPanel(width);
                        SetUpProjectsPanel();
                        SetUpOpenBlock(theme, width);
                        SetUpBlocks(projectsName, theme, width);
                        SetUpNavigationPanel(width);
                        SetUpLeaveButton(theme, width);
                        SetUpActionsPanel(theme, width);

                        AddControls();                       
                }

                private void AddControls()
                {
                        _projectsListPanel.Children.Add(_openBlock);
                        _projectsListPanel.Children.Add(_navigationPanel);
                        _projectsListPanel.Children.Add(_leaveButton);

                        this.Children.Add(_projectsListPanel);
                        this.Children.Add(_actionsPanel);
                }

                private void SetUpActionsPanel(Theme.Theme theme, double width)
                {
                        _actionsPanel = new StackPanel();
                        _actionsPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                        SetUpOpenButton(theme, width);
                        SetUpDeleteButton(theme, width);
                        SetUpRenameButton(theme, width);

                        _actionsPanel.Children.Add(_openButton);
                        _actionsPanel.Children.Add(_deleteButton);
                        _actionsPanel.Children.Add(_renameButton);
                        _actionsPanel.Margin = new System.Windows.Thickness(width / 20, 0, 0, 0);
                }

                private void SetUpRenameButton(Theme.Theme theme, double width)
                {
                        _renameButton = new AlternativeButton(ControlsValues.RENAME, width / 5, width / 30, new System.Windows.Thickness(0, width / 70, 0, 0), new System.Windows.Thickness(0, width / 200, 0, 0), System.Windows.HorizontalAlignment.Center, theme);
                }

                private void SetUpDeleteButton(Theme.Theme theme, double width)
                {
                        _deleteButton = new CancelButton(ControlsValues.DELETE, width / 5, width / 30, new System.Windows.Thickness(0, width / 70, 0, 0), new System.Windows.Thickness(0, width / 200, 0, 0), System.Windows.HorizontalAlignment.Center, theme);

                        _deleteButton.MouseDown += _deleteButton_MouseDown;
                }

                void _deleteButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_selectedBlock != null)
                        {
                                _chief.Delete(_selectedBlock._block.Text.ToString(), DatabaseValues.PROJECT);
                        }
                }

                private void SetUpOpenButton(Theme.Theme theme, double width)
                {
                        _openButton = new ValidateButton(ControlsValues.OPEN, width / 5, width / 30, new System.Windows.Thickness(0, width / 50, 0, 0), new System.Windows.Thickness(0, width / 200, 0, 0), System.Windows.HorizontalAlignment.Center, theme);
                        _openButton.MouseDown += _openButton_MouseDown;
                }

                private void SetUpNavigationPanel(double width)
                {
                        _navigationPanel = new ScrollViewer();
                        _navigationPanel.Content = _projectsPanel;
                        _navigationPanel.Height = width / 10;
                }

                private void SetUpBlocks(List<object> projectsName, Theme.Theme theme, double width)
                {

                        _blockList = new List<ProjectBlock>();
                        foreach (var item in projectsName)
                        {
                                ProjectBlock block = new ProjectBlock(item.ToString(), _projectsListPanel.Width, width / 50, theme);

                                block.MouseDown += block_MouseDown;

                                _blockList.Add(block);

                                _projectsPanel.Children.Add(block);
                        }
                }

                private void SetUpOpenBlock(Theme.Theme theme, double width)
                {
                        _openBlock = new TextBlock();
                        _openBlock.Text = ControlsValues.OPEN_PROJECT_TITLE;
                        _openBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _openBlock.FontFamily = new FontFamily("Edmondsans Regular");
                        _openBlock.FontSize = 30;
                        _openBlock.Foreground = theme.GetAccentColor();
                        _openBlock.Margin = new System.Windows.Thickness(0, 0, 0, width / 30);
                }

                private void SetUpProjectsPanel()
                {
                        _projectsPanel = new StackPanel();
                        _projectsPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                }

                private void SetUpProjectsListPanel(double width)
                {
                        _projectsListPanel = new StackPanel();
                        _projectsListPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                        _projectsListPanel.Margin = new System.Windows.Thickness(width / 50);
                }

                void _openButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                       if(_selectedBlock != null)
                       {
                               Captain oCaptain = new Captain();
                               oCaptain.ToProject(_selectedBlock._block.Text);
                       }
                }

                void block_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        foreach (ProjectBlock item in _blockList)
                        {
                                item.GetUnselected();
                        }

                         _selectedBlock = (ProjectBlock)sender;
                        _selectedBlock.GetSelected();
                       
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
