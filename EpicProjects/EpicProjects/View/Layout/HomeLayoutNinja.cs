﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using EpicProjects.View.Theme;
using EpicProjects.Constants;
using System.Windows.Media;
using EpicProjects.View.CustomControls;
using EpicProjects.View.CustomControls.Home;
using EpicProjects.Controller;
using System.Windows.Input;
using System.Windows;
using EpicProjects.View.CustomControls.PopUp;
using EpicProjects.Database;


namespace EpicProjects.View.Layout
{
        public class HomeLayoutNinja : LayoutNinja
        {
                public Theme.Theme _theme { get; set; }
                public Masterchief _chief { get; set; }

                public StackPanel _mainPanel { get; set; }
                public StackPanel _containerPanel { get; set; }

                public StackPanel _headerPanel { get; set; }

                public TextBlock _windowTitle{ get; set; }
                public TextBlock _catchPhrase { get; set; }

                public Separator _headerSeparator { get; set; }

                public StackPanel _itemsPanel { get; set; }
                public Separator _itemsSeparator { get; set; }

                public HomeItem _settingsItem { get; set; }
                public HomeItem _newProjectItem { get; set; }
                public HomeItem _openProjectItem { get; set; }

                public StackPanel _subContainer { get; set; }

                public StackPanel _latestProjectsPanel { get; set; }
                public TextBlock _latestBlock { get; set; }
                public Separator _latestSeparator { get; set; }
                public ValidateButton _projectOpening{ get; set; }

                public StackPanel _footerPanel { get; set; }
                public TextBlock _remyBlock { get; set; }
                public TextBlock _siteBlock{ get; set; }

                public ValidateButton _createProjectButton { get; set; }
                public CancelButton  _quitProjectButton{ get; set; }

                public HomeLayoutNinja()
                {
                        _theme = new CustomTheme();
                        _chief = new Masterchief();

                        
                        SetUpMainAndContainer();

                        SetUpHeader();

                        SetUpItems();

                        SetUpLatestProjects();

                        SetUpFooter();
                        
                }//HomeLayoutNinja()



# region Layout_Handling

                private void SetUpFooter()
                {
                        _footerPanel = new StackPanel();
                        _footerPanel.Orientation = Orientation.Vertical;

                        _remyBlock = new TextBlock();
                        _remyBlock.Text = "Created by Rémy Kaloustian | remykaloustian.com";
                        _remyBlock.Foreground = ThemeSelector.GetAccentColor();
                        _remyBlock.FontFamily = FontProvider._lato;
                        _remyBlock.FontSize = 20;
                        _remyBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _remyBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);


                        _siteBlock = new TextBlock();
                        _siteBlock.Text = "http://remykaloustian.com/epic";
                        _siteBlock.Foreground = ThemeSelector.GetAccentColor();
                        _siteBlock.FontFamily = FontProvider._lato;
                        _siteBlock.FontSize = 20;
                        _siteBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _siteBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);


                        _footerPanel.Children.Add(_remyBlock);
                        _footerPanel.Children.Add(_siteBlock);

