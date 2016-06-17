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
        public class NewAdvancedTaskPopUp:  NewTaskPopUp
        {
                public TextBlock _priorityBlock { get; set; }

                public ComboBox _priorityBox { get; set; }

                public string  _taskType { get; set; }


                public NewAdvancedTaskPopUp(double width, double height, string content, string projectName, bool isAdvanced, ContentPanel contentPanel):base(width,height,content,projectName,isAdvanced, contentPanel)
                {

                        _nameBox.MaxLength = 80;

                        _priorityBlock = new TextBlock();
                        _priorityBlock.Text = "Priority";
                        _priorityBlock.Foreground = ThemeSelector.GetBackground();
                        _priorityBlock.FontFamily = FontProvider._lato;
                        _priorityBlock.FontSize = Responsive.GetButtonTextSize();
                        _priorityBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _priorityBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                        _priorityBox = new ComboBox();
                        _priorityBox.Width = this.Width * 0.4;
                        _priorityBox.FontSize = Responsive.GetComboSize();
                        _priorityBox.FontFamily = FontProvider._lato;
                        _priorityBox.Items.Add(Priorities.NOT_IMPORTANT);
                        _priorityBox.Items.Add(Priorities.LESS_IMPORTANT);
                        _priorityBox.Items.Add(Priorities.IMPORTANT);
                        _priorityBox.Items.Add(Priorities.MOST_IMPORTANT);
                        _priorityBox.SelectedItem = _priorityBox.Items[2];


                        _validateButton.MouseDown += _validateButton_MouseDown;

                        _container.Children.Add(_priorityBlock);
                        _container.Children.Add(_priorityBox);

                      

                        _container.Children.Add(_validateButton);
                        _container.Children.Add(_cancelButton);
                        //TreatContent();


                        //Change header text
                }

                void _validateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {

                       if(_section == ControlsValues.TRAINING)
                       {
                               new TaskMasterChief(_projectName).InsertTraining(_nameBox.Text, _detailsBox.Text, _priorityBox.Text);
                               _contentPanel.LoadTraining();
                       }

                       else if (ControlsValues.ASSIGNMENTS.Contains(_section))
                       {
                               new TaskMasterChief(_projectName).InsertAssignment(_nameBox.Text, _detailsBox.Text, _priorityBox.Text);
                               _contentPanel.LoadAssignments();
                       }

                       else if (_section == ControlsValues.MAINTENANCE)
                       {
                               new TaskMasterChief(_projectName).InsertMaintenance(_nameBox.Text, _detailsBox.Text, _priorityBox.Text);
                               _contentPanel.LoadMaintenance();
                       }
                }//_validateButton_MouseDown()

               
        }//class NewAdvancedTaskPopUp
}//ns
