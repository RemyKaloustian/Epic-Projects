﻿using System;
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
using EpicProjects.View.Theme;
using EpicProjects.View.CustomControls.Blocks;

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

                public StatsBlock _dateAlert { get; set; }

                public StackPanel _actionsPanel { get; set; }

                public ValidateButton _createButton { get; set; }
                public CancelButton _quitButton { get; set; }

                public Theme.Theme _theme { get; set; }

                public Masterchief _chief { get; set; }

                public double _containerWidth { get; set; }
                #endregion

                public NewProjectPanel(ValidateButton createProjectButton, CancelButton quitProjectButton, double width)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        _containerWidth = width;
                        //this.Background = new SolidColorBrush(Colors.Chartreuse);
                        
                        _chief = new Masterchief();

                        _titleBlock = new TextBlock();
                        _nameBox = new TextBox();
                        _checkBlock = new TextBlock();
                        _startDateBlock = new TextBlock();
                        _startDatePicker = new DatePicker();
                        _endDateBlock = new TextBlock();
                        _endDatePicker = new DatePicker();

                        _actionsPanel = new StackPanel();

                        _dateAlert = new StatsBlock();
                        _dateAlert.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

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
                        this.Children.Add(_dateAlert);
                        this.Children.Add(createProjectButton);
                        this.Children.Add(quitProjectButton);

SetUpCheckBlock();
                }

           

                private void SetUpQuitButton(CancelButton quitProjectButton, double width)
                {
                        TextBlock quitBlock = new TextBlock();
                        //quitBlock.Text = "Forget it...";
                        //quitBlock.FontSize = 25;
                        //quitBlock.Padding = new System.Windows.Thickness(0, Convert.ToUInt16(_endDatePicker.Height / 3), 0, 0);
                        //quitBlock.FontFamily =FontProvider._lato;
                        //quitBlock.Foreground = ThemeSelector.GetAccentColor();
                        //quitBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;


                        //_quitButton = quitProjectButton;
                        //_quitButton.Children.Add(quitBlock);
                        //_quitButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        //_quitButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL));
                        //_quitButton.Margin = new System.Windows.Thickness(0, 0, 0, width / 60);
                        //_quitButton.Width = width / 2;
                        //_quitButton.Height = width / 30;
                }

                private void SetUpCreateProjectButton(ValidateButton createProjectButton, double width)
                {
                        TextBlock createBlock = new TextBlock();
                        //createBlock.Text = "Go on !";
                        //createBlock.FontFamily = FontProvider._lato;
                        //createBlock.FontSize = 25;
                        //createBlock.Foreground = ThemeSelector.GetAccentColor();
                        //createBlock.Padding = new System.Windows.Thickness(0, Convert.ToUInt16(_endDatePicker.Height / 3), 0, 0);


                        //createBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        _createButton = createProjectButton;
                        //_createButton.Children.Add(createBlock);
                        //_createButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        //_createButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.VALIDATE));
                        //_createButton.Width = width / 2;
                        //_createButton.Height = width / 30;
                        //_createButton.Margin = new System.Windows.Thickness(0, width / 60, 0, width / 60);
                        _createButton.MouseDown += _createButton_MouseDown;


                }

                void _createButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        if (_nameBox.Text == "" || _nameBox.Text == "Name of your project here")
                        {
                                NullInputPopUp popup = new NullInputPopUp();
                        }

                        else if (  _startDatePicker.SelectedDate == null)
                        {
                                NullInputPopUp popup = new NullInputPopUp();
                        }
                        else if (_endDatePicker.SelectedDate == null  )
                        {
                                NullInputPopUp popup = new NullInputPopUp();
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
                        return new Checker().IsProjectExisting(projectName);
                }


                private   void SetUpDateBlocks()
                {
                        _startDateBlock.Text = ControlsValues.STARTDATE;
                        _startDateBlock.FontFamily = FontProvider._lato;
                        _startDateBlock.Foreground = ThemeSelector.GetAccentColor();
                        _startDateBlock.FontSize = 25;


                        _startDateBlock.Margin = new Thickness(_containerWidth- _nameBox.Width - (_containerWidth - _nameBox.Width) / 2, _containerWidth/90, 0, 0);
                        _endDateBlock.Text = ControlsValues.ENDATE;
                        _endDateBlock.FontFamily = FontProvider._lato;
                        _endDateBlock.FontSize = 25;
                        _endDateBlock.Margin = new Thickness(_containerWidth- _nameBox.Width - (_containerWidth - _nameBox.Width) / 2, _containerWidth/90, 0, 0);
                        _endDateBlock.Foreground = ThemeSelector.GetAccentColor();
                }

                private void SetUpEndDatePicker(double width)
                {
                        _endDatePicker.Width = width / 2;
                     
                        _endDatePicker.FontSize = 20;
                        _endDatePicker.Height = width / 40;
                        _endDatePicker.Foreground = new SolidColorBrush(Colors.Gray);
                        _endDatePicker.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                        _endDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _endDatePicker.SelectedDateChanged += _endDatePicker_SelectedDateChanged;
                }

                void _endDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
                {
                        if (_endDatePicker.SelectedDate < _startDatePicker.SelectedDate)
                        {
                                _createButton.IsEnabled = false;
                                _dateAlert.Text = "You can't end a project before begining it.";
                        }

                        else
                        {
                                _createButton.IsEnabled = true;
                                _dateAlert.Text = "";
                        }
                }

                private void SetUpStartDatePicker(double width)
                {
                        _startDatePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _startDatePicker.Width = width / 2;

                        _startDatePicker.FontSize = 20;
                        _startDatePicker.Height = width / 40;
                        _startDatePicker.Foreground = new SolidColorBrush(Colors.Gray);
                        _startDatePicker.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                        _startDatePicker.SelectedDateChanged += _endDatePicker_SelectedDateChanged;
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
                        _checkBlock.FontFamily = FontProvider._lato;
                        _checkBlock.FontSize = 20;
                        _checkBlock.Foreground = ThemeSelector.GetAlertColor() ;
                        
                }

                void _nameBox_TextChanged(object sender, TextChangedEventArgs e)
                {
                        _checkBlock.Visibility = System.Windows.Visibility.Visible;

                        if(_nameBox.Text.Length ==0)
                        {
                                _createButton.IsEnabled = false;
                                _checkBlock.Text = ControlsValues.NULL;
                                
                        }
                        else
                        {
                                if(!isExistingProject(_nameBox.Text))
                                {
                                        _checkBlock.Text = ControlsValues.VALID;
                                        _createButton.IsEnabled = true;

                                }

                                else
                                {
                                        _checkBlock.Text = ControlsValues.EXISTING_PROJECT;
                                        _createButton.IsEnabled = false;

                                }
                        }
                }//_nameBox_TextChanged()

                private void SetUpTitleBlock(double width)
                {
                        _titleBlock.Text = ControlsValues.NEW_PROJECT_TITLE;
                        _titleBlock.FontFamily = FontProvider._proxima;
                        _titleBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _titleBlock.FontSize = 25;
                        _titleBlock.Foreground = ThemeSelector.GetAccentColor();
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
