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
using EpicProjects.Controller;
using EpicProjects.View.CustomControls;

namespace EpicProjects.View
{
        /// <summary>
        /// Interaction logic for ProjectWindow.xaml
        /// </summary>
        public partial class ProjectWindow : Window
        {
                public Project _project { get; set; }

                public string _currentAssignements { get; set; }

                public ProjectMasterChief _chief { get; set; }

                public TextBlock _nameBlock { get; set; }
                public TextBlock _startBlock { get; set; }
                public TextBlock _startDate { get; set; }

                public TextBlock _endBlock { get; set; }
                public TextBlock _endDate { get; set; }

                public Button _formationsButton { get; set; }
                public Button _tasksButton { get; set; }
                public Button _maintenanceButton { get; set; }
                public Button _newAssignment { get; set; }

                public StackPanel _headerButtons { get; set; }

                public StackPanel _greatPanel { get; set; }

                public StackPanel _newAssignmentPanel { get; set; }
                public TextBlock _assignementNameBlock { get; set; }
                public TextBox _assignmentName { get; set; }

                public TextBlock _assignmentDeadlineBlock { get; set; }
                public DatePicker _assignmentDeadline { get; set; }

                public ComboBox _typePicker { get; set; }
                public ComboBox  _priorityPicker { get; set; }

                public Button _createTask { get; set; }
                public Button _cancel { get; set; }


                public TextBlock _assignments  { get; set; }

                public StackPanel _assignmentsPanel { get; set; }

                public ProjectWindow(string name)
                {
                        InitializeComponent();
                        _chief = new ProjectMasterChief();
                        _currentAssignements = ModelConstants.FORMATION;
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

                        _newAssignment = new Button();
                        _newAssignment.Content = ControlsValues.NEWASSIGNMENT;
                        _newAssignment.Click += _newAssignment_Click;



                        _headerButtons.Children.Add(_formationsButton);
                        _headerButtons.Children.Add(_tasksButton);
                        _headerButtons.Children.Add(_maintenanceButton);
                        _headerButtons.Children.Add(_newAssignment);

                         _assignments = new TextBlock();

                         _assignmentsPanel = new StackPanel();
                         _assignmentsPanel.Orientation = Orientation.Vertical;

                          _greatPanel = new StackPanel();
                         _greatPanel.Orientation = Orientation.Vertical;

                         _greatPanel.Children.Add(panel);
                         _greatPanel.Children.Add(_headerButtons);
                         _greatPanel.Children.Add(_assignmentsPanel);



                        ProjectGrid.Children.Add(_greatPanel);

                        LoadFormationsOnUI();               

                }

                void _newAssignment_Click(object sender, RoutedEventArgs e)
                {
                        _greatPanel.Children.Remove(_assignments);
                        _greatPanel.Children.Remove(_assignmentsPanel);
                        BuildNewAssignmentPanel();
                        _greatPanel.Children.Add(_newAssignmentPanel);

                }

                public void BuildNewAssignmentPanel()
                {
                        _newAssignmentPanel = new StackPanel();
                        _newAssignmentPanel.Orientation = Orientation.Vertical;
                        _assignementNameBlock = new TextBlock();
                        _assignementNameBlock.Text = ControlsValues.NAME;

                        _assignmentName = new TextBox();

                        _assignmentDeadlineBlock = new TextBlock();
                        _assignmentDeadlineBlock.Text = ControlsValues.DEADLINE;

                        _assignmentDeadline = new DatePicker();

                        _typePicker = new ComboBox();

                        _typePicker.Items.Add(ControlsValues.FORMATION);
                        _typePicker.Items.Add(ControlsValues.TASK);
                        _typePicker.Items.Add(ControlsValues.MAINTENANCE);

                        _priorityPicker = new ComboBox();
                        _priorityPicker.Items.Add("1");
                        _priorityPicker.Items.Add("2");
                        _priorityPicker.Items.Add("3");
                        _priorityPicker.Items.Add("4");
                        _priorityPicker.Items.Add("5");

                        _createTask = new Button();
                        _createTask.Content = ControlsValues.CREATE;
                        _createTask.Click += _createTask_Click;

                        _cancel = new Button();
                        _cancel.Content = ControlsValues.QUIT;
                        _cancel.Click += _cancel_Click;
                        

                        _newAssignmentPanel.Children.Add(_assignementNameBlock);
                        _newAssignmentPanel.Children.Add(_assignmentName);
                        _newAssignmentPanel.Children.Add(_assignmentDeadlineBlock);
                        _newAssignmentPanel.Children.Add(_assignmentDeadline);
                        _newAssignmentPanel.Children.Add(_typePicker);
                        _newAssignmentPanel.Children.Add(_priorityPicker);
                        _newAssignmentPanel.Children.Add(_createTask);
                        _newAssignmentPanel.Children.Add(_cancel);

                        ShowDebugText();

                }

