﻿using EpicProjects.Constants;
using EpicProjects.View.CustomControls.Buttons;
using EpicProjects.View.CustomControls.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Panels
{
        public class OptionsPanel : StackPanel
        {

                public DefaultButton _sortButton { get; set; }
                public DefaultButton  _showDoneButton{ get; set; }
                public OptionsPanel()
                {
                        this.Orientation = Orientation.Vertical;
                        this.Width = Dimensions.GetWidth() * 0.27;
                        this.Height = Dimensions.GetHeight() * 0.8;
                        this.Background = new Theme.CustomTheme().GetAccentColor();

                        _sortButton = new DefaultButton("Sort",this.Width/2,this.Height/20, new System.Windows.Thickness(0,20,0,0),new System.Windows.Thickness(0,0,0,0),HorizontalAlignment,new Theme.CustomTheme());


                        _showDoneButton = new DefaultButton("Show done", this.Width / 2, this.Height / 20, new System.Windows.Thickness(0, 20, 0, 0), new System.Windows.Thickness(0, 0, 0, 0), HorizontalAlignment, new Theme.CustomTheme());
                       

                        this.Children.Add(_sortButton);
                        this.Children.Add(_showDoneButton);
                }

        }//class OptionsPanel
}//ns
