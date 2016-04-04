using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

using EpicProjects.Constants;
using EpicProjects.Controller;
using System.Windows;
using EpicProjects.View.CustomControls.PopUp;

namespace EpicProjects.View.CustomControls.Home
{
        public class NewProjectPanel : StackPanel
        {
                #region fields
                public TextBlock _titleBlock { get; set; }
                public TextBox _nameBox { get; set; }
                public TextBlock _checkBlock { get; set; }
                public TextBlock _startDateBlock { get; set; }
                public DatePicker _startDatePicker { get; set; }
                public TextBlock _endDateBlock { get; set; }

                public DatePicker _endDatePicker { get; set; }

                public StackPanel _actionsPanel { get; set; }

                public StackPanel _createButton { get; set; }
                public StackPanel _quitButton { get; set; }

                public Theme.Theme _theme { get; set; }

                public Masterchief _chief { get; set; }

                public double _containerWidth { get; set; }
                #endregion

                public NewProjectPanel(StackPanel createProjectButton, StackPanel quitProjectButton, Theme.Theme theme, double width)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        _containerWidth = width;
                        //this.Background = new SolidColorBrush(Colors.Chartreuse);
                        _theme = theme;
                        _chief = new Masterchief();

                        _titleBlock = new TextBlock();
                        _nameBox = new TextBox();
                        _checkBlock = new TextBlock();
                        _startDateBlock = new TextBlock();
                        _startDatePicker = new DatePicker();
                        _endDateBlock = new TextBlock();
                        _endDatePicker = new DatePicker();

                        _actionsPanel = new StackPanel();

                        SetUpTitleBlock(width);
                        SetUpNameBox(width);
                        
                        SetUpDateBlocks();
                        SetUpStartDatePicker(width);
                        SetUpEndDatePicker(width);
                        SetUpCreateProjectButton(createProjectButton, width);
                        SetUpQuitButton(quitProjectButton, width);

                        this.Children.Add(_titleBlock);
                        this.Children.Add(_nameBox);
                        this.Children.Add(_checkBlock);
                        this.Children.Add(_startDateBlock);
                        this.Children.Add(_startDatePicker);
                        this.Children.Add(_endDateBlock);
                        this.Children.Add(_endDatePicker);
                        this.Children.Add(createProjectButton);
                        this.Children.Add(quitProjectButton);

SetUpCheckBlock();
                }

           

