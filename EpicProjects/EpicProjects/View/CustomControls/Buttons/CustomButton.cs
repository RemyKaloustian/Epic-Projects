using EpicProjects.Constants;
using EpicProjects.View.Theme;
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

                public CustomButton(string content, double width, double height, System.Windows.Thickness margin, System.Windows.Thickness padding, HorizontalAlignment hAlign)
                {
                        _block = new TextBlock();
                        _block.Text = content;

                        this.Width = width;
                        this.Height = height;
                        this.Margin = margin;
                        this.Background = ThemeSelector.GetButtonColor();
                        
                        this.HorizontalAlignment = hAlign;

                        _block.Padding = padding;
                        _block.FontSize = 25;
                        _block.FontFamily = FontProvider._lato;
                        _block.Foreground = ThemeSelector.GetButtonContentColor();
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;


                        this.Children.Add(_block);

                        this.MouseLeave += CustomButton_MouseLeave;
                        this.MouseEnter += CustomButton_MouseEnter;
                    

                        //this.SetColor();
                }

                void CustomButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = ThemeSelector.GetButtonHoverColor();
                        _block.Foreground = ThemeSelector.GetButtonColor();
                }

                void CustomButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
                {
                        this.Background = ThemeSelector.GetButtonColor();
                        _block.Foreground = ThemeSelector.GetButtonContentColor();
                }


                //public  void SetColor();


        }//class CustomButton
}//ns
