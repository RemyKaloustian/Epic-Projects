using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpicProjects.View.CustomControls.Home
{
        public class NewProjectPanel : StackPanel
        {
                public TextBlock _titleBlock { get; set; }
                public TextBox _nameBox { get; set; }
                public DatePicker _startDatePicker { get; set; }
                public DatePicker _endDatePicker { get; set; }

                public StackPanel _createButton { get; set; }
                public StackPanel _quitButton { get; set; }

                public NewProjectPanel(StackPanel createProjectButton, StackPanel quitProjectButton )
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        //this.Background = new SolidColorBrush(Colors.Chartreuse);


                        _titleBlock = new TextBlock();
                        _nameBox = new TextBox();
                        _startDatePicker = new DatePicker();
                        _endDatePicker = new DatePicker();
                      

                        _titleBlock.Text = "Already making a new project ? You are so dynamic !";
                        _titleBlock.FontFamily = new System.Windows.Media.FontFamily("Edmondsans Regular");
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.FontSize = 25;

                        _nameBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBox.Text = "Name of your project here";

                        _startDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _endDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        TextBlock createBlock = new TextBlock();
                        createBlock.Text = "Create";
                        createProjectButton.Children.Add(createBlock);
                        createProjectButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        createProjectButton.Background = new SolidColorBrush(Colors.Green);

                        TextBlock quitBlock = new TextBlock();
                        quitBlock.Text = "Forget it...";
                        quitProjectButton.Children.Add(quitBlock);
                        quitProjectButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        quitProjectButton.Background = new SolidColorBrush(Colors.IndianRed);

                        this.Children.Add(_titleBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_startDatePicker);
                        this.Children.Add(_endDatePicker);
                        this.Children.Add(createProjectButton);
                        this.Children.Add(quitProjectButton);

                }
        }//class NewProjectPanel
}//ns
