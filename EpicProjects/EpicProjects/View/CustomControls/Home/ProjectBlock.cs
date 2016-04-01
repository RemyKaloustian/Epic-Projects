using EpicProjects.Constants;
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

                public ProjectBlock(string content, double width, double height, Theme.Theme theme)
                {
                        _block = new TextBlock();
                        _block.Text = content;
                        _block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        _block.Foreground = theme.GetAccentColor();
                        _block.FontFamily = FontProvider._lato;
                        _block.FontSize = 18;

                        this.Background = theme.GetBackground();
                        this.Width = width;
                        this.Height = height;
                        _theme = theme;
                        this.Children.Add(_block);



                }//ProjectBlock() 

                public void GetSelected()
                {
                        this.Background = _theme.GetAccentColor();
                        _block.Foreground = _theme.GetBackground();
                }//GetSelected

                public void GetUnselected()
                {
                        this.Background = _theme.GetBackground();
                        _block.Foreground = _theme.GetAccentColor();
                }//GetUnselected()
        }//class projectBlock
}//ns
