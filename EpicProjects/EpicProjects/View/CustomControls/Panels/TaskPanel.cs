using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        /// <summary>
        /// Contains all the task panels 
        /// </summary>
        public class TaskPanel : StackPanel
        {
                public TaskMasterChief _chief { get; set; }
                public RightPanelCoordinator _coordinator { get; set; }

                public List<SingleTaskPanel> _brainstormingList { get; set; }
                public List<SingleAdvancedTaskPanel> _trainingList { get; set; }
                public List<SingleAdvancedTaskPanel> _assignmentsList { get; set; }
                public List<SingleAdvancedTaskPanel> _maintenancesList { get; set; }

                public TaskPanel(DetailsPanel detailsPanel, string name, RightPanelCoordinator coordinator)
                {
                      //Setting up properties
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        this.Margin = new System.Windows.Thickness(0, 0, 10, 0);
                        this.Width = Dimensions.GetWidth() * 0.6;
                        this.MinHeight = Dimensions.GetHeight() * 0.8;
                        //this.Background = ThemeSelector.GetPopUpBackground();

                        //Setting up fields
                        _chief = new TaskMasterChief(name);
                        _coordinator = coordinator;
                       
                        _brainstormingList = new List<SingleTaskPanel>();
                        _trainingList = new List<SingleAdvancedTaskPanel>();
                        _assignmentsList = new List<SingleAdvancedTaskPanel>();
                        _maintenancesList = new List<SingleAdvancedTaskPanel>();
                }


                public void FillBrainstormings(OptionsPanel optionsPanel)
                {
                        optionsPanel.HideButtons();
                        this.Children.Clear();
                        
                        List<Model.Task> brains = _chief.SelectBrainstormings();

                        if(brains.Count != 0 )
                        {
                                foreach (Model.Task item in brains)
                                {
                                        SingleTaskPanel brainStorming = new SingleTaskPanel(item);
                                        _brainstormingList.Add(brainStorming);
                                        brainStorming.MouseDown += brainStorming_MouseDown;
                                        this.Children.Add(brainStorming);
                                }
                        }
                        else
                        {
                                this.Children.Add(new EmptyTaskPanel(ControlsValues.BRAINSTORMING));
                        }
                       
                }//FillBrainstormings

                public void FillTrainings(OptionsPanel optionsPanel)
                {
                        optionsPanel.ShowButtons();
                        this.Children.Clear();
                        //List<Model.AdvancedTask> trains = _chief.SelectTrainings();


                        List<Model.AdvancedTask> trains = new Sorter().SortTrainings(_chief);

                        if(trains.Count != 0)
                        {
                                foreach (Model.AdvancedTask item in trains)
                                {
                                        SingleAdvancedTaskPanel training = new SingleAdvancedTaskPanel(item);
                                        _trainingList.Add(training);
                                        training.MouseDown += Trainings_MouseDown;
                                        this.Children.Add(training);
                                }
                        }
                        else
                        {
                                this.Children.Add(new EmptyTaskPanel(ControlsValues.TRAINING));

                        }
                      
                }//FillTrainings()

                public void FillAssignments(OptionsPanel optionsPanel)
                {
                        optionsPanel.ShowButtons();
                        this.Children.Clear();
                        List<Model.AdvancedTask> assignments = new Sorter().SortAssignments(_chief);

                        if(assignments.Count != 0)
                        {
                                foreach (Model.AdvancedTask item in assignments)
                                {

                                        SingleAdvancedTaskPanel assignment = new SingleAdvancedTaskPanel(item);
                                        _assignmentsList.Add(assignment);
                                        assignment.MouseDown += Assignments_MouseDown;
                                        this.Children.Add(assignment);
                                }
                        }

                        else
                        {
                                this.Children.Add(new EmptyTaskPanel(ControlsValues.ASSIGNMENTS));

                        }
                       
                }//FillAssignments()

                public void FillMaintenances(OptionsPanel optionsPanel)
                {
                        optionsPanel.ShowButtons();
                        this.Children.Clear();
                        List<Model.AdvancedTask> maintenances = _chief.SelectMaintenances();

                        if(maintenances.Count != 0)
                        {
                                foreach (Model.AdvancedTask item in maintenances)
                                {

                                        SingleAdvancedTaskPanel maintenance = new SingleAdvancedTaskPanel(item);
                                        _maintenancesList.Add(maintenance);
                                        maintenance.MouseDown += Maintenances_MouseDown;
                                        this.Children.Add(maintenance);
                                }
                        }
                        else
                        {
                                this.Children.Add(new EmptyTaskPanel(ControlsValues.MAINTENANCE));

                        }
                      
                }//FillAssignments()


                /// <summary>
                /// Adds the details of the clicked brainstorming to the optionsPanel
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                void brainStorming_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        SingleTaskPanel taskPanel = (SingleTaskPanel)sender;
                        //Making the hover effect
                        taskPanel.TriggerHover();

                        //UnHovering the previously selected task
                        foreach (SingleTaskPanel task in _brainstormingList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = ThemeSelector.GetBackground();
                                        task._content.Foreground = ThemeSelector.GetAccentColor();
                                }
                        }
                        //Displaying the details panel
                        _coordinator.ToDetails(taskPanel._task._name ,  taskPanel._task._details , taskPanel);
                }//brainStorming_MouseDown()


                void Trainings_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        SingleAdvancedTaskPanel taskPanel = (SingleAdvancedTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleAdvancedTaskPanel task in _trainingList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = ThemeSelector.GetBackground();

                                        task._content.Foreground = ThemeSelector.GetAccentColor();
                                }
                        }

                        _coordinator.ToDetails(taskPanel._advancedTask._name, taskPanel._advancedTask._details, taskPanel, taskPanel._advancedTask._priority, taskPanel._advancedTask._state);                  
                }//Trainings_MouseDown()

                void Assignments_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        SingleAdvancedTaskPanel taskPanel = (SingleAdvancedTaskPanel)sender;
                      taskPanel.TriggerHover();

                        foreach (SingleAdvancedTaskPanel task in _assignmentsList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = ThemeSelector.GetBackground();

                                        task._content.Foreground = ThemeSelector.GetAccentColor();
                                }
                        }
                        _coordinator.ToDetails(taskPanel._advancedTask._name, taskPanel._advancedTask._details, taskPanel, taskPanel._advancedTask._priority,  taskPanel._advancedTask._state);
                }//Assignments_MouseDown()

                void Maintenances_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        SingleAdvancedTaskPanel taskPanel = (SingleAdvancedTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleAdvancedTaskPanel task in _maintenancesList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = ThemeSelector.GetBackground();

                                        task._content.Foreground = ThemeSelector.GetAccentColor();
                                }
                        }
                        _coordinator.ToDetails(taskPanel._advancedTask._name, taskPanel._advancedTask._details, taskPanel, taskPanel._advancedTask._priority, taskPanel._advancedTask._state);
                }//Maintenances_MouseDown()

              
        }//class TaskPanel
}//ns
