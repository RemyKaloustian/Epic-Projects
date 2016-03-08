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

                public Theme.Theme _theme { get; set; }

                public NewProjectPanel(StackPanel createProjectButton, StackPanel quitProjectButton, Theme.Theme theme, double width )
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        //this.Background = new SolidColorBrush(Colors.Chartreuse);
                        _theme = theme;

                        _titleBlock = new TextBlock();
                        _nameBox = new TextBox();
                        _startDatePicker = new DatePicker();
                        _endDatePicker = new DatePicker();
                      

                        _titleBlock.Text = "Already making a new project ? You are so dynamic !";
                        _titleBlock.FontFamily = new System.Windows.Media.FontFamily("Edmondsans Regular");
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = _theme.GetAccentColor();
                        _titleBlock.Margin = new System.Windows.Thickness(0, width / 40, 0, width/60);

                        _nameBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBox.Text = "Name of your project here";
                        _nameBox.Width = width / 2;
                        _nameBox.Height = width / 40;
                        _nameBox.FontSize = 20;
                        _nameBox.Foreground = new SolidColorBrush(Colors.Gray);
                        _nameBox.GotFocus += _nameBox_GotFocus;
                        _nameBox.LostFocus += _nameBox_LostFocus;

                        _startDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _startDatePicker.Width = width / 2;
                        _startDatePicker.Text = "Start date of your project";
                        _startDatePicker.FontSize = 20;
                        _startDatePicker.Height = width / 40;
                        _startDatePicker.Foreground = new SolidColorBrush(Colors.Gray);
                        _startDatePicker.Margin = new System.Windows.Thickness(0, width / 60, 0, 0);


                        _endDatePicker.Width = width / 2;
                        _endDatePicker.Text = "Ending date of your project";
                        _endDatePicker.FontSize = 20;
                        _endDatePicker.Height = width / 40;
                        _endDatePicker.Foreground = new SolidColorBrush(Colors.Gray);
                        _endDatePicker.Margin = new System.Windows.Thickness(0, width / 60, 0, 0);


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

                void _nameBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
                {
                        if(_nameBox.Text == "")
                        {
                                _nameBox.Text = "Name of your project here";
                                _nameBox.Foreground = new SolidColorBrush(Colors.Gray);
                        }
                       
                }

                void _nameBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
                {
                        _nameBox.Text = "";
                        _nameBox.Foreground = new SolidColorBrush(Colors.Black);
                }
        }//class NewProjectPanel
}//ns
