using EpicProjects.Constants;
using EpicProjects.View.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EpicProjects.View.CustomControls.Home
{
        public class ProjectBlock : StackPanel
        {
                public TextBlock _block { get; set; }

                public Theme.Theme _theme { get; set; }

                public ProjectBlock(string content, double width, double height)
                {
                        _block = new TextBlock();
                        _block.Text = content;
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _block.Foreground = ThemeSelector.GetAccentColor();
                        _block.FontFamily = FontProvider._lato;
                        _block.FontSize = 18;

                        this.Background = ThemeSelector.GetBackground();
                        this.Width = width;
                        this.Height = height;
                       
                        this.Children.Add(_block);



                }//ProjectBlock() 

                public void GetSelected()
                {
                        this.Background = ThemeSelector.GetAccentColor();
                        _block.Foreground = ThemeSelector.GetBackground();
                }//GetSelected

                public void GetUnselected()
                {
                        this.Background = ThemeSelector.GetBackground();
                        _block.Foreground = ThemeSelector.GetAccentColor();
                }//GetUnselected()
        }//class projectBlock
}//ns