                private void SetUpQuitButton(StackPanel quitProjectButton, double width)
                {
                        TextBlock quitBlock = new TextBlock();
                        quitBlock.Text = "Forget it...";
                        quitBlock.FontSize = 25;
                        quitBlock.Padding = new System.Windows.Thickness(0, Convert.ToUInt16(_endDatePicker.Height / 3), 0, 0);
                        quitBlock.FontFamily =FontProvider._lato;
                        quitBlock.Foreground = _theme.GetAccentColor();
                        quitBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;


                        _quitButton = quitProjectButton;
                        _quitButton.Children.Add(quitBlock);
                        _quitButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _quitButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL));
                        _quitButton.Margin = new System.Windows.Thickness(0, 0, 0, width / 60);
                        _quitButton.Width = width / 2;
                        _quitButton.Height = width / 30;
                }

                private void SetUpCreateProjectButton(StackPanel createProjectButton, double width)
                {
                        TextBlock createBlock = new TextBlock();
                        createBlock.Text = "Go on !";
                        createBlock.FontFamily = FontProvider._lato;
                        createBlock.FontSize = 25;
                        createBlock.Foreground = _theme.GetAccentColor();
                        createBlock.Padding = new System.Windows.Thickness(0, Convert.ToUInt16(_endDatePicker.Height / 3), 0, 0);


                        createBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _createButton = createProjectButton;
                        _createButton.Children.Add(createBlock);
                        _createButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _createButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.VALIDATE));
                        _createButton.Width = width / 2;
                        _createButton.Height = width / 30;
                        _createButton.Margin = new System.Windows.Thickness(0, width / 60, 0, width / 60);
                        _createButton.MouseDown += _createButton_MouseDown;


                }

                void _createButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_nameBox.Text == "" || _nameBox.Text == "Name of your project here")
                        {
                                NullInputPopUp popup = new NullInputPopUp(_theme);
                        }

                        else if (  _startDatePicker.SelectedDate == null)
                        {
                                NullInputPopUp popup = new NullInputPopUp(_theme);
                        }
                        else if (_endDatePicker.SelectedDate == null  )
                        {
                                NullInputPopUp popup = new NullInputPopUp(_theme);
                        }

                        else if(isExistingProject(_nameBox.Text))
                        {
                                

                                AlreadyExistingProject aep = new AlreadyExistingProject(Dimensions.GetWidth()/3,Dimensions.GetHeight()/4,ControlsValues.EXISTING_PROJECT);
                        }

                        else
                        {
                                _chief.InsertProject(_nameBox.Text, _startDatePicker.Text, _endDatePicker.Text);
                                Captain oCaptain = new Captain();
                                oCaptain.ToProject(_nameBox.Text);
                        }

                }

                private bool isExistingProject(string projectName)
                {
                        List<string> existingProjects = _chief.SelectProjects();

                        foreach (string item in existingProjects)
                        {
                                if (item.ToLower() == _nameBox.Text.ToLower())
                                {
                                       
                                        return true;
                                }
                        }

                        return false;
                }


                private   void SetUpDateBlocks()
                {
                        _startDateBlock.Text = ControlsValues.STARTDATE;
                        _startDateBlock.FontFamily = FontProvider._lato;
                        _startDateBlock.Foreground = _theme.GetAccentColor();
                        _startDateBlock.FontSize = 25;


                        _startDateBlock.Margin = new Thickness(_containerWidth- _nameBox.Width - (_containerWidth - _nameBox.Width) / 2, _containerWidth/90, 0, 0);
                        _endDateBlock.Text = ControlsValues.ENDATE;
                        _endDateBlock.FontFamily = FontProvider._lato;
                        _endDateBlock.FontSize = 25;
                        _endDateBlock.Margin = new Thickness(_containerWidth- _nameBox.Width - (_containerWidth - _nameBox.Width) / 2, _containerWidth/90, 0, 0);
                        _endDateBlock.Foreground = _theme.GetAccentColor();
                }

                private void SetUpEndDatePicker(double width)
                {
                        _endDatePicker.Width = width / 2;
                     
                        _endDatePicker.FontSize = 20;
                        _endDatePicker.Height = width / 40;
                        _endDatePicker.Foreground = new SolidColorBrush(Colors.Gray);
                        _endDatePicker.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                        _endDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                }

                private void SetUpStartDatePicker(double width)
                {
                        _startDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _startDatePicker.Width = width / 2;

                        _startDatePicker.FontSize = 20;
                        _startDatePicker.Height = width / 40;
                        _startDatePicker.Foreground = new SolidColorBrush(Colors.Gray);
                        _startDatePicker.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                }

                private void SetUpNameBox(double width)
                {
                        _nameBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBox.Text = ControlsValues.NAME;
                        _nameBox.Width = width / 2;
                        _nameBox.Height = width / 40;
                        _nameBox.FontSize = 20;
                        _nameBox.Foreground = new SolidColorBrush(Colors.Gray);
                        _nameBox.GotFocus += _nameBox_GotFocus;
                        _nameBox.LostFocus += _nameBox_LostFocus;
                        _nameBox.TextChanged += _nameBox_TextChanged;
                        _nameBox.LostFocus +=_nameBox_LostFocus;
                }

                private void SetUpCheckBlock()
                {
                        double leftMargin = _containerWidth- _nameBox.Width-(_containerWidth-_nameBox.Width)/2;
                        _checkBlock.Margin = new Thickness(leftMargin, 0, 0, 0);
                        _checkBlock.FontFamily = FontProvider._aleo;
                        _checkBlock.FontSize = 20;
                        
                }

                void _nameBox_TextChanged(object sender, TextChangedEventArgs e)
                {
                        _checkBlock.Visibility = System.Windows.Visibility.Visible;

                        if(_nameBox.Text.Length ==0)
                        {
                                _createButton.IsEnabled = false;
                                _checkBlock.Text = ControlsValues.NULL;
                                _checkBlock.Foreground = Palette2.GetColor(Palette2.MIDNIGHT_BLUE);
                        }
                        else
                        {
                                if(!isExistingProject(_nameBox.Text))
                                {
                                        _checkBlock.Text = ControlsValues.VALID;
                                        _createButton.IsEnabled = true;
                                        _checkBlock.Foreground = Palette2.GetColor(Palette2.TURQUOISE);

                                }

                                else
                                {
                                        _checkBlock.Text = ControlsValues.EXISTING_PROJECT;
                                        _createButton.IsEnabled = false;
                                        _checkBlock.Foreground = Palette2.GetColor(Palette2.MIDNIGHT_BLUE);

                                }
                        }
                }//_nameBox_TextChanged()

                private void SetUpTitleBlock(double width)
                {
                        _titleBlock.Text = ControlsValues.NEW_PROJECT_TITLE;
                        _titleBlock.FontFamily = FontProvider._edmond;
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = _theme.GetAccentColor();
                        _titleBlock.Margin = new System.Windows.Thickness(0, width / 40, 0, width / 60);
                        
                }

                void _nameBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
                {
                        if (_nameBox.Text == "")
                        {
                                _nameBox.Text = ControlsValues.NAME;
                                _nameBox.Foreground = new SolidColorBrush(Colors.Gray);
                                _checkBlock.Visibility = System.Windows.Visibility.Hidden;
                        }

                }

                void _nameBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
                {
                        _nameBox.Text = "";
                        _nameBox.Foreground = new SolidColorBrush(Colors.Black);
                }
        }//class NewProjectPanel
}//ns
