using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.Controller;
using EpicProjects.Constants;

namespace EpicProjects.View.CustomControls
{
        /// <summary>
        /// This class represents a task on the UI
        /// </summary>
        public class TaskPanel : StackPanel
        {
                public TaskMasterChief _chief { get; set; }

                public TextBlock _nameBlock { get; set; }
                public Button _editButton { get; set; }
                public Button _deleteButton { get; set; }
                public TextBox _editBox { get; set; }

                public bool _isEditing { get; set; }

                public string _lastName { get; set; }

                public TaskPanel(string name)
                {
                        _isEditing = false;
                        _chief = new TaskMasterChief(name);

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = name;

                        _editButton = new Button();
                        _editButton.Content = ControlsValues.EDIT;
                        _editButton.Click += _editButton_Click;

                        _deleteButton = new Button();
                        _deleteButton.Content = ControlsValues.DELETE;
                        _deleteButton.Click += _deleteButton_Click;

                        _editBox = new TextBox();
                        _editBox.Text = _nameBlock.Text;

                        _lastName = _nameBlock.Text;

                        this.Orientation = Orientation.Horizontal;

                        this.Children.Add(_nameBlock);
                        this.Children.Add(_editButton);
                        this.Children.Add(_deleteButton);
                }

                void _editButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        if(_isEditing)
                        {
                                CloseTaskEditing();
                                _isEditing = false;
                        }
                        else if(!_isEditing)
                        {
                                OpenTaskEditing();
                                _isEditing = true;
                        }
                }//TaskPanel()

                void _deleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        _chief.DeleteTask(_nameBlock.Text);
                       // StackPanel parent = this.Parent as StackPanel;
                        this.Visibility = System.Windows.Visibility.Hidden;
                        
                }//_deleteButton_Click()

                private void CloseTaskEditing()
                {
                        _chief.UpdateTask(_lastName, _editBox.Text);

                        _nameBlock.Text = _editBox.Text;

                        this.Children.Remove(_editBox);
                        this.Children.Remove(_editButton);
                        this.Children.Remove(_deleteButton);

                        this.Children.Add(_nameBlock);
                        this.Children.Add(_editButton);
                        this.Children.Add(_deleteButton);
                }

                private void OpenTaskEditing()
                {
                        this.Children.Remove(_nameBlock);
                        this.Children.Remove(_editButton);
                        this.Children.Remove(_deleteButton);

                        this.Children.Add(_editBox);
                        this.Children.Add(_editButton);
                        this.Children.Add(_deleteButton);
                }


        }//class TaskPanel
}//ns
