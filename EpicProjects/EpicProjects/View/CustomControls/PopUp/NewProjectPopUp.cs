﻿using EpicProjects.Constants;
using EpicProjects.Constants.Colors;
using EpicProjects.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.PopUp
{
        public class NewProjectPopUp:PopUp
        {
                public Separator _separator { get; set; }
                public TextBlock _nameBlock { get; set; }
                public TextBox _nameBox{ get; set; }
                public TextBlock _alertBlock{ get; set; }

                public TextBlock _startDateBlock { get; set; }
                public DatePicker _startDatePicker{ get; set; }
                public TextBlock _endDateBlock { get; set; }
                public DatePicker _endDatePicker{ get; set; }

                public ValidateButton _validateButton { get; set; }
                public CancelButton _cancelButton{ get; set; }
                public NewProjectPopUp(double width, double height, string content) : base(width,height,content)
                {
                        this.Background = Palette2.GetColor(WindowsPhonePalette.STEEL);

                        SetUpSeparator();
                        SetUpNameBlock();
                        SetUpNameBox();
                        SetUpAlertBlock();
                        SetUpStartDateBlock();
                        SetUpStartPicker();
                        SetUpEndDateBlock();
                        SetUpEndPicker();
                        SetUpButtons();

                        _container.Children.Add(_separator);
                        _container.Children.Add(_nameBlock);
                        _container.Children.Add(_nameBox);
                        _container.Children.Add(_alertBlock);
                        _container.Children.Add(_startDateBlock);
                        _container.Children.Add(_startDatePicker);
                        _container.Children.Add(_endDateBlock);
                        _container.Children.Add(_endDatePicker);
                        _container.Children.Add(_validateButton);
                        _container.Children.Add(_cancelButton);

                }

                private void SetUpButtons()
                {
                        _validateButton = new ValidateButton("Create", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _validateButton.MouseDown += _validateButton_MouseDown;
                        _validateButton.IsEnabled = false;

                        _cancelButton = new CancelButton("Cancel", this.Width * 0.5, this.Height * 0.07, new System.Windows.Thickness(0, 30, 0, 30), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center, new Theme.CustomTheme());

                        _cancelButton.MouseDown += _cancelButton_MouseDown;
                }

                private void SetUpEndPicker()
                {
                        _endDatePicker = new DatePicker();
                        _endDatePicker.Width = this.Width * 0.5;
                        _endDatePicker.Height = this.Height * 0.05;
                }

                private void SetUpEndDateBlock()
                {
                        _endDateBlock = new TextBlock();
                        _endDateBlock.Text = "End date";
                        _endDateBlock.FontFamily = FontProvider._lato;
                        _endDateBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _endDateBlock.FontSize = 20;
                        _endDateBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _endDateBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                private void SetUpStartPicker()
                {
                        _startDatePicker = new DatePicker();
                        _startDatePicker.Width = this.Width * 0.5;
                        _startDatePicker.Height = this.Height * 0.05;
                }

                private void SetUpStartDateBlock()
                {
                        _startDateBlock = new TextBlock();
                        _startDateBlock.Text = "Start date";
                        _startDateBlock.FontFamily = FontProvider._lato;
                        _startDateBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _startDateBlock.FontSize = 20;
                        _startDateBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _startDateBlock.Margin = new System.Windows.Thickness(0, 20, 0, 0);
                }

                private void SetUpAlertBlock()
                {

                        _alertBlock = new TextBlock();
                        _alertBlock.FontFamily = FontProvider._open;
                        _alertBlock.FontSize = 15;
                        _alertBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        double left = this.Width - _nameBox.Width - ((this.Width - _nameBox.Width) / 2);

                        _alertBlock.Margin = new System.Windows.Thickness(left, 0, 0, 0);
                }

                private void SetUpNameBox()
                {
                        _nameBox = new TextBox();
                        _nameBox.Width = this.Width * 0.5;
                        _nameBox.FontFamily = FontProvider._lato;
                        _nameBox.FontSize = 15;
                        _nameBox.Height = this.Height * 0.05;
                        _nameBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBox.TextChanged += _nameBox_TextChanged;
                }

                private void SetUpNameBlock()
                {
                        _nameBlock = new TextBlock();
                        _nameBlock.Text = "Name";
                        _nameBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.FontSize = 20;
                        _nameBlock.Foreground = new Theme.CustomTheme().GetBackground();
                        _nameBlock.Margin = new System.Windows.Thickness(0, 30, 0, 0);
                }

                private void SetUpSeparator()
                {
                        _separator = new Separator();
                        _separator.Width = this.Width * 0.5;
                        _separator.Background = new Theme.CustomTheme().GetBackground();
                }

                void _nameBox_TextChanged(object sender, TextChangedEventArgs e)
                {
                        if(_nameBox.Text.Trim() == "")
                        {
                                _alertBlock.Text = "Null input is not allowed.";
                                _validateButton.IsEnabled = false;
                        }

                        else if(new Checker().IsProjectExisting(_nameBox.Text))
                        {

                                _alertBlock.Text = "There is already a project named like this.";
                                _validateButton.IsEnabled = false;
                        }

                        else
                        {
                                _alertBlock.Text = "Name is valid";
                                _validateButton.IsEnabled = true;
                        }
                }

                void _validateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        string startDateValue;

                        if (_startDatePicker.SelectedDate == null)
                        {
                                startDateValue = "";
                        }
                        else
                        {
                                startDateValue = _startDatePicker.SelectedDate.Value.ToString();
                        }

                        string endDateValue ;

                        if (_endDatePicker.SelectedDate == null)
                        {
                                endDateValue = "";
                        }
                        else
                        {
                                endDateValue = _endDatePicker.SelectedDate.Value.ToString();
                        }
                        
                 
                        new ProjectMasterChief().InsertProject(_nameBox.Text, startDateValue, endDateValue);

                        new Captain().ToProject(_nameBox.Text);
                        this.Close();
                }

                void _cancelButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        this.Close();
                }
        }//class NewProjectPopUp
}//ns