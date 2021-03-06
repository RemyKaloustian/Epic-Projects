﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using EpicProjects.Model;
using EpicProjects.Constants;
using EpicProjects.Controller;
using EpicProjects.View.CustomControls;

using EpicProjects.View.Layout;
using EpicProjects.View.Theme;

namespace EpicProjects.View
{
        /// <summary>
        /// Interaction logic for ProjectWindow.xaml
        /// </summary>
        public partial class ProjectWindow : Window
        {
                

                public LayoutNinja _ninja { get; set; }

                public StackPanel _container { get; set; }

             

                public ProjectWindow(string name)
                {
                        InitializeComponent();
                        ThemeSelector.InitializeTheme();


                        _ninja = new ProjectLayoutNinja(name);
                        _container = _ninja.GetLayout();

                        ProjectGrid.Children.Add(_container);

                        SetUpWindow(name);

                        this.Closed += ProjectWindow_Closed;

                }

                void ProjectWindow_Closed(object sender, EventArgs e)
                {
                        App.Current.Shutdown();
                }

                private void SetUpWindow(string name)
                {
                        this.Width = Dimensions.GetWidth();
                        this.Height = Dimensions.GetHeight();
                        this.MinHeight = Dimensions.GetHeight();
                        this.MinWidth = Dimensions.GetWidth();
                        this.ResizeMode = System.Windows.ResizeMode.CanResize;
                        this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        this.WindowState = WindowState.Maximized;
                        this.Title = name;
                }

             
        }//class ProjectWindow
}//ns
