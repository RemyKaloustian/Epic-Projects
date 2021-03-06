﻿using EpicProjects.Constants;
using EpicProjects.Model;
using EpicProjects.View.CustomControls.Panels;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.Layout
{
        public class ProjectLayoutNinja :LayoutNinja
        {
                public Project _project { get; set; }
                public StackPanel _menuPanel { get; set; }
                public StackPanel _centralPanel { get; set; }

                public string _name  { get; set; }
                public ProjectLayoutNinja(string name)
                {
                        _project = new Project(name);
                        _name = name;

                       
                }

                public override System.Windows.Controls.StackPanel GetLayout()
                {
                      
                       _menuPanel = new SideMenuPanel(_name);
                       _centralPanel = new CentralPanel(_name);
                       _centralPanel.Background = ThemeSelector.GetContentBackground();

                       StackPanel container = new StackPanel();
                       container.Orientation = Orientation.Horizontal;
                       container.Children.Add(_menuPanel);
                       container.Children.Add(_centralPanel);

                       return container;
                }
        }//class ProjectLayoutNinja
}//ns
