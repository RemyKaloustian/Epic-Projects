using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        /// <summary>
        /// The central panel with the list of the tasks
        /// </summary>
        public class ContentPanel : StackPanel
        {
                public string _projectName { get; set; }
                public TaskPanel _taskPanel { get; set; }
                public ScrollViewer _scroller{ get; set; }
                public DetailsPanel  _detailsPanel { get; set; }
                public OptionsPanel _optionsPanel { get; set; }
                public StackPanel _rightPanel { get; set; }
                public HeaderPanel _headerPanel { get; set; }

                public bool _firstLoad { get; set; }
                public bool _isOnOptions { get; set; }
                public string  _UIState { get; set; }

                public ContentPanel(string name, HeaderPanel headerPanel)
                {
                        //Setting properties
                        this.Height = Dimensions.GetHeight()*0.75;
                        this.Margin = new System.Windows.Thickness(0, 10, 0, 0);
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;

                        //Setting fields
                        RightPanelCoordinator coord = new RightPanelCoordinator(this);
                        _taskPanel = new TaskPanel(_detailsPanel,name,coord);        
                        _optionsPanel = new OptionsPanel(_taskPanel);                        

                        _rightPanel = _optionsPanel;
                        _firstLoad = true;
                        _isOnOptions = true;
                        _projectName = name;
                        _scroller = new ScrollViewer();
                        _headerPanel = headerPanel;

                        //Adding children
                        _scroller.Content = _taskPanel;
                        this.Children.Add(_scroller);
                        this.Children.Add(_rightPanel);

                        //Loading Brainstormings on beginning by default
                        LoadBrainstorming();
                }

                /// <summary>
                ///Loads the brainstormings on the Layout
                /// </summary>
                public void LoadBrainstorming()
                {
                        //Fill the layout with brainstormings 
                        _taskPanel.FillBrainstormings(_optionsPanel);
                        _headerPanel.HighlightBrainstorming();
                        //If it's not the first time we show brainstormings and the details panel is on
                        if(!_firstLoad && !_isOnOptions)
                        {
                                //Removing the details panel, adding the options panel
                                InitializeSectionChange();
                        }

                        else if(_firstLoad)
                        {
                                _firstLoad = false;
                        }

                        _UIState = UIStates.ON_BRAINSTORMING;
                        _optionsPanel._uiState = _UIState;
                }//LoadBrainstorming()

             

                /// <summary>
                /// Loads the trainings on the layout
                /// </summary>
                public void LoadTraining()
                {
                        //Fill the layout with trainings
                        _taskPanel.FillTrainings(_optionsPanel);
                        //Changing the highlighting
                        _headerPanel.HighlightTraining();

                        //If the options panel is off
                        if(!_isOnOptions)
                        {
                                //Removing the detailsPanel and adding the options panel
                                InitializeSectionChange();
                        }

                        _UIState = UIStates.ON_TRAINING;
                        _optionsPanel._uiState = _UIState;
                }//LoadTraining()

                /// <summary>
                /// Loads the assignments on the layout
                /// </summary>
                public void LoadAssignments()
                {
                        //Fill the layout with assignments
                        _taskPanel.FillAssignments(_optionsPanel);
                        _headerPanel.HighlightAssignments();
                        //If the options panel is off
                        if(!_isOnOptions)
                        {
                                //Removing the detailsPanel and adding the options panel
                                InitializeSectionChange();
                        }

                        _UIState = UIStates.ON_ASSIGNMENT;
                        _optionsPanel._uiState = _UIState;

                }//LoadAssignments()


                /// <summary>
                /// Loads the maintenances on the layout
                /// </summary>
                public void LoadMaintenance()
                {
                        //Fill the layout with maintenance
                        _taskPanel.FillMaintenances(_optionsPanel);
                        _headerPanel.HighlightMaintenance();
                        //If the options panel is off
                        if(!_isOnOptions)
                        {
                                //Removing the detailsPanel and adding the options panel
                                InitializeSectionChange();
                        }

                        _UIState = UIStates.ON_MAINTENANCE;
                        _optionsPanel._uiState = _UIState;

                }//LoadMaintenance()

                /// <summary>
                /// Removes the details panel, adds the options panel
                /// </summary>
                private void InitializeSectionChange()
                {
                        this.Children.Remove(_detailsPanel);
                        this.Children.Add(_optionsPanel);
                        _isOnOptions = true;
                }//InitializeSectionChange()

                public  void LoadBrainstormingAddition()
                {

                        NewTaskPopUp newPopUp = new NewTaskPopUp(Dimensions.GetWidth()*0.7,Dimensions.GetHeight()/1.5, ControlsValues.BRAINSTORMING, _projectName, false, this);                      
                }

                internal void LoadTrainingAddition()
                {
                        NewAdvancedTaskPopUp newAdvanced = new NewAdvancedTaskPopUp(Dimensions.GetWidth() * 0.7, Dimensions.GetHeight() / 1.2, ControlsValues.TRAINING, _projectName, true, this);
                }

                internal void LoadAssignmentsAddition()
                {
                        NewAdvancedTaskPopUp newAdvanced = new NewAdvancedTaskPopUp(Dimensions.GetWidth() * 0.7, Dimensions.GetHeight() / 1.2, ControlsValues.ASSIGNMENTS.Remove(ControlsValues.ASSIGNMENTS.Length - 1), _projectName, true, this);
                }

                internal void LoadMaintenanceAddition()  
                {
                        NewAdvancedTaskPopUp newAdvanced = new NewAdvancedTaskPopUp(Dimensions.GetWidth() * 0.7, Dimensions.GetHeight() / 1.2, ControlsValues.MAINTENANCE, _projectName, true, this);
                }

                
        }//class ContentPanel
}//ns
