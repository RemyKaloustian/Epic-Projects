using EpicProjects.Constants;
using EpicProjects.Constants.Model;
using EpicProjects.Database;
using EpicProjects.View.CustomControls.Buttons;
using EpicProjects.View.CustomControls.Home;
using EpicProjects.View.CustomControls.PopUp;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class OptionsPanel : StackPanel
        {

                public DefaultButton _sortButton { get; set; }
                public DefaultButton  _showDoneButton{ get; set; }

                public TaskPanel  _taskPanel{ get; set; }

                public SortingPopUp _sortingPU { get; set; }

                public string  _uiState{ get; set; }

                public OptionsPanel( TaskPanel taskpanel)
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = ThemeSelector.GetBackground();

                        _sortingPU = new SortingPopUp(Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.5, "Sorting options");
                        _sortingPU.Hide();

                        _taskPanel = taskpanel;

                        _sortButton = new DefaultButton("Sort",this.Width/2,this.Height/20, new System.Windows.Thickness(0,20,0,0),new System.Windows.Thickness(0,0,0,0),HorizontalAlignment);
                        _sortButton.MouseDown += _sortButton_MouseDown;


                        _showDoneButton = new DefaultButton(this.GetShowDoneContent(), this.Width / 2, this.Height / 20, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), HorizontalAlignment);
                        _showDoneButton.MouseDown += _showDoneButton_MouseDown;
                       
                      
                              this.Children.Add(_sortButton);
                              this.Children.Add(_showDoneButton);

                              _sortingPU._sortImportanceButton.MouseDown += _sortImportanceButton_MouseDown;
                              _sortingPU._sortStateButton.MouseDown += _sortStateButton_MouseDown;
                              _sortingPU._sortCreationButton.MouseDown += _sortCreationButton_MouseDown;
                       
                }

                void _sortCreationButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        Preferences.SetSort(Sorting.CREATION);
                        FillOnState();

                }

                void _sortStateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        Preferences.SetSort(Sorting.STATE);
                        FillOnState();

                }

                void _sortImportanceButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        Preferences.SetSort(Sorting.IMPORTANCE);
                        FillOnState();
                        
                }

                void _sortButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        _sortingPU.Show();

                }

                private string GetShowDoneContent()
                {
                        string content = "Show done";
                        if(Preferences.GetShowDone())
                        {
                                //Constants.Debug.CW("In GetShowDoneContent(), Preferences.GetShowDone() = " + Preferences.GetShowDone());
                                content = "Hide done";
                        }

                        //Constants.Debug.CW("content =" + content);
                        return content;
                }

                void _showDoneButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_showDoneButton._block.Text == "Show done")
                        {
                                _showDoneButton._block.Text = "Hide done";   
                                //Constants.Debug.CW("Setting show done to true");

                                Preferences.SetShowDone(true);

                                FillOnState();
                        }
                        else
                        {
                                _showDoneButton._block.Text = "Show done"; 
                                //Constants.Debug.CW("Setting show done to false");

                                Preferences.SetShowDone(false);

                                FillOnState();

                        }
                }//_showDoneButton_MouseDown()

                private void FillOnState()
                {

                        if (_uiState == UIStates.ON_TRAINING)
                        {
                                _taskPanel.FillTrainings(this);
                        }
                        else if (_uiState == UIStates.ON_ASSIGNMENT)
                        {
                                _taskPanel.FillAssignments(this);
                        }

                        else if (_uiState == UIStates.ON_MAINTENANCE)
                        {
                                _taskPanel.FillMaintenances(this);
                        }
                }//FillOnState()

                public void HideButtons()
                {
                        Constants.Debug.CW("Hiding buttons");
                        _sortButton.Visibility = System.Windows.Visibility.Hidden;
                        _showDoneButton.Visibility = System.Windows.Visibility.Hidden;
                }//HideButtons()

                public  void ShowButtons()
                {
                        Constants.Debug.CW("Showing the buttons");
                        _sortButton.Visibility = System.Windows.Visibility.Visible;
                        _showDoneButton.Visibility = System.Windows.Visibility.Visible;
                }

        }//class OptionsPanel
}//ns