                private void ShowDebugText()
                {
                        _project.Reload();

                        DebugText.Inlines.Clear();

                        DebugText.Inlines.Add("Formations :  \n");

                        foreach (string item in _project._formations)
                        {
                                DebugText.Inlines.Add(item + "\n");
                        }

                        DebugText.Inlines.Add("---------------------\n\n");
                        DebugText.Inlines.Add("Tasks : \n");

                        foreach (string item in _project._tasks)
                        {
                                DebugText.Inlines.Add(item + "\n");
                        }

                        DebugText.Inlines.Add("---------------------\n\n");
                        DebugText.Inlines.Add("Maintenance :\n ");

                        foreach (string item in _project._maintenances)
                        {
                                DebugText.Inlines.Add(item + "\n");
                        }
                }

                void _cancel_Click(object sender, RoutedEventArgs e)
                {
                        _greatPanel.Children.Remove(_newAssignmentPanel);
                       // _greatPanel.Children.Add(_assignments);
                        _greatPanel.Children.Add(_assignmentsPanel);
                }

                void _createTask_Click(object sender, RoutedEventArgs e)
                {
                        string name = _assignmentName.Text;
                        string deadline = _assignmentDeadline.Text;
                        string type = _typePicker.Text;
                        int priority = Convert.ToInt32(_priorityPicker.Text);
                        int id = Convert.ToInt32(_project._id);
                        //string name, string deadline, string type, int priority, int projectid
                        //_chief.InsertTask(name, deadline, type, priority, id);

                        _greatPanel.Children.Remove(_newAssignmentPanel);
                        ReloadAssignments();
                        //_greatPanel.Children.Add(_assignments);
                        _greatPanel.Children.Add(_assignmentsPanel);
                        ShowDebugText();
                }

                private void ReloadAssignments()
                {
                        if (_currentAssignements == ModelConstants.FORMATION)
                                LoadFormationsOnUI();

                        else if (_currentAssignements == ModelConstants.MAINTENANCE)
                                LoadMaintenanceOnUI();

                        else if (_currentAssignements == ModelConstants.TASK)
                                LoadTasksOnUI();

                }

                void _maintenanceButton_Click(object sender, RoutedEventArgs e)
                {
                        _currentAssignements = ModelConstants.MAINTENANCE;
                        LoadMaintenanceOnUI();
                        Constants.Debug.CW("_currentAssignments : " + _currentAssignements);
                }

                void _tasksButton_Click(object sender, RoutedEventArgs e)
                {
                        _currentAssignements = ModelConstants.TASK;
                        LoadTasksOnUI();
                        Constants.Debug.CW("_currentAssignments : " + _currentAssignements);

                }

                void _formationsButton_Click(object sender, RoutedEventArgs e)
                {
                        _currentAssignements = ModelConstants.FORMATION;
                        LoadFormationsOnUI();
                        Constants.Debug.CW("_currentAssignments : " + _currentAssignements);

                }

                private void LoadFormationsOnUI()
                {
                        _assignments.Inlines.Clear();
                        _assignmentsPanel.Children.Clear();
                        _project.Reload();
                        foreach (string item in _project._formations)
                        {
                                //_assignments.Inlines.Add(item + "\n");
                                TaskPanel taskPanel = new TaskPanel(item);
                                _assignmentsPanel.Children.Add(taskPanel);
                                taskPanel._deleteButton.Click += _deleteButton_Click;
                        }
                }

                void _deleteButton_Click(object sender, RoutedEventArgs e)
                {
                        ReloadAssignments();
                }

                private void LoadTasksOnUI()
                {
                        _assignments.Inlines.Clear();
                        _assignmentsPanel.Children.Clear();
                        _project.Reload();
                        foreach (string item in _project._tasks)
                        {
                                //_assignments.Inlines.Add(item + "\n");
                                TaskPanel taskPanel = new TaskPanel(item);
                                _assignmentsPanel.Children.Add(taskPanel);
                                taskPanel._deleteButton.Click += _deleteButton_Click;
                        }
                }

                private void LoadMaintenanceOnUI()
                {
                        _assignments.Inlines.Clear();
                        _assignmentsPanel.Children.Clear();
                        _project.Reload();
                        foreach (string item in _project._maintenances)
                        {
                                //_assignments.Inlines.Add(item + "\n");
                                TaskPanel taskPanel = new TaskPanel(item);
                                _assignmentsPanel.Children.Add(taskPanel);
                                taskPanel._deleteButton.Click += _deleteButton_Click;
                        }
                }

        }//class ProjectWindow
}//ns
