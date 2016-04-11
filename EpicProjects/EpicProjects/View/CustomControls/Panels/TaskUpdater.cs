using EpicProjects.Constants;
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
                //Brainstorming fields
                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox { get; set; }

                public TextBlock _detailsBlock { get; set; }
                public TextBox _detailsBox { get; set; }

                public ValidateButton _applyButton { get; set; }
                public CancelButton _nopeButton { get; set; }

                //Advanced fields

                public TextBlock _priorityBlock { get; set; }
                public ComboBox _priorityCombo { get; set; }

                public TextBlock _stateBlock{ get; set; }
                public ComboBox _stateCombo { get; set; }

                

                /// <summary>
                /// Used for brainstormings
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                public TaskUpdater(string name, string details, double width, double height)
                {
                        this.Orientation = Orientation.Vertical;

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name";
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _nameBlock.FontSize = 20;
                        _nameBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                        _nameBox = new TextBox();
                        _nameBox.Text = name;
                        _nameBox.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _nameBox.FontFamily = FontProvider._lato;
                        _nameBox.FontSize = 15;
                        _nameBox.Width = width * 0.8;

                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Details";
                        _detailsBlock.FontFamily = FontProvider._lato;
                        _detailsBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _detailsBlock.FontSize = 20;
                        _detailsBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _detailsBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);


                        _detailsBox = new TextBox();
                        _detailsBox.Text = details;
                        _detailsBox.TextWrapping = System.Windows.TextWrapping.Wrap;
                        _detailsBox.Width = width * 0.8;
                        _detailsBox.FontFamily = FontProvider._lato;
                        _detailsBox.FontSize = 15;


                        _applyButton = new ValidateButton(ControlsValues.APPLY, width * 0.7, height * 0.05, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _nopeButton = new CancelButton(ControlsValues.NOPE, width * 0.7, height * 0.05, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());


                        this.Children.Add(_nameBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_detailsBlock);
                        this.Children.Add(_detailsBox);

                        this.Children.Add(_applyButton);
                        this.Children.Add(_nopeButton);
                }


                /// <summary>
                /// Used for brainstormings
                /// </summary>
                /// <param name="name"></param>
                /// <param name="details"></param>
                public TaskUpdater(string name, string details, string priority, string state)
                {
                        this.Orientation = Orientation.Vertical;

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name";

                        _nameBox = new TextBox();
                        _nameBox.Text = name;
                        _nameBox.TextWrapping = System.Windows.TextWrapping.Wrap;

                        _detailsBlock = new TextBlock();
                        _detailsBlock.Text = "Details";

                        _detailsBox = new TextBox();
                        _detailsBox.Text = details;
                        _detailsBox.TextWrapping = System.Windows.TextWrapping.Wrap;

                        _priorityBlock = new TextBlock();
                        _priorityBlock.Text = "Priority";

                        _priorityCombo = new ComboBox();

                        FillPriorityCombo(priority);

                        _stateBlock = new TextBlock();
                        _stateBlock.Text = "State";

                        _stateCombo = new ComboBox();
                        FillStateCombo(state);


                        _applyButton = new ValidateButton(ControlsValues.APPLY, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _nopeButton = new CancelButton(ControlsValues.NOPE, this.Width * 0.6, this.Height * 0.05, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());


                        this.Children.Add(_nameBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_priorityBlock);
                        this.Children.Add(_priorityCombo);
                        this.Children.Add(_stateBlock);
                        this.Children.Add(_stateCombo);
                        this.Children.Add(_detailsBlock);
                        this.Children.Add(_detailsBox);

                        this.Children.Add(_applyButton);
                        this.Children.Add(_nopeButton);
                }

                private void FillPriorityCombo(string priority)
                {
                        _priorityCombo.Items.Add(Priorities.NOT_IMPORTANT);
                        _priorityCombo.Items.Add(Priorities.LESS_IMPORTANT);
                        _priorityCombo.Items.Add(Priorities.IMPORTANT);                       
                        _priorityCombo.Items.Add(Priorities.ULTRA_IMPORTANT); 
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

                        else if (priority.Contains( Priorities.ULTRA_IMPORTANT))
                        {
                                _priorityCombo.SelectedItem = _priorityCombo.Items[3];
                        }

                        else if (priority.Contains( Priorities.MOST_IMPORTANT))
                        {
                                _priorityCombo.SelectedItem = _priorityCombo.Items[4];
                        }
                }//FillPriorityCombo()


                private void FillStateCombo(string state)
                {
                        Constants.Debug.CW("In FillStateCombo, state  = " + state);


                        _stateCombo.Items.Add(States.UIOPEN);
                        _stateCombo.Items.Add(States.UIPROGRESS);
                        _stateCombo.Items.Add(States.UIDONE);

                        if(state.Contains( States.UIOPEN))
                        {
                                _stateCombo.SelectedItem = _stateCombo.Items[0];
                                Constants.Debug.CW("items 0  = " + _stateCombo.Items[0]);
                        }

                        else if (state.Contains( States.UIPROGRESS))
                        {
                                _stateCombo.SelectedItem = _stateCombo.Items[1];
                                Constants.Debug.CW("items 1  = " + _stateCombo.Items[1]);

                        }

                        else if (state.Contains( States.UIDONE))
                        {
                                _stateCombo.SelectedItem = _stateCombo.Items[2];
                                Constants.Debug.CW("items 2  = " + _stateCombo.Items[2]);

                        }
                }//FillStateCombo()




        }//class TaskUpdater
}//ns
