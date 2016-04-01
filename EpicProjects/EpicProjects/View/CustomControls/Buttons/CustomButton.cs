using EpicProjects.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpicProjects.View.CustomControls
{
        public abstract class  CustomButton : StackPanel
        {
                public TextBlock _block { get; set; }

                public CustomButton(string content, double width, double height, System.Windows.Thickness margin, System.Windows.Thickness padding, HorizontalAlignment hAlign, Theme.Theme theme)
                {
                        _block = new TextBlock();
                        _block.Text = content;

                        this.Width = width;
                        this.Height = height;
                        this.Margin = margin;
                        
                        this.HorizontalAlignment = hAlign;

                        _block.Padding = padding;
                        _block.FontSize = 25;
                        _block.FontFamily = FontProvider._lato;
                        _block.Foreground = theme.GetAccentColor();
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                        this.Children.Add(_block);
                    

                        this.SetColor();
                }

                public abstract void SetColor();


        }//class CustomButton
}//ns
