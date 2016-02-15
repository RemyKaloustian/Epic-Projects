using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using EpicProjects.Model;
using EpicProjects.Constants;

namespace EpicProjects.View
{
        /// <summary>
        /// Interaction logic for ProjectWindow.xaml
        /// </summary>
        public partial class ProjectWindow : Window
        {
                public Project _project { get; set; }

                public TextBlock _nameBlock { get; set; }
                public TextBlock _startBlock { get; set; }
                public TextBlock _startDate { get; set; }

                public TextBlock _endBlock { get; set; }
                public TextBlock _endDate { get; set; }

                public Button _formationsButton { get; set; }
                public Button _tasksButton { get; set; }
                public Button _maintenanceButton { get; set; }

                public StackPanel _headerButtons { get; set; }

                public TextBlock _assignments  { get; set; }

                public ProjectWindow(string name)
                {
                        InitializeComponent();

                        _project = new Project(name);                        

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = _project._name;
                        _nameBlock.FontSize = 30;

                        _startBlock = new TextBlock();
                        _startBlock.Text = "Commence le ";
                        _startDate = new TextBlock();
                        _startDate.Text = _project._startDate;

                        _endBlock = new TextBlock();
                        _endBlock.Text = "S'arrete le";
                        _endDate = new TextBlock();
                        _endDate.Text = _project._endDate;

                        StackPanel panel = new StackPanel();
                        panel.Orientation = Orientation.Vertical;

                        panel.Children.Add(_nameBlock);
                        panel.Children.Add(_startBlock);
                        panel.Children.Add(_startDate);
                        panel.Children.Add(_endBlock);
                        panel.Children.Add(_endDate);



                        _headerButtons = new StackPanel();
                        _headerButtons.Orientation = Orientation.Horizontal;

                        _formationsButton = new Button();
                        _formationsButton.Content = ControlsValues.FORMATIONS;
                        _formationsButton.Click += _formationsButton_Click;

                        _tasksButton = new Button();
                        _tasksButton.Content = ControlsValues.TASKS;
                        _tasksButton.Click += _tasksButton_Click;

                        _maintenanceButton = new Button();
                        _maintenanceButton.Content = ControlsValues.MAINTENANCE;
                        _maintenanceButton.Click += _maintenanceButton_Click;

                        _headerButtons.Children.Add(_formationsButton);
                        _headerButtons.Children.Add(_tasksButton);
                        _headerButtons.Children.Add(_maintenanceButton);

                         _assignments = new TextBlock();

                         StackPanel greatStackPanel = new StackPanel();
                         greatStackPanel.Orientation = Orientation.Vertical;

                         greatStackPanel.Children.Add(panel);
                         greatStackPanel.Children.Add(_headerButtons);
                         greatStackPanel.Children.Add(_assignments);



                        ProjectGrid.Children.Add(greatStackPanel);
                        

                }

                void _maintenanceButton_Click(object sender, RoutedEventArgs e)
                {
                        _assignments.Inlines.Clear();
                        foreach (string item in _project._maintenances)
                        {
                                _assignments.Inlines.Add(item + "\n");
                        }
                }

                void _tasksButton_Click(object sender, RoutedEventArgs e)
                {
                        _assignments.Inlines.Clear();
                        foreach (string item in _project._tasks)
                        {
                                _assignments.Inlines.Add(item + "\n");
                        }
                }

                void _formationsButton_Click(object sender, RoutedEventArgs e)
                {
                        _assignments.Inlines.Clear();
                        foreach (string item in _project._formations)
                        {
                                _assignments.Inlines.Add(item + "\n");
                        }
                }//ProjetWindow()

        }//class ProjectWindow
}//ns
