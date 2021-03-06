﻿using EpicProjects.Constants;
using EpicProjects.View.CustomControls.Items;
using EpicProjects.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using EpicProjects.Constants.Images;
using System.Windows;
using EpicProjects.View.CustomControls.PopUp;
using EpicProjects.View.Theme;
using EpicProjects.Controller;

namespace EpicProjects.View.CustomControls.Panels
{
        

        public class SideMenuPanel : StackPanel
        {
                public string _project { get; set; }

                public SideMenuItem _newProjectItem { get; set; }

                public SideMenuItem _openProjectItem { get; set; }

                public SideMenuItem _statsItem { get; set; }

                public SideMenuItem _bugItem { get; set; }

                public SideMenuItem _homeItem { get; set; }

                public SideMenuItem _settingsItem { get; set; }

                

                public SideMenuPanel(string project)
                {
                        this.Orientation = System.Windows.Controls.Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.1;
                        this.Height = Dimensions.GetHeight();
                        _project = project;

                        _newProjectItem = new SideMenuItem(ControlsValues.NEWPROJECT, Responsive.GetSideMenuTextSize());
                        _newProjectItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);
                        _newProjectItem.MouseDown += _newProjectItem_MouseDown;

                        _openProjectItem = new SideMenuItem(ControlsValues.OPENPROJECT,Responsive.GetSideMenuTextSize());
                        _openProjectItem.Padding = new Thickness(this.Width * 0.1,this.Width/8,0,this.Width/8);
                        _openProjectItem.MouseDown += _openProjectItem_MouseDown;


                        _statsItem = new SideMenuItem(ControlsValues.STATS,Responsive.GetSideMenuTextSize());
                        _statsItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);
                        _statsItem.MouseDown += _statsItem_MouseDown;


                        _bugItem = new SideMenuItem(ControlsValues.REPORT,Responsive.GetSideMenuTextSize());
                        _bugItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);
                        _bugItem.MouseDown += _bugItem_MouseDown;


                        _homeItem = new SideMenuItem(ControlsValues.HOME,Responsive.GetSideMenuTextSize());
                        _homeItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);
                        _homeItem.MouseDown += _homeItem_MouseDown;

                        _settingsItem = new SideMenuItem(ControlsValues.SETTINGS, Responsive.GetSideMenuTextSize());
                        _settingsItem.Padding = new Thickness(this.Width * 0.1, this.Width / 8, 0, this.Width / 8);
                        _settingsItem.MouseDown += _settingsItem_MouseDown;


                        this.Children.Add(_newProjectItem);
                        this.Children.Add(_openProjectItem);
                        this.Children.Add(_statsItem);
                        this.Children.Add(_bugItem);
                        this.Children.Add(_homeItem);
                        this.Children.Add(_settingsItem);

                        this.Background = ThemeSelector.GetBackground();

                }

                void _settingsItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        Settings s = new Settings(_project);
                }

                void _statsItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        StatsPopUp st = new StatsPopUp(Dimensions.GetWidth()*0.6, Dimensions.GetHeight()*0.8, "Statistics", _project);
                }

                void _bugItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        ReportBug bug = new ReportBug(Dimensions.GetWidth() * 0.6, Dimensions.GetHeight() * 0.8, "Report a bug");
                }

                void _openProjectItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        OpenProjectPopUp op = new OpenProjectPopUp(Dimensions.GetWidth() * 0.6, Dimensions.GetHeight() * 0.8, "Open project");
                }

                void _newProjectItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        NewProjectPopUp newP = new NewProjectPopUp(Dimensions.GetWidth() * 0.6, Dimensions.GetHeight() * 0.8, "New Project");
                }

                void _homeItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
                {
                        foreach (Window win in App.Current.Windows)
                        {                               
                                    win.Hide();                            
                        }

                        View.Home j = new View.Home();
                        j.Show();                       
                }

        }//class MenuPanel
}//ns
