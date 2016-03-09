using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

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

                public OpenProjectPanel(List<object> projectsName)
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

                        _leaveButton = new StackPanel();
                        TextBlock leaveBlock = new TextBlock();
                        leaveBlock.Text = "Just leave";
                        _leaveButton.Children.Add(leaveBlock);

                       

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

        }///class OpenProjectPanel
}//ns
