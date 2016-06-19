using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls.Panels;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class NewTaskPopUp : PopUp
        {
                #region fields
                public string _projectName{ get; set; }
                public string  _section{ get; set; }

                public Separator _separator { get; set; }

                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox { get; set; }

                public TextBlock _alertBlock { get; set; }

                public TextBlock _detailsBlock { get; set; }
                public TextBox _detailsBox { get; set; }

                public ValidateButton _validateButton { get; set; }
                public CancelButton _cancelButton { get; set; }

                public ContentPanel _contentPanel { get; set; }

                #endregion

                public NewTaskPopUp(double width, double height, string content, string projectName, bool isAdvanced, ContentPanel contentPanel)
                        : base(width,  height,  content)
                {
                        this.Background = ThemeSelector.GetPopUpBackground();
                        _contentPanel = contentPanel;
                        _block.Text = "New " + content;
                        _section = content;
                        _projectName = projectName;

                        SetUpSeparator();
                        SetUpNameBlock();
                        SetUpNameBox();
                        SetUpAlertBlock();
                        SetUpDetailsBlock();
                        SetUpDetailsBox();
                        SetUpButtons();

                        _container.Children.Add(_separator);
                        _container.Children.Add(_nameBlock);
                        _container.Children.Add(_nameBox);
                        _container.Children.Add(_alertBlock);
                        _container.Children.Add(_detailsBlock);
                        _container.Children.Add(_detailsBox);

                        if (!isAdvanced)
                        {
                                _container.Children.Add(_validateButton);
                                _container.Children.Add(_cancelButton);
                        }
                }//Constructor()


                #region SetUp
                private void SetUpButtons()
                {
                        _validateButton = new ValidateButton("Create", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _validateButton.MouseDown += _validateButton_MouseDown;
                        _validateButton.IsEnabled = false;

                        _cancelButton = new CancelButton("Cancel", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);

                        _cancelButton.MouseDown += _cancelButton_MouseDown;
                }

                private void SetUpDetailsBox()
                {
                        _detailsBox = new TextBox();

                        _detailsBox.Width = this.Width * 0.5;
                        _detailsBox.FontFamily = FontProvider._lato;
                        _detailsBox.Height = this.Height * 0.2;
                        _detailsBlock.MaxHeight = 200;
                        _detailsBox.FontSize = 16;
                        _detailsBox.TextWrapping = System.Windows.TextWrapping.Wrap;
                }

                private void SetUpDetailsBlock()
                {
                        _detailsBlock = new TextBlock();
                        _detailsBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _detailsBlock.FontSize = Responsive.GetButtonTextSize();
                        _detailsBlock.FontFamily = FontProvider._lato;
                        _detailsBlock.Text = "Description";
                        _detailsBlock.Foreground = ThemeSelector.GetBackground();
                        _detailsBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                private void SetUpAlertBlock()
                {
                        _alertBlock = new TextBlock();
                        _alertBlock.FontFamily = FontProvider._open;
                        _alertBlock.FontSize = Responsive.GetSideMenuTextSize();
                        _alertBlock.Foreground = ThemeSelector.GetBackground();
                        double leftMargin = this.Width - _nameBox.Width - ((this.Width - _nameBox.Width)/2);
                        _alertBlock.Margin = new System.Windows.Thickness(leftMargin, 0, 0, 0);
                }

                private void SetUpNameBox()
                {
                        _nameBox = new TextBox();
                        _nameBox.Width = this.Width * 0.5;
                        _nameBox.FontFamily = FontProvider._lato;
                       // _nameBox.Height = this.Height * 0.06;
                        _nameBox.FontSize = Responsive.GetSideMenuTextSize();

                        _nameBox.TextChanged += _nameBox_TextChanged;
                        _nameBox.GotFocus += _nameBox_GotFocus; ;
                }

                void _nameBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
                {
                        CheckName();
                }

                void _nameBox_TextChanged(object sender, TextChangedEventArgs e)
                {

                        CheckName();
                    
                }

                private void CheckName()
                {
                        if (_nameBox.Text.Trim() == "")
                        {
                                _alertBlock.Text = "Null input is not valid";
                                _validateButton.IsEnabled = false;
                        }

                        else if (!this.IsNameValid())
                        {
                                _alertBlock.Text = "this task already exists";
                                _validateButton.IsEnabled = false;
                        }

                        else
                        {
                                _alertBlock.Text = "Name is valid";
                                _validateButton.IsEnabled = true;
                        }
                }

                /// <summary>
                /// Checking if the task is already defined in the current project
                /// </summary>
                /// <returns></returns>
                private bool IsNameValid()
                {

                        if(_section == ControlsValues.BRAINSTORMING)
                        {
                                List<Model.Task> tasks = new TaskMasterChief(_projectName).SelectBrainstormings();

                                foreach (Model.Task item in tasks)
                                {
                                        if (item._name.ToLower().Trim().Replace(" ",string.Empty) == _nameBox.Text.ToLower().Trim().Replace(" ", string.Empty) && item._project == _projectName)
                                                return false;
                                }
                        }

                        else if(_section ==ControlsValues.TRAINING)
                        {
                                List<Model.AdvancedTask> tasks = new TaskMasterChief(_projectName).SelectTrainings();

                                foreach (Model.AdvancedTask item in tasks)
                                {
                                        if (item._name.ToLower().Trim().Replace(" ", string.Empty) == _nameBox.Text.ToLower().Trim().Replace(" ", string.Empty) && item._project == _projectName)
                                                return false;
                                }
                        }

                        else if( ControlsValues.ASSIGNMENTS.Contains(_section))
                        {
                                List<Model.AdvancedTask> tasks = new TaskMasterChief(_projectName).SelectAssignments();

                                foreach (Model.AdvancedTask item in tasks)
                                {
                                        if (item._name.ToLower().Trim().Replace(" ", string.Empty) == _nameBox.Text.ToLower().Trim().Replace(" ", string.Empty) && item._project == _projectName)
                                                return false;
                                }
                        }


                        else if(_section == ControlsValues.MAINTENANCE)
                        {
                                List<Model.AdvancedTask> tasks = new TaskMasterChief(_projectName).SelectMaintenances();

                                foreach (Model.AdvancedTask item in tasks)
                                {
                                        if (item._name.ToLower().Trim().Replace(" ", string.Empty) == _nameBox.Text.ToLower().Trim().Replace(" ", string.Empty) && item._project == _projectName)
                                                return false;
                                }
                        }

                        return true;
                }

                private void SetUpNameBlock()
                {
                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name  ";
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.FontSize = Responsive.GetButtonTextSize();
                        _nameBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBlock.Foreground = ThemeSelector.GetBackground();
                }

                private void SetUpSeparator()
                {
                        _separator = new Separator();
                        _separator.Width = this.Width / 2;
                        _separator.Background = ThemeSelector.GetBackground();
                        _separator.Margin = new System.Windows.Thickness(0, 10, 0, 50);
                }
                #endregion

                #region Events
                void _validateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if(_nameBox.Text.Trim() == "")
                        {
                                _alertBlock.Text = "Null input is invalid";
                        }

                        else if (_section == ControlsValues.BRAINSTORMING)
                        {
                                new TaskMasterChief(_projectName).InsertBrainstorming(_nameBox.Text, _detailsBox.Text);
                                _contentPanel.LoadBrainstorming();
                        }
                    
                        this.Close();
                }

                void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }

                #endregion
        }//class NewTaskPopUp
}//ns
