using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class TaskUpdater : StackPanel
        {
                #region fields
                //Brainstorming fields
                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox { get; set; }

                public TextBlock _alertBlock { get; set; }

                public TextBlock _detailsBlock { get; set; }
                public TextBox _detailsBox { get; set; }

                public ValidateButton _applyButton { get; set; }
                public CancelButton _nopeButton { get; set; }

                //Advanced fields

                public TextBlock _priorityBlock { get; set; }
                public ComboBox _priorityCombo { get; set; }

                public TextBlock _stateBlock{ get; set; }
                public ComboBox _stateCombo { get; set; }

                #endregion

                #region Constructors
                /// <summary>
                /// Used for brainstormings
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                public TaskUpdater(string name, string details, double width, double height)
                {
                        this.Orientation = Orientation.Vertical;
                        this.Background = ThemeSelector.GetBackground();

                        SetUpName();
                        SetUpNameBox(name, width);
                        SetUpAlertBlock();
                        SetUpDetails();
                        SetUpDetailsBox(details, width);
                        SetUpButtons(width, height);




                        this.Children.Add(_nameBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_alertBlock);
                        this.Children.Add(_detailsBlock);
                        this.Children.Add(_detailsBox);

                        this.Children.Add(_applyButton);
                        this.Children.Add(_nopeButton);
                }

                


                /// <summary>
                /// Used for advanced tasks
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                public TaskUpdater(string name, string details, string priority, string state, double width, double height)
                {
                        this.Orientation = Orientation.Vertical;
                        this.Background = ThemeSelector.GetBackground();


                        SetUpName();
                        SetUpNameBox(name, width);
                        SetUpAlertBlock();
                        SetUpDetails();
                        SetUpDetailsBox(details, width);
                        SetUpButtons(width, height);
                        SetUpPriorityBlock();
                        SetUpPriorityCombo(width);
                        FillPriorityCombo(priority);
                        SetUpStateBlock();
                        SetUpStateCombo(width);
                        FillStateCombo(state);
                        SetUpButtons(width, height);

                        this.Children.Add(_nameBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_alertBlock);
                        this.Children.Add(_priorityBlock);
                        this.Children.Add(_priorityCombo);
                        this.Children.Add(_stateBlock);
                        this.Children.Add(_stateCombo);
                        this.Children.Add(_detailsBlock);
                        this.Children.Add(_detailsBox);

                        this.Children.Add(_applyButton);
                        this.Children.Add(_nopeButton);
                }

                #endregion

                #region SetUp functions
                private void SetUpButtons(double width, double height)
                {
                        _applyButton = new ValidateButton(ControlsValues.APPLY, width * 0.7, height * 0.05, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center);

                        _nopeButton = new CancelButton(ControlsValues.NOPE, width * 0.7, height * 0.05, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center);
                }

                private void SetUpAlertBlock()
                {
                        _alertBlock = new TextBlock();
                        _alertBlock.FontFamily = FontProvider._open;
                        _alertBlock.FontSize = 13;
                        _alertBlock.Foreground = ThemeSelector.GetAccentColor();
                        //double leftMargin =  this.Width - _nameBox.Width - ((this.Width - _nameBox.Width) / 2);
                        //_alertBlock.Margin = new System.Windows.Thickness(leftMargin, 0, 0, 0);

                        _alertBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                }

                private void SetUpDetailsBox(string details, double width)
                {
                        _detailsBox = new TextBox();
                        _detailsBox.Text = details;
                        _detailsBox.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _detailsBox.Width = width * 0.8;
                        _detailsBox.MaxHeight = 300;
                        _detailsBox.FontFamily = FontProvider._lato;
                        _detailsBox.FontSize = 15;
                }

                private void SetUpDetails()
                {
                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Details";
                        _detailsBlock.FontFamily = FontProvider._lato;
                        _detailsBlock.Foreground = ThemeSelector.GetAccentColor();
                        _detailsBlock.FontSize = 20;
                        _detailsBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _detailsBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                }

                private void SetUpNameBox(string name, double width)
                {
                        _nameBox = new TextBox();
                        _nameBox.Text = name;
                        _nameBox.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _nameBox.FontFamily = FontProvider._lato;
                        _nameBox.FontSize = 15;
                        _nameBox.Width = width * 0.8;

                }

          

                private void SetUpName()
                {
                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name";
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.Foreground = ThemeSelector.GetAccentColor();
                        _nameBlock.FontSize = 20;
                        _nameBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }


                private void SetUpStateCombo(double width)
                {
                        _stateCombo = new ComboBox();
                        _stateCombo.FontFamily = FontProvider._lato;
                        _stateCombo.FontSize = 18;
                        _stateCombo.Width = width * 0.8;
                }

                private void SetUpStateBlock()
                {
                        _stateBlock = new TextBlock();
                        _stateBlock.Text = "State";
                        _stateBlock.FontFamily = FontProvider._lato;
                        _stateBlock.Foreground = ThemeSelector.GetAccentColor();
                        _stateBlock.FontSize = 20;
                        _stateBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _stateBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                private void SetUpPriorityCombo(double width)
                {
                        _priorityCombo = new ComboBox();
                        _priorityCombo.FontFamily = FontProvider._lato;
                        _priorityCombo.FontSize = 18;
                        _priorityCombo.Width = width * 0.8;
                }

                private void SetUpPriorityBlock()
                {

                        _priorityBlock = new TextBlock();
                        _priorityBlock.Text = "Priority";
                        _priorityBlock.FontFamily = FontProvider._lato;
                        _priorityBlock.Foreground = ThemeSelector.GetAccentColor();
                        _priorityBlock.FontSize = 20;
                        _priorityBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _priorityBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                #endregion

                private void FillPriorityCombo(string priority)
                {
                        _priorityCombo.Items.Add(Priorities.NOT_IMPORTANT);
                        _priorityCombo.Items.Add(Priorities.LESS_IMPORTANT);
                        _priorityCombo.Items.Add(Priorities.IMPORTANT);                       
                        _priorityCombo.Items.Add(Priorities.MOST_IMPORTANT);

                        if(priority.Contains(Priorities.NOT_IMPORTANT))
                        {
                                _priorityCombo.SelectedItem = _priorityCombo.Items[0];  
                        }

                        else if (priority.Contains( Priorities.LESS_IMPORTANT))
                        {
                                _priorityCombo.SelectedItem = _priorityCombo.Items[1];

                        }

                        else if (priority.Contains( Priorities.IMPORTANT))
                        {
                                _priorityCombo.SelectedItem = _priorityCombo.Items[2];

                        }

                        //else if (priority.Contains( Priorities.ULTRA_IMPORTANT))
                        //{
                        //        _priorityCombo.SelectedItem = _priorityCombo.Items[3];
                        //}

                        else if (priority.Contains( Priorities.MOST_IMPORTANT))
                        {
                                _priorityCombo.SelectedItem = _priorityCombo.Items[3];
                        }
                }//FillPriorityCombo()


                private void FillStateCombo(string state)
                {


                        _stateCombo.Items.Add(States.UIOPEN);
                        _stateCombo.Items.Add(States.UIPROGRESS);
                        _stateCombo.Items.Add(States.UIDONE);

                        if(state.Contains( States.UIOPEN))
                        {
                                _stateCombo.SelectedItem = _stateCombo.Items[0];
                        }

                        else if (state.Contains( States.UIPROGRESS))
                        {
                                _stateCombo.SelectedItem = _stateCombo.Items[1];

                        }

                        else if (state.Contains( States.UIDONE))
                        {
                                _stateCombo.SelectedItem = _stateCombo.Items[2];

                        }
                }//FillStateCombo()




        }//class TaskUpdater
}//ns
