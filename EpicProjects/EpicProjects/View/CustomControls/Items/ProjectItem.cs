﻿using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Items
{
        public class ProjectItem : StackPanel
        {
                public TextBlock _nameBlock{ get; set; }
                public TextBlock _ratioBlock { get; set; }

                public ProjectItem(double height, string content, string ratio)
                {
                        this.Height = height;
                        this.Background = ThemeSelector.GetPopUpBackground();
                        this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                        this.Margin = new System.Windows.Thickness(100,0,0,0);

                        SetUpNameBlock(content);
                        SetUpRatioBlock(ratio);

                        this.Children.Add(_nameBlock);
                        this.Children.Add(_ratioBlock);

                }//ProjectItem()

                private void SetUpRatioBlock(string ratio)
                {
                        _ratioBlock = new TextBlock();
                        _ratioBlock.Text = ratio;
                        _ratioBlock.FontFamily = FontProvider._lato;
                        _ratioBlock.FontSize = 17;
                        _ratioBlock.Foreground = ThemeSelector.GetBackground();
                        _ratioBlock.Margin = new System.Windows.Thickness(40, 0, 0, 0);
                        _ratioBlock.TextWrapping = System.Windows.TextWrapping.Wrap;
                }//SetUpRatioBlock()

                private void SetUpNameBlock(string content)
                {
                        _nameBlock = new TextBlock();
                        _nameBlock.Text = content;
                        _nameBlock.FontFamily = FontProvider._lato;
                        _nameBlock.FontSize = 17;
                        _nameBlock.Foreground = ThemeSelector.GetBackground();
                        _nameBlock.Margin = new System.Windows.Thickness(40, 0, 0, 0);
                        _nameBlock.TextWrapping = System.Windows.TextWrapping.Wrap;
                }//SetUpNameBlock()

                public void Hover()
                {
                        this.Background = ThemeSelector.GetBackground();
                        _nameBlock.Foreground = ThemeSelector.GetAccentColor();
                        _ratioBlock.Foreground = ThemeSelector.GetAccentColor();

                }//Hover()

                public void Unhover()
                {
                        this.Background = ThemeSelector.GetPopUpBackground();
                        _nameBlock.Foreground = ThemeSelector.GetBackground();
                        _ratioBlock.Foreground = ThemeSelector.GetBackground();
                }//Unhover()



        }//class ProjectItem
}//ns
