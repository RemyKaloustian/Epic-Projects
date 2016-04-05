﻿using EpicProjects.Constants;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class TaskPanel : StackPanel
        {

                public DetailsPanel _detailsPanel { get; set; }

                public TaskMasterChief _chief { get; set; }

                public List<SingleTaskPanel> _brainstormingList { get; set; }
                public List<SingleAdvancedTaskPanel> _trainingList { get; set; }
                public List<SingleAdvancedTaskPanel> _assignmentsList { get; set; }
                public List<SingleAdvancedTaskPanel> _maintenancesList { get; set; }

                public TaskPanel(DetailsPanel detailsPanel, string name)
                {
                        _chief = new TaskMasterChief(name);
                        _detailsPanel = detailsPanel;
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        this.Margin = new System.Windows.Thickness(0, 0, 10, 0);

                        this.Width = Dimensions.GetWidth() * 0.6;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = Palette2.GetColor(Palette2.LIGHT_GRAY);

                        _brainstormingList = new List<SingleTaskPanel>();
                        _trainingList = new List<SingleAdvancedTaskPanel>();
                        _assignmentsList = new List<SingleAdvancedTaskPanel>();
                        _maintenancesList = new List<SingleAdvancedTaskPanel>();
                }


                public void FillBrainstormings()
                {
                        this.Children.Clear();

                        List<Model.Task> brains = _chief.SelectBrainstormings();
                        foreach (Model.Task item in brains)
                        {                               
                                SingleTaskPanel brainStorming = new SingleTaskPanel(item);
                                _brainstormingList.Add(brainStorming);
                                brainStorming.MouseDown += brainStorming_MouseDown;
                                this.Children.Add(brainStorming);
                        }
                }//FillBrainstormings

                public void FillTrainings()
                {
                        this.Children.Clear();
                        List<Model.AdvancedTask> brains = _chief.SelectTrainings();
                        foreach (Model.AdvancedTask item in brains)
                        {
                                SingleAdvancedTaskPanel training = new SingleAdvancedTaskPanel(item);
                                _trainingList.Add(training);
                                training.MouseDown += Trainings_MouseDown;
                                this.Children.Add(training);
                        }
                }//FillTrainings()

                public void FillAssignments()
                {
                        this.Children.Clear();
                        List<Model.AdvancedTask> assignments = _chief.SelectAssignments();
                        foreach (Model.AdvancedTask item in assignments)
                        {

                                SingleAdvancedTaskPanel assignment = new SingleAdvancedTaskPanel(item);
                                _assignmentsList.Add(assignment);
                                assignment.MouseDown += Assignments_MouseDown;
                                this.Children.Add(assignment);
                        }
                }//FillAssignments()

                public void FillMaintenances()
                {
                        this.Children.Clear();
                        List<Model.AdvancedTask> maintenances = _chief.SelectMaintenances();
                        foreach (Model.AdvancedTask item in maintenances)
                        {
                                
                                SingleAdvancedTaskPanel maintenance = new SingleAdvancedTaskPanel(item);
                                _maintenancesList.Add(maintenance);
                                maintenance.MouseDown += Maintenances_MouseDown;
                                this.Children.Add(maintenance);
                        }
                }//FillAssignments()


                void brainStorming_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        SingleTaskPanel taskPanel = (SingleTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleTaskPanel task in _brainstormingList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = new Theme.CustomTheme().GetAccentColor();

                                        task._checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                                        task._content.Foreground = new Theme.CustomTheme().GetBackground();
                                }
                        }
                        _detailsPanel.AddSeparator();

                        _detailsPanel._name.Text = taskPanel._task._name;
                        _detailsPanel._details.Text = taskPanel._task._details;
                        _detailsPanel._quitButton.Visibility = System.Windows.Visibility.Visible;
                        _detailsPanel._taskPanel = taskPanel;

                       

                }


                void Trainings_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        SingleAdvancedTaskPanel taskPanel = (SingleAdvancedTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleAdvancedTaskPanel task in _trainingList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = new Theme.CustomTheme().GetAccentColor();

                                        task._checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                                        task._content.Foreground = new Theme.CustomTheme().GetBackground();
                                }
                        }
                        _detailsPanel.AddSeparator();

                        _detailsPanel._name.Text = taskPanel._advancedTask._name;
                        _detailsPanel._details.Text = taskPanel._advancedTask._details;
                        _detailsPanel.SetPriorityLayout(taskPanel._advancedTask._priority);
                        _detailsPanel._quitButton.Visibility = System.Windows.Visibility.Visible;
                        _detailsPanel._taskPanel = taskPanel;


                  
                }



                void Assignments_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        SingleAdvancedTaskPanel taskPanel = (SingleAdvancedTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleAdvancedTaskPanel task in _assignmentsList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = new Theme.CustomTheme().GetAccentColor();

                                        task._checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                                        task._content.Foreground = new Theme.CustomTheme().GetBackground();
                                }
                        }
                        _detailsPanel.AddSeparator();

                        _detailsPanel._name.Text = taskPanel._advancedTask._name;
                        _detailsPanel._details.Text = taskPanel._advancedTask._details;
                        _detailsPanel.SetPriorityLayout(taskPanel._advancedTask._priority);
                        _detailsPanel._quitButton.Visibility = System.Windows.Visibility.Visible;
                        _detailsPanel._taskPanel = taskPanel;


                  
                }

                void Maintenances_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                        SingleAdvancedTaskPanel taskPanel = (SingleAdvancedTaskPanel)sender;
                        taskPanel.TriggerHover();
                        foreach (SingleAdvancedTaskPanel task in _maintenancesList)
                        {
                                if (!task.IsMouseOver)
                                {
                                        task.Background = new Theme.CustomTheme().GetAccentColor();

                                        task._checkBoxBorder.BorderBrush = new Theme.CustomTheme().GetBackground();
                                        task._content.Foreground = new Theme.CustomTheme().GetBackground();
                                }
                        }
                        _detailsPanel.AddSeparator();
                        _detailsPanel._name.Text = taskPanel._advancedTask._name;
                        _detailsPanel._details.Text = taskPanel._advancedTask._details;
                        _detailsPanel.SetPriorityLayout(taskPanel._advancedTask._priority);
                        _detailsPanel._quitButton.Visibility = System.Windows.Visibility.Visible;
                        _detailsPanel._taskPanel = taskPanel;

                        
                }

              
        }//class TaskPanel
}//ns
