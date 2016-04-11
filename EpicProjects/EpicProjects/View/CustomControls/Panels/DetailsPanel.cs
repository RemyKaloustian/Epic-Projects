using EpicProjects.Constants;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        /// <summary>
        /// The panel that will hold the details of a task when clicked
        /// </summary>
        public class DetailsPanel : StackPanel
        {
                

                public RightPanelCoordinator _coordinator { get; set; }
                public TaskUpdater _taskUpdater { get; set; }

                public StackPanel _container{ get; set; }

                public TextBlock _name { get; set; }
                public Separator _nameSeparator { get; set; }
                public TextBlock _priority{ get; set; }
                public Separator _prioritySeparator { get; set; }                   
                public TextBlock _stateBlock { get; set; }
                public Separator _stateSeparator { get; set; }
                public TextBlock _details { get; set; }
                public ValidateButton _updateButton { get; set; }
                public CancelButton _quitButton { get; set; }

                public SingleTaskPanel _taskPanel { get; set; }


                public DetailsPanel(RightPanelCoordinator coordinator)
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                    

                        _coordinator = coordinator;
                        _name = new TextBlock();
                        _details = new TextBlock();
                        _priority = new TextBlock();

                      

                        _quitButton = new CancelButton(ControlsValues.CLOSE,this.Width*0.6,this.Height*0.05,new System.Windows.Thickness(0,0,0,0), new System.Windows.Thickness(0,0,0,0), System.Windows.HorizontalAlignment.Center,new Theme.CustomTheme());
                        _quitButton.Visibility = System.Windows.Visibility.Hidden;
                        _quitButton.MouseDown += _quitButton_MouseDown;

                        SetUpName();
                        SetUpSeparator();
                        SetUpPrioritySeparator();
                        SetUpDetails();
                     
                        _container.Children.Add(_name);
                        _container.Children.Add(_nameSeparator);
                        _container.Children.Add(_priority);
                        _container.Children.Add(_prioritySeparator);
                        _container.Children.Add(_details);
                        _container.Children.Add(_quitButton);
                }

              


                /// <summary>
                /// Is used for brainstormings
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="taskPanel"></param>
                /// <param name="coordinator"></param>
                public DetailsPanel(string name, string details, SingleTaskPanel taskPanel, RightPanelCoordinator coordinator)
                {
                        //Setting up the details panel properties
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();
                        _container = new StackPanel();
                        _container.Orientation = System.Windows.Controls.Orientation.Vertical;

                        //Setting up the fields
                        _coordinator = coordinator;
                        _name = new TextBlock();
                        _details = new TextBlock();                       

                        _name.Text = name;
                        _details.Text = details;
                        _taskPanel = taskPanel;

                        _updateButton = new ValidateButton(ControlsValues.UPDATE, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());
                        _updateButton.MouseDown += _updateButton_MouseDown;

                        _quitButton = new CancelButton(ControlsValues.CLOSE, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 30, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());
                        _quitButton.MouseDown += _quitButton_MouseDown;

                        //Setting up the components
                        SetUpName();
                        _nameSeparator = SetUpSeparator();                        
                        SetUpDetails();
                        

                        //Adding the components to the details panel
                        _container.Children.Add(_name);
                        _container.Children.Add(_nameSeparator);
                        _container.Children.Add(_details);
                        _container.Children.Add(_updateButton);
                        _container.Children.Add(_quitButton);

                        this.Children.Add(_container);
                }//Constructor 1 

                void _updateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Children.Remove(_container);
                        _taskUpdater = new TaskUpdater(_name.Text, _details.Text, this.Width, this.Height);
                        _taskUpdater._nopeButton.MouseDown += _nopeButton_MouseDown;
                        _taskUpdater._applyButton.MouseDown += _applyButton_MouseDown;
                        this.Children.Add(_taskUpdater);
                }

                void _applyButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        new TaskMasterChief(_coordinator._contentPanel._projectName).UpdateBrainstorming(_name.Text,_taskUpdater._nameBox.Text,_taskUpdater._detailsBox.Text);
                        this.Children.Remove(_taskUpdater);
                        this.Children.Add(_container);
                        _coordinator._contentPanel.LoadBrainstorming();
                }

                void _nopeButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Children.Remove(_taskUpdater);
                        this.Children.Add(_container);
                }



                /// <summary>
                /// Is used for advanced tasks
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                /// <param name="taskPanel"></param>
                /// <param name="coordinator"></param>
                /// <param name="priority"></param>
                /// <param name="state"></param>
                public    DetailsPanel(string name,string details,SingleTaskPanel taskPanel, RightPanelCoordinator coordinator, string priority, string state)
                {
                // TODO: Complete member initialization
                     
                        //Setting up the details panel properties
                         this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _container = new StackPanel();
                        _container.Orientation = System.Windows.Controls.Orientation.Vertical;
                        //Setting up the fields
                        _coordinator = coordinator;
                        _name = new TextBlock();
                        _details = new TextBlock();
                        _priority = new TextBlock();
                        _stateBlock = new TextBlock();
                        _prioritySeparator = new Separator();
                        

                        _name.Text = name;
                        _details.Text = details;
                        _taskPanel = taskPanel;
                        _updateButton = new ValidateButton(ControlsValues.UPDATE, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());
                        _updateButton.MouseDown += _updateButton_MouseDownAdvanced;

                        _quitButton = new CancelButton(ControlsValues.CLOSE,this.Width*0.6,this.Height*0.05,new System.Windows.Thickness(0,20,0,0), new System.Windows.Thickness(0,0,0,0), System.Windows.HorizontalAlignment.Center,new Theme.CustomTheme());
                        _quitButton.MouseDown += _quitButton_MouseDown;

                        //Setting up the components
                        SetUpName();
                        _nameSeparator = SetUpSeparator();
                        _prioritySeparator = SetUpSeparator();
                        SetPriorityLayout(priority); 
                        SetUpState(state);
                        _stateSeparator = SetUpSeparator();
                        SetUpDetails();
                       

                        //Adding the components to the details panel
                        _container.Children.Add(_name);
                        _container.Children.Add(_nameSeparator);                       
                        _container.Children.Add(_priority);
                        _container.Children.Add(_prioritySeparator);

                        _container.Children.Add(_stateBlock);
                        _container.Children.Add(_stateSeparator);
                        _container.Children.Add(_details);
                        _container.Children.Add(_updateButton);
                        _container.Children.Add(_quitButton);

                        this.Children.Add(_container);
                }//Constructor 2

                private void _updateButton_MouseDownAdvanced(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Children.Remove(_container);
                        _taskUpdater = new TaskUpdater(_name.Text, _details.Text, _priority.Text,_stateBlock.Text, this.Width, this.Height);
                        _taskUpdater._nopeButton.MouseDown += _nopeButton_MouseDown;
                        _taskUpdater._applyButton.MouseDown += _applyButton_MouseDownAdvanced;
                        this.Children.Add(_taskUpdater);

                     
                }

                private void _applyButton_MouseDownAdvanced(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_coordinator._contentPanel._UIState == UIStates.ON_TRAINING)
                        {
                                new TaskMasterChief(_coordinator._contentPanel._projectName).UpdateTraining(_name.Text, _taskUpdater._nameBox.Text, _taskUpdater._detailsBox.Text, _taskUpdater._priorityCombo.SelectedItem.ToString(), _taskUpdater._stateCombo.SelectedItem.ToString());
                                _coordinator._contentPanel.LoadTraining();

                        }

                        else if (_coordinator._contentPanel._UIState == UIStates.ON_ASSIGNMENT)
                        {
                                _coordinator._contentPanel.LoadAssignments();
                        }

                        else if (_coordinator._contentPanel._UIState == UIStates.ON_MAINTENANCE)
                        {
                                _coordinator._contentPanel.LoadMaintenance();
                        }


                        this.Children.Remove(_taskUpdater);
                        this.Children.Add(_container);
                        
                }

                /// <summary>
                /// Quits the details panel when the quitButton is clicked
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                void _quitButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _taskPanel.UnHover();
                        _coordinator.ToOptions();
                }

                /// <summary>
                /// Sets up the details paragraph
                /// </summary>
                private void SetUpDetails()
                {
                        _details.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _details.FontFamily = FontProvider._lato;
                        _details.FontSize = 15;
                        _details.Width = this.Width * 0.8;
                        _details.MinHeight = 100;
                        _details.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _details.Foreground = new Theme.CustomTheme().GetBackground();
                }

                /// <summary>
                /// Sets up the priority separator
                /// </summary>
                private void SetUpPrioritySeparator()
                {
                        _prioritySeparator = new Separator();
                        _prioritySeparator.Width = this.Width * 0.85;
                        _prioritySeparator.Background = new Theme.CustomTheme().GetBackground();
                        _prioritySeparator.Margin = new System.Windows.Thickness(0, this.Height * 0.025, 0, this.Height * 0.025);
                }

                /// <summary>
                /// Sets up the separator 
                /// </summary>
                private Separator SetUpSeparator()
                {
                        Separator sep = new Separator();
                        
                        sep.Width = this.Width * 0.85;
                        sep.Background = new Theme.CustomTheme().GetBackground();
                        sep.Margin = new System.Windows.Thickness(0, this.Height * 0.025, 0, this.Height * 0.025);

                        return sep;
                }

                /// <summary>
                /// Set up the name of the task
                /// </summary>
                private void SetUpName()
                {

                        _name.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _name.FontFamily = FontProvider._lato;
                        _name.FontSize = 28;
                        _name.Width = this.Width * 0.8;
                        _name.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _name.Foreground = new Theme.CustomTheme().GetBackground();
                        _name.Margin = new System.Windows.Thickness(0, this.Height * 0.015, 0, 0);
                }

                /// <summary>
                /// Makes the separator visible
                /// </summary>
                public void AddSeparator()
                {
                        _nameSeparator.Visibility = System.Windows.Visibility.Visible;

                }

                /// <summary>
                /// Sets the priority layout, but DOES NOT display it
                /// </summary>
                /// <param name="content"></param>
                public void SetPriorityLayout(string content)
                {
                       // _prioritySeparator = new Separator();
                        //_prioritySeparator.Visibility = System.Windows.Visibility.Hidden;
                        _priority.Text = "Priority : " + content;


                        _priority.FontFamily = FontProvider._lato;
                        _priority.FontSize = 22;
                        _priority.Width = this.Width * 0.8;
                        //_priority.Visibility = System.Windows.Visibility.Hidden;
                        _priority.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _priority.Foreground = new Theme.CustomTheme().GetBackground();

                }

                internal void SetUpState(string state)
                {
                        _stateBlock.Text = "State : " + new StateInterpreter(state).ToUIState();
                        _stateBlock.FontFamily = FontProvider._lato;
                        _stateBlock.FontSize = 22;
                        _stateBlock.Width = this.Width * 0.8;
                        _stateBlock.Foreground = new Theme.CustomTheme().GetBackground();
                }

                /// <summary>
                /// Displays the priority when an advanced task is clicked
                /// </summary>
                /// <param name="content"></param>
                public void DisplayPriority(string content)
                {
                        _prioritySeparator.Visibility = System.Windows.Visibility.Visible;
                        _priority.Visibility = System.Windows.Visibility.Visible;
                }
        }//class DetailsPanel()
}//ns
