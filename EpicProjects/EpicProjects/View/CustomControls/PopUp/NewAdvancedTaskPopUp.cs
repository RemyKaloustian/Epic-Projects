using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls.Panels;
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

                        _priorityBlock = new TextBlock();
                        _priorityBlock.Text = "Priority";
                        _priorityBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _priorityBlock.FontFamily = FontProvider._lato;
                        _priorityBlock.FontSize = 25;
                        _priorityBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _priorityBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);

                        _priorityBox = new ComboBox();
                        _priorityBox.Width = this.Width * 0.4;
                        _priorityBox.FontSize = 20;
                        _priorityBox.FontFamily = FontProvider._lato;
                        _priorityBox.Items.Add(Priorities.NOT_IMPORTANT);
                        _priorityBox.Items.Add(Priorities.LESS_IMPORTANT);
                        _priorityBox.Items.Add(Priorities.IMPORTANT);
                        _priorityBox.Items.Add(Priorities.MOST_IMPORTANT);
                        _priorityBox.Items.Add(Priorities.ULTRA_IMPORTANT);
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

                       else if (_section == ControlsValues.ASSIGNMENTS)
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
