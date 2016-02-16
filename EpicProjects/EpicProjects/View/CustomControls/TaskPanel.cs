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

                public TaskPanel(string name)
                {
                        _chief = new TaskMasterChief();

                        _nameBlock = new TextBlock();
                        _nameBlock.Text = name;

                        _editButton = new Button();
                        _editButton.Content = ControlsValues.EDIT;

                        _deleteButton = new Button();
                        _deleteButton.Content = ControlsValues.DELETE;
                        _deleteButton.Click += _deleteButton_Click;

                        this.Orientation = Orientation.Horizontal;

                        this.Children.Add(_nameBlock);
                        this.Children.Add(_editButton);
                        this.Children.Add(_deleteButton);
                }//TaskPanel()

                void _deleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
                {
                        _chief.DeleteTask(_nameBlock.Text);
                       // StackPanel parent = this.Parent as StackPanel;
                        this.Visibility = System.Windows.Visibility.Hidden;
                        
                }//_deleteButton_Click()


        }//class TaskPanel
}//ns