                        _subContainer.Children.Add(_footerPanel);
                }

                private void SetUpLatestProjects()
                {
                        _subContainer = new StackPanel();
                        _subContainer.Orientation = Orientation.Vertical;


                        _latestProjectsPanel = new StackPanel();
                        _latestProjectsPanel.Orientation = Orientation.Vertical;
                        _latestProjectsPanel.Width = _containerPanel.Width;

                        SetUpLatestTitle();                        
                        SetUpLatestProjectsNames();

                        _projectOpening = new ValidateButton("Open the app on last project", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30, 0, 10), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);

                        _projectOpening.MouseDown += _projectOpening_MouseDown;
                        //_latestProjectsPanel.Children.Add(_projectOpening);

                        SetUpLatestSeparator();


                        _subContainer.Children.Add(_latestProjectsPanel);

                        _containerPanel.Children.Add(_subContainer);
                }

                void _projectOpening_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        if(_projectOpening._block.Text == "Open the app on last project")
                        {
                                _projectOpening._block.Text = "Show the home page on opening";
                                Preferences.SetOpening(false);
                        }
                        else
                        {
                                _projectOpening._block.Text = "Open the app on last project";
                                Preferences.SetOpening(true);

                        }
                }

                #region SetUp
                private void SetUpMainAndContainer()
                {
                        _mainPanel = new StackPanel();
                        _containerPanel = new StackPanel();
                        _containerPanel.Orientation = Orientation.Vertical;
                        _containerPanel.Height = Dimensions.GetHeight();
                        _containerPanel.Width = Dimensions.GetWidth() * 0.9;
                       // _containerPanel.Background = new SolidColorBrush(Colors.Black);


                        _mainPanel.Children.Add(_containerPanel);
                        _mainPanel.Background = ThemeSelector.GetBackground();
                }

                private void SetUpWindowTitle()
                {
                        _windowTitle.Text = "EPIC PROJECTS";
                        _windowTitle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _windowTitle.FontFamily = FontProvider._code;
                        _windowTitle.Foreground = ThemeSelector.GetAccentColor();
                        _windowTitle.FontSize = 82;
                        _windowTitle.Padding = new System.Windows.Thickness(0, Convert.ToDouble(Dimensions.GetHeight() / 40), 0, 0);
                }

                private void SetUpCatchPhrase()
                {
                        _catchPhrase.Text = "Lead your projects like a boss.";
                        _catchPhrase.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _catchPhrase.FontFamily = FontProvider._proxima;
                        _catchPhrase.Foreground = ThemeSelector.GetAccentColor();
                        _catchPhrase.FontSize = 40;
                        _catchPhrase.Padding = new System.Windows.Thickness(0, Convert.ToDouble(Dimensions.GetHeight() / 50), 0, Convert.ToDouble(Dimensions.GetHeight() / 50));
                }

                private void FillHeader()
                {
                        _headerPanel = new StackPanel();
                        _headerPanel.Orientation = Orientation.Vertical;
                        _headerPanel.Children.Add(_windowTitle);
                        _headerPanel.Children.Add(_catchPhrase);
                        _headerPanel.Children.Add(_headerSeparator);

                        _containerPanel.Children.Add(_headerPanel);
                }

                private void SetUpHeader()
                {
                        _windowTitle = new TextBlock();
                        _catchPhrase = new TextBlock();
                        _headerSeparator = new Separator();

                        SetUpWindowTitle();

                        SetUpCatchPhrase();

                        _headerSeparator.Width = _containerPanel.Width;
                        _headerSeparator.Background = ThemeSelector.GetAccentColor();

                        FillHeader();
                }

                private void SetUpItems()
                {
                        _itemsPanel = new StackPanel();
                        _itemsPanel.Orientation = Orientation.Horizontal;
                        _itemsPanel.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);

                        _settingsItem = new HomeItem(ControlsValues.SETTINGS, Shortcuts.SETTINGS, _containerPanel.Width / 4, "");
                        _settingsItem.MouseDown += _settingsItem_MouseDown;

                        _itemsPanel.Children.Add(_settingsItem);

                        _newProjectItem = new HomeItem(ControlsValues.OPENPROJECT, Shortcuts.OPEN, _containerPanel.Width / 4, "");

                        _itemsPanel.Children.Add(_newProjectItem);

                        _openProjectItem = new HomeItem(ControlsValues.NEWPROJECT, Shortcuts.NEW, _containerPanel.Width / 4, "");
                        _itemsPanel.Children.Add(_openProjectItem);

                        //_itemsPanel.Children.Add(new HomeItem(ControlsValues.DOCUMENTATION, Shortcuts.DOC, _containerPanel.Width / 5, ""));

                        HomeItem report = new HomeItem(ControlsValues.REPORT, Shortcuts.BUG, _containerPanel.Width / 4, "");
                        _itemsPanel.Children.Add(report);
                        report.MouseDown += report_MouseDown;

                        _itemsSeparator = new Separator();
                        _itemsSeparator.Width = _containerPanel.Width;
                        _itemsSeparator.Background = ThemeSelector.GetAccentColor();
                        _itemsSeparator.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 20, 0, 0);




                        _containerPanel.Children.Add(_itemsPanel);
                        //Bacause it would be displayed horizontally
                        _containerPanel.Children.Add(_itemsSeparator);

                }

                void report_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        ReportBug rep = new ReportBug(Dimensions.GetWidth() * 0.5, Dimensions.GetHeight() * 0.8, "Report a bug");
                        rep.Show();
                }

              

                void _settingsItem_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        new Captain().ToSettings("home");
                }

                private void SetUpLatestTitle()
                {

                        _latestBlock = new TextBlock();
                        _latestBlock.Text = "Latest Projects";
                        _latestBlock.FontFamily = FontProvider._proxima;
                        _latestBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _latestBlock.FontSize = 45;
                        _latestBlock.Foreground = ThemeSelector.GetAccentColor();
                        _latestBlock.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);

                        _latestProjectsPanel.Children.Add(_latestBlock);
                }

                private void SetUpLatestProjectsNames()
                {
                        List<string> latestProjects = Preferences.GetLatestProjects();

                        foreach (var item in latestProjects)
                        {
                                ProjectLink link = new ProjectLink(item, ThemeSelector.GetAccentColor());
                                _latestProjectsPanel.Children.Add(link);
                        }
                }

                private void SetUpLatestSeparator()
                {

                        _latestSeparator = new Separator();
                        _latestSeparator.Width = _containerPanel.Width;
                        _latestSeparator.Background = ThemeSelector.GetAccentColor();
                        _latestSeparator.Margin = new System.Windows.Thickness(0, _containerPanel.Height / 30, 0, 0);

                        _latestProjectsPanel.Children.Add(_latestSeparator);
                }
                #endregion

                #region layout
                public override StackPanel GetLayout()
                {
                        return _mainPanel;
                }

                public StackPanel GetNewProjectPanel()
                {
                        _createProjectButton = new ValidateButton("Go On !", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 30, 0, 10), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _createProjectButton.MaxHeight = 60;
                        _createProjectButton.MouseDown += _createProjectButton_MouseDown;
                        _createProjectButton.MouseEnter += _createProjectButton_MouseEnter;
                        _createProjectButton.MouseLeave += _createProjectButton_MouseLeave;

                        _quitProjectButton = new CancelButton("Never mind", Dimensions.GetWidth() * 0.3, Dimensions.GetHeight() * 0.07, new System.Windows.Thickness(0, 0, 0, 0), new System.Windows.Thickness(5, 5, 5, 5), System.Windows.HorizontalAlignment.Center);
                        _quitProjectButton.MaxHeight = 60;
                        _quitProjectButton.MouseDown += _quitProjectButton_MouseDown;
                        _quitProjectButton.MouseEnter += _quitProjectButton_MouseEnter;
                        _quitProjectButton.MouseLeave += _quitProjectButton_MouseLeave;


                        //Creating the new proejct panel 

                        if(Dimensions.GetWidth() > 1900)
                        {
                                _subContainer = new CustomControls.Home.NewProjectPanel(_createProjectButton, _quitProjectButton, _containerPanel.Width);
                                ReloadLayout();
                        }

                        else
                        {
                                NewProjectPopUp newp = new NewProjectPopUp(Dimensions.GetWidth()*0.5,Dimensions.GetHeight()*0.8, "New project");
                        }
                        
                        return _mainPanel;
                       
                }

                public StackPanel GetOpenProjectPanel()
                {
                        OpenProjectPanel openProjectPanel = new CustomControls.Home.OpenProjectPanel(_chief._guru._propSelector.SelectProjects(), _containerPanel.Width);

                        _subContainer = openProjectPanel;

                        openProjectPanel._leaveButton.MouseDown += _leaveButton_MouseDown;

                        ReloadLayout();
                        return _mainPanel;
                } 

                private void RestoreDefaultLayout()
                {
                        this.SetUpLatestProjects();
                        this.SetUpFooter();
                        this.ReloadLayout();
                }

                private void ReloadLayout()
                {
                        _containerPanel.Children.Clear();
                        _containerPanel.Children.Add(_headerPanel);
                        _containerPanel.Children.Add(_itemsPanel);
                        _containerPanel.Children.Add(_itemsSeparator);
                        _containerPanel.Children.Add(_subContainer);
                }
                #endregion


                #region events
                void _leaveButton_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        this.RestoreDefaultLayout();
                }

                void _quitProjectButton_MouseLeave(object sender, MouseEventArgs e)
                {
                       // _quitProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL));
                }

                void _quitProjectButton_MouseEnter(object sender, MouseEventArgs e)
                {
                        //_quitProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.CANCEL_HOVER));
                }

                void _createProjectButton_MouseLeave(object sender, MouseEventArgs e)
                {
                        //_createProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.VALIDATE));
                }

                void _createProjectButton_MouseEnter(object sender, MouseEventArgs e)
                {
                        //_createProjectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(Palette2.VALIDATE_HOVER));
                }

                void _quitProjectButton_MouseDown(object sender, MouseButtonEventArgs e)
                {
                        RestoreDefaultLayout();
                }


                void _createProjectButton_MouseDown(object sender, MouseButtonEventArgs e)
                {
                       // _chief.InsertProject((NewProjectPanel)_subContainer.)
                }
                #endregion



#endregion


        }//class HomeLayoutNinja
}//ns
